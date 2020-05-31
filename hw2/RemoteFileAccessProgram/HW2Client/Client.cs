using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PacketClass;

namespace RemoteFileAccessProgram
{
    public enum TREE_IMAGE
    {
        FOLDER,
        VEDIO,      // avi, mp4
        IMAGE,      // jpg, png
        MUSIC,      // mp3 ,wav
        TEXT,       // txt
        OTHER
    }
    public partial class Client : Form
    {
        #region 변수
        IPAddress IP; int PORT;
        DetailView child;//상세정보Form

        //Server Client Members
        public NetworkStream m_Stream;//네트워크 스트림
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        //client members
        public bool m_bConnect = false; //서버 접속 플래그
        TcpClient m_Client; //클라이언트구나 자기 자신을 말하는건가?
        #endregion

        public Client()
        {
            InitializeComponent();
        }
        #region 연결부분
        private void btnServerConnect_Click(object sender, EventArgs e) //연결을 누르면 젤먼저 실행
        {
            if (txtDownloadPath.Text.Length <= 0)
            {
                MessageBox.Show("경로가 설정되어있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtIP.Text.Length <= 0 || txtPort.Text.Length <= 0)
            {
                MessageBox.Show("빈칸을 모두 기입한 후 서버를 연결해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIP.Focus();
                return;
            }

            if (btnServerConnect.Text == "서버연결")
            {
                Connect();//연결시도
                if (m_bConnect)
                {
                    btnServerConnect.Text = "연결끊기";
                    btnServerConnect.ForeColor = Color.Red;
                }
            }
            else
            {
                Disconnect();
            }
        }
        public void Connect()
        {
            //연결시에 입력한 txt를 기반으로 클라이언트를 연결한다.
            IP = IPAddress.Parse(txtIP.Text);
            PORT = int.Parse(txtPort.Text);
            m_Client = new TcpClient();//서버에 접속하기 위한 클라이언트 객채 만듦
            try
            {
                m_Client.Connect(IP, PORT);//해당 IP와 PORT로 연결시도.
            }
            catch
            {
                //연결 실패 했다는 메세지를 출력해줬으면 좋겠다.
                m_bConnect = false;
                return;
            }

            m_bConnect = true;
            m_Stream = m_Client.GetStream(); //아이디로부터 스트림을 받아온다.

            FirstInit();//서버에 init정보 요청

        }

        public void FirstInit()
        {
            //서버한테  초기화정보 요청
            Packet Init = new Packet();
            Init.Type = (int)PacketType.INIT;//INIT 패킷
            Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
            Send();

            int bytes = m_Stream.Read(readBuffer, 0, 1024 * 4);
            string path = Encoding.UTF8.GetString(readBuffer, 0, bytes);

            //선택 정보 보내기
            Packet dInfo = new Packet();
            dInfo.Type = (int)PacketType.Select;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();


            /* Set TreeView */
            TreeNode root;
            root = trvDir.Nodes.Add(path);
            root.ImageIndex = (int)TREE_IMAGE.FOLDER; // folder
            //파일이면 어떻게 하징? Path로 등록할 수 있나?
            if (trvDir.SelectedNode == null)
                trvDir.SelectedNode = root;
            root.SelectedImageIndex = root.ImageIndex;
            root.Nodes.Add("");

            /* Set ListView */
            ViewRight(path);
            //BeforeSelectMethod(path);//해당 패스에 대한 dir 정보를 불러온다.

        }


        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            Messenger ms = new Messenger(e.Node.FullPath+"를 BefroeSelect에서 보냅니다.");
            ms.Type= (int)PacketType.MESSAGE;
            Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
            Send();

            ViewRight(e.Node.FullPath);
        }

        public void Send()
        {
            try
            {
                this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
                this.m_Stream.Flush();
                for (int i = 0; i < 1024 * 4; i++)
                {
                    this.sendBuffer[i] = 0;
                }
            }
            catch
            {
                MessageBox.Show("전송 오류");
                return;
            }
            
        }

        public void Disconnect()
        {
            if (!m_bConnect) return;

            //서버에도 연결을 끊었다는 신호를 보내주어야 한다.
            Disconnection ds = new Disconnection();
            ds.Type = (int)PacketType.EXIT;
            Packet.Serialize(ds).CopyTo(this.sendBuffer, 0);
            Send();

            m_bConnect = false;
            m_Client.Close();
            m_Stream.Flush();
            m_Stream.Close();

            lvwFiles.Clear();
            trvDir.Nodes.Clear();
            btnServerConnect.Text = "서버연결";
            btnServerConnect.ForeColor = Color.Black;
            //Message("상대방과 연결 중단");
        }
        #endregion

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;
            foreach (ListViewItem item in siList)
            {
                OpenItem(item);
            }
        }
        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;
            if (item.Tag.ToString() == "D")
            {
                //현재 선택된 트리뷰의 노드를 확장
                node = trvDir.SelectedNode;
                node.Expand();

                //확장된 노드 중 현재 리스트뷰에서 선택한 같은 노드를 선택
                child = node.FirstNode;
                while (child != null)
                {
                    if (child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else
            {
                Process.Start(txtDownloadPath.Text + "\\" + item.Text);
            }
        }



        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void mnuMoreInfo_Click(object sender, EventArgs e)
        {
            child = new DetailView();
            child.Owner = this;//mdiParent??

            ListView.SelectedListViewItemCollection lvc = lvwFiles.SelectedItems;
            ListViewItem lv = lvc[0];

            child.FileImage.Image = null;
            child.txtFileName.Text = lv.Name;
            child.lbFileType.Text = "lbFileType";
            child.lbLocation.Text = "lbLocation";
            child.lbSize.Text = "lbSize";
            child.lbCreateDate.Text = "lbCreateDate";
            child.lbEditDate.Text = "lbEditDate";
            child.lbExcessDate.Text = "lbExcessDate";

            //선택한 파일에 대한 정보가 public이어서 모달이 접근 가능하게 만들어야됨.
            //그다음에 파일에 대한 정보를 모달에게 전달해주어야 댐

            child.Show();//여러창 가능, 다른창 사용가능

        }
        #region 수정 안해도 되는 함수들

        private void btnPathSetting_Click(object sender, EventArgs e)
        {
            //선택된 경로 표시
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtDownloadPath.Text = folderBrowser.SelectedPath;
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            mnuDetail.Checked = false;
            mnuList.Checked = false;
            mnuSmall.Checked = false;
            mnuLarge.Checked = false;

            switch (item.Text)
            {
                case "자세히":
                    mnuDetail.Checked = true;
                    lvwFiles.View = View.Details;
                    break;
                case "간단히":
                    mnuList.Checked = true;
                    lvwFiles.View = View.List;
                    break;
                case "작은아이콘":
                    mnuSmall.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "큰아이콘":
                    mnuLarge.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }

        #endregion
        public void setPlus(TreeNode node)
        {

            File_Info dInfo = new File_Info();//하위 디렉토리에 대한 하위 정보 얻어오기
            //dInfo.SetPath(node.FullPath);
            dInfo.Type = (int)PacketType.FILE_INFO;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();

            File_Info fInfo = (File_Info)Packet.Desserialize(readBuffer);

            if (fInfo.length > 0)//하위디렉토리 길이가 양수라면.
                node.Nodes.Add("");
        }
        private void trvDir_BeforeExpand_1(object sender, TreeViewCancelEventArgs e)
        {
            File_Info dInfo = new File_Info();//path에 대한 directory정보 읽어오기
            dInfo.SetPath(e.Node.FullPath);
            dInfo.Type = (int)PacketType.Expand;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();

            try
            {
                m_Stream.Read(readBuffer, 0, 1024 * 4);
            }
            catch
            {
                MessageBox.Show("디렉토리 읽기 에러");
                return;
            }
            File_Info fInfo = (File_Info)Packet.Desserialize(readBuffer);//Desserialize

            DirectoryInfo[] diArray = fInfo.diArray;//하위디렉토리
            FileInfo[] fiArray = fInfo.fiArray;

            TreeNode node;
            try
            {
                e.Node.Nodes.Clear();

                foreach (DirectoryInfo dirs in diArray)
                {
                    //루트 디렉토리 바로 및 디렉토리를 보여줌.
                    node = e.Node.Nodes.Add(dirs.Name);//하위 디렉토리 정보들을 노드에 추가한다.
                    setPlus(node);//하위 디렉토리 정보 밑에 세부 폴더가 있다면 setPlus 함수를 실행한다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trvDir_BeforeSelect_1(object sender, TreeViewCancelEventArgs e)
        {
            Packet dInfo = new Packet();
            dInfo.Type = (int)PacketType.Select;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();

            ViewRight(e.Node.FullPath);
            
            //Select dInfo = new Select();
            //dInfo.Type = (int)PacketType.Expand;
            //Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            //ViewRight(e.Node.FullPath);
        }
        void ViewRight(string path)
        {
            File_Info dInfo = new File_Info();
            dInfo.SetPath(path);
            dInfo.Type = (int)PacketType.FILE_INFO;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();


            try
            {
                m_Stream.Read(readBuffer, 0, 1024 * 4);
            }
            catch
            {
                MessageBox.Show("디렉토리 읽기 에러");
                return;
            }
            File_Info fInfo = (File_Info)Packet.Desserialize(readBuffer);//Desserialize
            console.Text = fInfo.GetPath() + "\r\n" + path;

            //console.Text = fInfo.di.FullName+"\r\n"+path;
            //DirectoryInfo di = fInfo.di;//디렉토리 정보
            //DirectoryInfo[] diArray = fInfo.diArray;//하위디렉토리
            //FileInfo[] fiArray = fInfo.fiArray;
            ListViewItem item;

            try
            {
                lvwFiles.Items.Clear();

                foreach (DirectoryInfo di in fInfo.diArray)
                {
                    item = lvwFiles.Items.Add(di.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(di.LastWriteTime.ToString());
                    item.ImageIndex = (int)TREE_IMAGE.FOLDER;
                    item.Tag = "D";
                }
                
                foreach (FileInfo fi in fInfo.fiArray)
                {
                    item = lvwFiles.Items.Add(fi.Name);
                    item.SubItems.Add(fi.Length.ToString());
                    item.SubItems.Add(fi.LastWriteTime.ToString());

                    if (fi.Extension == ".avi" || fi.Extension == ".mp4")
                        item.ImageIndex = (int)TREE_IMAGE.VEDIO;
                    else if (fi.Extension == ".jpg" || fi.Extension == ".png")
                        item.ImageIndex = (int)TREE_IMAGE.IMAGE;
                    else if (fi.Extension == ".mp3" || fi.Extension == ".wav")
                        item.ImageIndex = (int)TREE_IMAGE.MUSIC;
                    else if (fi.Extension == ".txt")
                        item.ImageIndex = (int)TREE_IMAGE.TEXT;
                    else
                        item.ImageIndex = (int)TREE_IMAGE.OTHER;

                    item.Tag = "F";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void lvwFiles_ItemActivate(object sender, EventArgs e)
        {

        }
        private void lvwFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
