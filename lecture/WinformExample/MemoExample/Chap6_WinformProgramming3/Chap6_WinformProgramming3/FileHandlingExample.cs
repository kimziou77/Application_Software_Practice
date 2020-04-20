using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }
    }
}
