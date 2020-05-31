using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteFileAccessProgram
{
    public partial class DetailView : Form
    {
        public string name;
        public string excessDate;
        public string fileType;
        public string location;
        public int size;

        public DetailView()
        {
            InitializeComponent();
            //this.txtFileName.Text="파일이름";
            //lbFileType.Text = "파일이름";
            //lbExcessDate;
            //lbFileType;
            //lbLocation;
            //lbSize;
        }
        public void SetDetailVal(string name, string excessDate, string fileType, string location, int size)
        {
            this.name = name;
            this.excessDate = excessDate;
            this.fileType = fileType;
            this.location = location;
            this.size = size;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
