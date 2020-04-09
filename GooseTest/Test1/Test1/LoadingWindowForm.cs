using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test1
{
    public partial class LoadingWindowForm : Form
    {
        delegate void StringParameterDelegate(string Text);
        delegate void StringParameterWithStatusDelegate(string Text, TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();

        bool CloseSplashScreenFlag = false;

        public LoadingWindowForm()
        {
            InitializeComponent();
            pictureBox1.Image = System.Drawing.Image.FromFile("../../img/bear_doll.jpg");

            //라벨 색상 추가
            this.label1.Parent = this.pictureBox1;
            label1.Text = "Wait";
            label1.ForeColor = Color.AliceBlue;
        }

        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }
        public void UpdateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterDelegate(UpdateStatusText), new object[] { Text });
                return;
            }
            label1.ForeColor = Color.AliceBlue;
            label1.Text = Text;
        }
        public void UpdateStatusTextWithStatus(string Text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new StringParameterWithStatusDelegate(UpdateStatusTextWithStatus), new object[] { Text, tom });
                return;
            }
            switch (tom)
            {
                case TypeOfMessage.Error:
                    label1.ForeColor = Color.Red;
                    break;
                case TypeOfMessage.Warning:
                    label1.ForeColor = Color.Yellow;
                    break;
                case TypeOfMessage.Success:
                    label1.ForeColor = Color.AliceBlue;
                    break;
            }
            label1.Text = Text;
        }
        private void SplashForm_FormClosing(object sender,FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
