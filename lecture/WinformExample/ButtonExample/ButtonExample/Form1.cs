using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void MessageBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TextNote.SelectedText);
        }

        private void SeletctBtn_Click(object sender, EventArgs e)
        {
            TextNote.SelectAll();
            TextNote.Focus();
        }

        private void RadioDot_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(RadioDot.Text, TextNote.Font.Size, TextNote.Font.Style);
            TextNote.Font = f;
        }

        private void RadioGul_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(RadioGul.Text, TextNote.Font.Size, TextNote.Font.Style);
            TextNote.Font = f;
        }

        private void RadioGung_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(RadioGung.Text, TextNote.Font.Size, TextNote.Font.Style);
            TextNote.Font = f;
        }

        private void CheckBold_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(TextNote.Font.FontFamily, TextNote.Font.Size, FontStyle.Bold ^ TextNote.Font.Style);
            TextNote.Font = f;
        }

        private void CheckLine_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(TextNote.Font.FontFamily, TextNote.Font.Size, FontStyle.Underline ^ TextNote.Font.Style);
            TextNote.Font = f;
        }

        private void CheckItalic_CheckedChanged(object sender, EventArgs e)
        {
            Font f = new Font(TextNote.Font.FontFamily, TextNote.Font.Size, FontStyle.Italic ^ TextNote.Font.Style);
            TextNote.Font = f;
        }
    }
}
