using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationTest3
{
    public partial class Lottto : Form
    {
        Random random = new Random();
        static int roundNum = 1;
        public Lottto()
        {
            InitializeComponent();
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            //i회차
            List<int> numbers = createRandomNum();
            changeLabel(numbers);
            ListViewItem item= new ListViewItem(roundNum.ToString() + "회차");
            for(int i = 0; i < 6; i++)
            {
                item.SubItems.Add(numbers[i].ToString());
            }
            listView1.Items.Add(item);
            roundNum++;
        }


        List<int> createRandomNum()
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int r = random.Next(1, 46);
                numbers.Add(r);
            }
            numbers = numbers.Distinct().ToList();
            if (numbers.Count < 6)
                return createRandomNum();

            List<int> sortedNum= new List<int>();
            for(int i = 0; i < 6; i++)
            {
                sortedNum.Add(numbers[i]);
            }
            sortedNum.Sort();
            return sortedNum;
        }
        void changeLabel(List<int> numbers)
        {
            label1.Text = numbers[0].ToString();
            label2.Text = numbers[1].ToString();
            label3.Text = numbers[2].ToString();
            label4.Text = numbers[3].ToString();
            label5.Text = numbers[4].ToString();
            label6.Text = numbers[5].ToString();
        }
    }
}
