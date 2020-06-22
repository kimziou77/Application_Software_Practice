using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationTest
{
    public partial class inputForm : Form
    {
        static int idxNum = 1;
        public inputForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MainForm mainForm = (MainForm)Owner;

            if (txtName.TextLength <= 0||txtStdNum.TextLength<=0)
            {
                MessageBox.Show("학번과 이름을 모두 입력하여 주세요");
                return;
            }
            TextBox[] textboxs = { txtKor, txtEng, txtMath, txtSoc, txtSci };

            try
            {
                foreach(TextBox tb in textboxs)
                {
                    if (tb.Text.Length <= 0)
                    {//null이면 -1로 추가하기
                        tb.Text = "-1";
                        continue;
                    }

                    int a = int.Parse(tb.Text);
                    if (a < 0)
                    {
                        throw new Exception();
                    }
                }

            }catch(Exception ex)
            {
                MessageBox.Show("입력 형식이 잘못되었습니다. 재 기입해주세요");
                return;
            }

            ListViewItem item = new ListViewItem(idxNum.ToString());    idxNum++;
            item.SubItems.Add(txtName.Text.ToString());
            item.SubItems.Add(txtStdNum.Text.ToString());
            foreach(TextBox tb in textboxs)
                item.SubItems.Add(tb.Text);

            mainForm.listview.Items.Add(item);

            this.Close();
        }

    }
}
