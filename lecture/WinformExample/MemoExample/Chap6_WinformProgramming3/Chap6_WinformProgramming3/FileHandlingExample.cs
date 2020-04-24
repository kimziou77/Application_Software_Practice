using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chap6_WinformProgramming3
{
    public partial class FileHandlingExample : Form
    {
        List<string[]> awsList = new List<string[]>();
        public FileHandlingExample()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
            InitializeDateTimePicker();
        }
        private void InitializeOpenFileDialog()
        {
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "CSV (*.csv)|*.csv|" + "All files (*.*)|*.*";
            ofd.FileName = "";
        }
        private void InitializeDateTimePicker()
        {
            dtpDate.Value = DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM") + "-01", "yyyy-MM-dd", null);
            dtpTime.Value = DateTime.ParseExact("00:00:00", "HH:mm:ss", null);
        }
        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                awsList = readCSV(ofd.FileName);
            }
        }
        private List<string[]> readCSV(string path)
        {
            StreamReader sr = new StreamReader(path);
            var csvList = new List<string[]>();
            try
            {
                Text = Path.GetFileName(path);
                string line;
                while ((line = sr.ReadLine()) != null)
                    csvList.Add(line.Split(','));
            }
            catch (Exception ex)
            {
                Text = "";
                MessageBox.Show(ex.Message, "File Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sr.Close();
            }
            return csvList;
        }
        private DateTime GetDate()
        {
            string yyyyMMdd = dtpDate.Value.ToString("yyyy-MM-dd");
            string HHmm = dtpTime.Value.ToString("HH:mm");
            return DateTime.ParseExact(yyyyMMdd + ' ' + HHmm, "yyyy-MM-dd HH:mm", null);
        }
        private string GetTemperature()
        {
            string curDateString = GetDate().ToString("yyyy-MM-dd HH:mm");
            
            for(int row =0; row < awsList.Count; row++)
            {
                if(string.Equals(awsList[row][1], curDateString))
                {
                    return awsList[row][2];
                }
            }
            return string.Empty;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (ofd.FileName == string.Empty)
            {
                MessageBox.Show("입력된 파일이 없습니다.");
                return;
            }
            string Temperaturestring = GetTemperature();
            if (string.Equals(Temperaturestring, string.Empty))
                MessageBox.Show(string.Format("{0}에는 자료가 없습니다.", GetDate()));
            else
                MessageBox.Show(string.Format("{0}에는 {1}도 입니다.", GetDate(),Temperaturestring));

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ofd.FileName == string.Empty)
            {
                MessageBox.Show("입력된 파일이 없습니다.");
                return;
            }
            string FileName = Path.GetFileName(ofd.FileName);
            StreamWriter sw = new StreamWriter(FileName, true);
            sw.WriteLine(GetDate().ToString("yyyy-MM-dd HH:mm"+"," + GetTemperature()));
            sw.Close();
        }
    }
}
