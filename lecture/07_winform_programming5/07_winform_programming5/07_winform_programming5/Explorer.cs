using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
  

namespace _07_winform_programming5
{
    
    public partial class Explorer : Form
    {
        public Explorer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Drv_list;
            TreeNode root;
            Drv_list = Environment.GetLogicalDrives();

            foreach(string Drv in Drv_list)
            {
                root = trvDir.Nodes.Add(Drv);
                root.ImageIndex = 2;//이미지 리스트 번호?

                if (trvDir.SelectedNode == null)
                    trvDir.SelectedNode = root;
                root.SelectedImageIndex = root.ImageIndex;
                root.Nodes.Add("");
            }
        }
        public void setPlus(TreeNode node)
        {
            string path;
            DirectoryInfo dir;
            DirectoryInfo[] di;
            try
            {
                path = node.FullPath;
                dir = new DirectoryInfo(path);
                di = dir.GetDirectories();
                if (di.Length > 0)
                    node.Nodes.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;
            foreach(ListViewItem item in siList)
            {
                OpenItem(item);
            }
        }
        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;
            if(item.Tag.ToString() == "D")
            {
                node = trvDir.SelectedNode;
                node.Expand();

                child = node.FirstNode;
                while(child != null)
                {
                    if(child.Text == item.Text)
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
                Process.Start(txtPath.Text + "\\" + item.Text);
            }
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            string path;
            DirectoryInfo dir;
            DirectoryInfo[] di;
            TreeNode node;
            try
            {
                e.Node.Nodes.Clear();
                path = e.Node.FullPath;
                dir = new DirectoryInfo(path);
                di = dir.GetDirectories();

                foreach(DirectoryInfo dirs in di)
                {
                    node = e.Node.Nodes.Add(dirs.Name);
                    setPlus(node);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            DirectoryInfo di;
            DirectoryInfo[] diarray;
            ListViewItem item;
            FileInfo[] fiArray;

            try
            {
                di = new DirectoryInfo(e.Node.FullPath);
                txtPath.Text = e.Node.FullPath.Substring(0, 2) + e.Node.FullPath.Substring(3);
                lvwFiles.Items.Clear();

                diarray = di.GetDirectories();
                foreach(DirectoryInfo tdis in diarray)
                {
                    item = lvwFiles.Items.Add(tdis.Name);
                    item.SubItems.Add("");
                    item.SubItems.Add(tdis.LastWriteTime.ToString());
                    item.ImageIndex = 0;
                    item.Tag = "D";

                    fiArray = di.GetFiles();
                    foreach(FileInfo fis in fiArray)
                    {
                        item = lvwFiles.Items.Add(fis.Name);
                        item.SubItems.Add(fis.Length.ToString());
                        item.SubItems.Add(fis.LastWriteTime.ToString());
                        item.ImageIndex = 1;
                        item.Tag = "F";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                case "작은 아이콘":
                    mnuSmall.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "큰 아이콘":
                    mnuLarge.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }

    }

}
