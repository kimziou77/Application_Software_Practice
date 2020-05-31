using PacketDefine;
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
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static PacketDefine.Class1;

namespace Client
{
    public partial class Client : Form
    {
        bool DEBUGGING = false;

        public Client()
        {
            InitializeComponent();
            files = new Dictionary<string, FileInfo>();
        }

        #region 변수
        IPAddress IP; int PORT;
        Detail child;//상세정보Form

        //Server Client Members
        public NetworkStream m_Stream;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        //client members
        public bool m_bConnect = false;
        TcpClient m_Client;

        //path에 대한 file정보를 저장하고 있음.
        Dictionary<string, FileInfo> files;

        //선택된 path 정보
        string selectedPath;
        ListViewItem selectedList;
        #endregion

        #region 서버연결/해제 함수
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
                m_bConnect = false;
                return;
            }
            btnServerConnect.Text = "연결끊기";
            btnServerConnect.ForeColor = Color.Red;
            m_bConnect = true;
            m_Stream = m_Client.GetStream();

            FirstInit();//서버에 init정보 요청
        }

        public void Disconnect()
        {
            if(btnServerConnect.Text == "서버연결") return;
            
            btnServerConnect.Text = "서버연결";
            btnServerConnect.ForeColor = Color.Black;


            if (!m_Client.Connected) return; //이미 서버가 꺼져있다면 return;

            try
            {
                if (DEBUGGING)
                {
                    Messenger ms = new Messenger("@[+]Disconnect[-]");
                    ms.Type = (int)PacketType.MESSAGE;//INIT 패킷
                    Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                    Send();
                }

                //서버에도 연결을 끊었다는 신호를 보내주어야 한다.
                Packet pk = new Packet();
                pk.Type = (int)PacketType.EXIT;
                Packet.Serialize(pk).CopyTo(this.sendBuffer, 0);
                Send();
            }
            catch(Exception e)
            {
                txtPort.Text = e.StackTrace;
                //서버쪽에서 연결을 해제함.
            }

            try
            {
                m_bConnect = false;
                lvwFiles.Clear();
                trvDir.Nodes.Clear();
                m_Client.Close();
                m_Stream.Flush();
                m_Stream.Close();
            }
            catch(Exception e)
            {
                txtIP.Text = e.StackTrace;
            }

        }
        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
        #endregion

        public void FirstInit()
        {
            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[+]FirstInit");
                ms.Type = (int)PacketType.MESSAGE;//INIT 패킷
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
            //서버한테  초기화정보 요청
            Packet Init = new Packet();
            Init.Type = (int)PacketType.INIT;//INIT 패킷
            Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
            Send();

            int bytes = m_Stream.Read(readBuffer, 0, 1024 * 4);
            string path = Encoding.UTF8.GetString(readBuffer, 0, bytes);

            TreeNode root;
            root = trvDir.Nodes.Add(path);  //서버에 최초로 등록된 path를 받는다.
            root.ImageIndex = (int)TREE_IMAGE.FOLDER;
            if (trvDir.SelectedNode == null)
                trvDir.SelectedNode = root;
            root.SelectedImageIndex = root.ImageIndex;
            root.Nodes.Add("");

            //SetListView(path);//BeforeSelectMethod(path);//해당 패스에 대한 dir 정보를 불러온다.

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[-]FirstInit");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
        }
        void SetListView(string path)
        {

            Messenger mes = new Messenger("BeforeSelect 데이터 요청...");
            mes.Type = (int)PacketType.MESSAGE;
            Packet.Serialize(mes).CopyTo(this.sendBuffer, 0);
            Send();

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[+]ViewRight");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
            selectedPath = path;

            File_Info dInfo = new File_Info(path);
            dInfo.Type = (int)PacketType.FILE_INFO;
            Packet.Serialize(dInfo).CopyTo(this.sendBuffer, 0);
            Send();

            m_Stream.Read(readBuffer, 0, 1024 * 4);
            File_Info fInfo = (File_Info)Packet.Desserialize(readBuffer);//Desserialize

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("SetListVeiwPath : " + fInfo.path);
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
            //MessageBox.Show(path);

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
                    if (!files.ContainsKey(path + "\\" + fi.Name))
                        files.Add(path + "\\" + fi.Name, fi);//path에 대한 fileinfo

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
                    selectedList = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[-]ViewRight");
                ms.Type = (int)PacketType.MESSAGE;//INIT 패킷
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
        }
        private void setPlus(TreeNode node, int Dir_len)
        {
            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[+]setPlus");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }

            if (Dir_len > 0)//하위디렉토리 길이가 양수라면.
                node.Nodes.Add("");

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[-]setPlus");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
        }
        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();
            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        #region 트리 이벤트
        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[+]TreeBeforeSelect");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(sendBuffer, 0);
                Send();
            }

            SetListView(e.Node.FullPath);

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[-]TreeBeforeSelect");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(sendBuffer, 0);
                Send();
            }
        }
        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            Messenger mes = new Messenger("BeforeExpand...");
            mes.Type = (int)PacketType.MESSAGE;
            Packet.Serialize(mes).CopyTo(this.sendBuffer, 0);
            Send();

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[+]TreeBeforeExpand");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }

            string path = e.Node.FullPath;

            File_Info fi = new File_Info(path);//해당 path의 하위 디렉토리들을 돌며 하위 디렉토리를 얻는다.
            fi.Type = (int)PacketType.FILE_INFO;
            Packet.Serialize(fi).CopyTo(this.sendBuffer, 0);
            Send();

            m_Stream.Read(readBuffer, 0, 1024 * 4);
            File_Info fInfo = (File_Info)Packet.Desserialize(readBuffer);//Desserialize

            TreeNode node;
            e.Node.Nodes.Clear();

            foreach (DirectoryInfo dis in fInfo.diArray)
            {
                node = e.Node.Nodes.Add(dis.Name);
                setPlus(node, fInfo.diArray.Length);
            }

            if (DEBUGGING)
            {
                Messenger ms = new Messenger("@[-]TreeBeforeExpand");
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
            }
        }
        #endregion

        #region 리스트 이벤트
        private void lvwFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //선택한 ListViewItem을 저장한다.
            selectedList = e.Item;
        }
        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            TreeNode node;
            TreeNode child;

            if (selectedList.Tag.ToString() == "D") //폴더면 열어주고
            {
                node = trvDir.SelectedNode;
                node.Expand();
                child = node.FirstNode;
                while (child != null)
                {
                    if (child.Text == selectedList.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        //child.Expand();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else//더블클릭시 상세정보 출력
            {
                mnuMoreInfo_Click(sender, e);
                //Process.Start(selectedPath + "\\" + selectedList.Text);
            }
        }
        #endregion

        #region ConTextMenuStrip
        private void mnuMoreInfo_Click(object sender, EventArgs e)
        {
            if (selectedList.Tag.ToString() == "D")
            {
                MessageBox.Show("디렉토리 상세정보 지원 안함.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileInfo f = files[selectedPath + "\\" + selectedList.Text];
            child = new Detail(f);
            child.Show();
        }
        private void mnuDetail_Click(object sender, EventArgs e)
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

        #region 클라이언트 버튼 3개
        private void btnPath_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowser.SelectedPath;
            }
        }
        private void btnServerConnect_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Length <= 0)
            {
                MessageBox.Show("경로가 설정되어있지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtIP.Text.Length <= 0 || txtPort.Text.Length <= 0)
            {
                MessageBox.Show("빈칸을 모두 기입한 후 서버를 연결해주세요.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
                return;
            }
            int port = int.Parse(txtPort.Text);
            if (port < 0 || port > 65535){
                MessageBox.Show("잘못된 포트번호 입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
            }

            if (btnServerConnect.Text == "서버연결")
                Connect();
            else
                Disconnect();
        }
        private void btnDir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("준비중");
        }
        #endregion

        private void mnuDownload_Click(object sender, EventArgs e)
        {
            if (selectedList.Tag.ToString() == "D")
            {
                MessageBox.Show("폴더는 다운로드를 지원하지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DownFile df = new DownFile();
            df.name = selectedList.Text;
            df.ClientPath = txtPath.Text;
            df.ServerPath = selectedPath + "\\" + selectedList.Text;
            df.Type = (int)PacketType.DOWNLOAD;
            Packet.Serialize(df).CopyTo(this.sendBuffer, 0);
            Send();

            FileInfo f = files[selectedPath + "\\" + selectedList.Text];

            FileStream file = null;
            BinaryWriter bw = null;

            try
            {
                // 파일 스트림 생성
                file = new FileStream(df.ClientPath +"\\"+ df.name, FileMode.Create);
                bw = new BinaryWriter(file);
                //파일이 이미 존재하는 경우 unAuto.... 예외발생
                byte[] bytesFileBuffer = new byte[f.Length];
                int bytes = m_Stream.Read(bytesFileBuffer, 0, (int)f.Length);
                bw.Write(bytesFileBuffer);
            }
            catch(UnauthorizedAccessException ex)
            {
                Messenger ms = new Messenger("파일 수신 접근권한거부 : " + ex.StackTrace) ;
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
                return;
            }
            catch(Exception ex)
            {
                Messenger ms = new Messenger("파일 수신 실패 : "+ ex.Message);
                ms.Type = (int)PacketType.MESSAGE;
                Packet.Serialize(ms).CopyTo(this.sendBuffer, 0);
                Send();
                return;
            }
            finally
            {
                // 파일 스트림 닫기
                if(bw!=null)    bw.Close();
                if(file!=null)  file.Close();
            }

            Messenger ms2 = new Messenger(df.name + " 데이터 다운로드 완료...");
            ms2.Type = (int)PacketType.MESSAGE;
            Packet.Serialize(ms2).CopyTo(this.sendBuffer, 0);
            Send();
        }
    }
}
