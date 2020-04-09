using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace MoveExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LeftBtn_Click(object sender, EventArgs e)
        {
            //Image[] images= new Image[4];
            //images.Append(Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front1.png"));
            //images.Append(Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front2.png"));
            //images.Append(Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front3.png"));
            //images.Append(Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front4.png"));
            //for(int i = 0; i < images.Length; i++)
            //{
            //    pictureBox1.Image = images[i];
            //    Thread.Sleep(50);
            //}

            Bitmap bit=new Bitmap("../img/movementBear.gif");
            ImageAnimator.Animate(bit, new EventHandler(this.OnFrameChanged));
            

            Graphics g=pictureBox1.CreateGraphics();
            g.DrawImage(bit,new Point(0,0));

        }

        private void RightBtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("C:\\Users\\souvenir\\Desktop\\sprite\\Front2.png");

        }
        private void OnFrameChanged(object sender, EventArgs e)
        {

            this.Invalidate();

        }
    }
    //Bitmap bit;

    //protected override void OnLoad(EventArgs e)
    //{

    //    bit = new Bitmap("../../img/ogu.gif");

    //    ImageAnimator.Animate(bit, new EventHandler(this.OnFrameChanged));

    //    base.OnLoad(e);

    //}

    //protected override void OnPaint(PaintEventArgs e)
    //{

    //    ImageAnimator.UpdateFrames();

    //    Graphics g = pictureBox1.CreateGraphics();

    //    g.DrawImage(this.bit, new Point(0, 0));

    //    base.OnPaint(e);

    //}

    //private void OnFrameChanged(object sender, EventArgs e)
    //{

    //    this.Invalidate();

    //}
}
