using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW04
{
    public partial class Form1 : Form
    {
        public Form1(){
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e){
            picProfile.ImageLocation = txtUrl.Text;
        }
        private void rdoNormal_CheckedChanged(object sender, EventArgs e){
            picProfile.SizeMode = PictureBoxSizeMode.Normal;
        }
        private void rdoStretchImage_CheckedChanged(object sender, EventArgs e){
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void rdoAutoSize_CheckedChanged(object sender, EventArgs e){
            picProfile.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        private void rdoCenterImage_CheckedChanged(object sender, EventArgs e){
            picProfile.SizeMode = PictureBoxSizeMode.CenterImage;

        }
        private void rdoZoom_CheckedChanged(object sender, EventArgs e){
            picProfile.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void chkVisible_CheckedChanged(object sender, EventArgs e){
            picProfile.Visible = !chkVisible.Checked;
        }
        private void rdoOption_CheckedChanged(object sender, EventArgs e){
            var rdoOption = sender as RadioButton;
            if(null != rdoOption){
                PictureBoxSizeMode SizeMode;
                if (rdoOption == rdoNormal)
                    SizeMode = PictureBoxSizeMode.Normal;
                else if (rdoOption == rdoStretchImage)
                    SizeMode = PictureBoxSizeMode.StretchImage;
                else if (rdoOption == rdoAutoSize)
                    SizeMode = PictureBoxSizeMode.AutoSize;
                else if (rdoOption == rdoCenterImage)
                    SizeMode = PictureBoxSizeMode.CenterImage;
                else
                    SizeMode = PictureBoxSizeMode.Zoom;
                picProfile.SizeMode = SizeMode;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
        }
    }
}
