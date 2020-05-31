using PacketDefine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{

    public partial class Detail : Form
    {
        public int imageIndex;
        public Detail()
        {
            InitializeComponent();
        }
        public Detail(FileInfo f)
        {
            InitializeComponent();
            
            txtFileName.Text = f.Name;
            lbFileType.Text = f.Extension.Substring(1);
            lbLocation.Text = f.FullName;
            lbCreateDate.Text = f.CreationTime.ToString();
            lbEditDate.Text = f.LastWriteTime.ToString();
            lbAcessDate.Text = f.LastAccessTime.ToString();
            lbSize.Text = f.Length.ToString()+" 바이트";

            SetImage(f);
            FileImage.Image = imageList1.Images[imageIndex];
        }
        void SetImage(FileInfo fi)
        {
            
            if (fi.Extension == ".avi" || fi.Extension == ".mp4")
                imageIndex = (int)TREE_IMAGE.VEDIO;
            else if (fi.Extension == ".jpg" || fi.Extension == ".png")
                imageIndex = (int)TREE_IMAGE.IMAGE;
            else if (fi.Extension == ".mp3" || fi.Extension == ".wav")
                imageIndex = (int)TREE_IMAGE.MUSIC;
            else if (fi.Extension == ".txt")
                imageIndex = (int)TREE_IMAGE.TEXT;
            else
                imageIndex = (int)TREE_IMAGE.OTHER;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
