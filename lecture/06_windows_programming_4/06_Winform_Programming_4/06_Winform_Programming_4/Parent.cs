using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace _06_Winform_Programming_4
{
    public partial class Parent : Form
    {
        Child child;
        int nChild = 0;
        public Parent()
        {
            InitializeComponent();
        }

        private void 새파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = new Child();
            child.MdiParent = this;
            child.Text = "NoName" + nChild++;
            child.Show();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFDlg.ShowDialog() == DialogResult.OK)
            {
                Stream str = openFDlg.OpenFile();
                StreamReader reader = new StreamReader(str);

                child = new Child();
                child.MdiParent = this;
                child.Text = "NONAME" + nChild++;
                child.Show();

                child.getTextBox().Text = reader.ReadToEnd();
                reader.Close();
                str.Close();
            }
        }

        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (saveFDlg.ShowDialog() == DialogResult.OK)
            {
                child = (Child)(this.ActiveMdiChild);
                string fName = child.Text;
                StreamWriter write = new StreamWriter(fName);
                write.Write(child.getTextBox().Text);
                write.Close();
            }
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFDlg.ShowDialog() == DialogResult.OK)
            {
                child = (Child)(this.ActiveMdiChild);
                string fName = saveFDlg.FileName;
                StreamWriter write = new StreamWriter(fName);
                write.Write(child.getTextBox().Text);
                write.Close();
                child.Text = fName;
            }
        }

        private void 실행취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.getTextBox().Undo();
        }

        private void 오려내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.getTextBox().Cut();

        }

        private void 복사하기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.getTextBox().Copy();
        }

        private void 붙여넣기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.getTextBox().Paste();
        }

        private void 지우기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child = (Child)(this.ActiveMdiChild);
            child.getTextBox().Text="";
        }

        private void 자동줄바꿈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (child.getTextBox().WordWrap)
            {
                child.getTextBox().WordWrap = false;
                자동줄바꿈ToolStripMenuItem.Checked = false;
            }
            else
            {
                if (child.getTextBox().WordWrap)
                {
                    child.getTextBox().WordWrap = true;
                    자동줄바꿈ToolStripMenuItem.Checked = true;
                }
            }
        }

        private void 글꼴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                child.getTextBox().Font = fontDlg.Font;
            }
        }

        private void 글자색바꾸기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                child.getTextBox().ForeColor = colorDlg.Color;
            }

        }

        private void 바탕색바꾸기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                child.getTextBox().BackColor = colorDlg.Color;
            }
        }

        private void 바둑판배열세로ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void 바둑판배열가로ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 계단식배열ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}
