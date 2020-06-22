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
    public partial class ViewForm : Form
    {
        int colCount = 0;
        public ListView lv;
        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            string[] subject = { "국어", "영어" , "수학" , "사회" , "과학"};

            MainForm mainform = (MainForm)Owner;
            listView1.Columns.Add("index");
            listView1.Columns.Add("이름");
            listView1.Columns.Add("학번");

            for(int i = 0; i < 5; i++)
            {
                if (mainform.cb[i])//체크되어있다면
                {
                    listView1.Columns.Add(subject[i]);
                    colCount++;
                }
            }
            listView1.Columns.Add("평균");


            listView1 = mainform.listview;


            //mainform.listview;
        }
    }
    class Student
    {
        public string name;
        public string stdNum;
        public int []scores;
        public Student(string name, string stdNum,int a,int b,int c,int d,int e)
        {
            this.name = name;
            this.stdNum = stdNum;

        }
    }
}
