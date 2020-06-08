using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Csharp
{
    
    public partial class Form1 : Form
    {
        DataSet1 dataset;
        public Form1()
        {
            InitializeComponent();
            dataset = new DataSet1();
            dataset.Tables["Person"].Rows.Add(new object[] { 1, "Kim", 30 });
            dataset.Tables["Person"].Rows.Add(new object[] { 2, "Kong", 35 });
            dataset.Tables["Person"].Rows.Add(new object[] { 3, "Park", 20 });
            dataset.Tables["Person"].Rows.Add(new object[] { 4, "Lee", 22 });
            dataGridView1.DataSource = dataset.Tables["Person"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataset.Tables["Person"].Rows.Add(new object[] {
                dataset.Tables["Person"].Rows.Count+1,
                txtName.Text, Convert.ToInt32(txtAge.Text)
            });
        }
    }
}
