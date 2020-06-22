using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationTest2
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtName.TextLength <= 0 || txtStdNum.TextLength <= 0)
            {
                MessageBox.Show("학번과 이름을 모두 입력하여 주세요");
                return;
            }

            try
            {
                int.Parse(txtKor.Text);
                int.Parse(txtEng.Text);
                int.Parse(txtMath.Text);
                int.Parse(txtSoc.Text);
                int.Parse(txtSci.Text);
                //null이면 -1로 추가하기

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("입력 형식이 잘못되었습니다.");
            }
            this.Close();
        }
    }
}
