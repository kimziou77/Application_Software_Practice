using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
public enum ControlParseCase
{
    None,
    Name,
    Age,
    Gender
}
namespace WinformExample
{
    public partial class ListViewExample : Form
    {
        public ListViewExample()
        {
            InitializeComponent();
        }

        private void ListViewExample_Load(object sender, EventArgs e)
        {
            PeopleListView.View = View.Details;
            PeopleListView.Columns.Add("Name","Name");
            PeopleListView.Columns.Add("Gender", "Gender");
            PeopleListView.Columns.Add("Age", "Age");
            PeopleListView.Columns.Add("Last","Last");

            PeopleListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            PeopleListView.Columns.RemoveByKey("Last");

            //Align
            PeopleListView.Columns[0].TextAlign = HorizontalAlignment.Left;
            PeopleListView.Columns["Age"].TextAlign = HorizontalAlignment.Center;
            PeopleListView.Columns[2].TextAlign = HorizontalAlignment.Left;


        }
        private void ClearControls()
        {
            NameText.Clear();
            AgeText.Clear();
            GenderCombo.SelectedItem = null;
        }
        private ControlParseCase GetControlParseCase()
        {
            if (String.Equals(NameText, string.Empty)) return ControlParseCase.Name;
            else if (string.Equals(AgeText, string.Empty)) return ControlParseCase.Age;
            else if (GenderCombo.SelectedItem == null) return ControlParseCase.Gender;

            return ControlParseCase.None;
        }
        private Dictionary<string, string> GetControlParseDict()
        {
            return new Dictionary<string, string>()
            {
                { "Name", NameText.Text },
                { "Age", AgeText.Text },
                { "Gender", GenderCombo.SelectedItem.ToString() }

            };
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (GetControlParseCase() != ControlParseCase.None) return;

            var PeopleItem = new ListViewItem(new string[PeopleListView.Columns.Count]);
            for(int i = 0; i < PeopleListView.Columns.Count; i++)
                PeopleItem.SubItems[i].Name = PeopleListView.Columns[i].Name;

            var controlParseDict = GetControlParseDict();
            foreach (string item in controlParseDict.Keys)
                PeopleItem.SubItems[item].Text = controlParseDict[item];

            
            PeopleListView.Items.Add(PeopleItem);

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (PeopleListView.FocusedItem == null) return;

            PeopleListView.FocusedItem.Remove();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (GetControlParseCase() != ControlParseCase.None) return;
            var controlParseDict = GetControlParseDict();
            foreach(string item in controlParseDict.Keys)
            {
                var PeopleItem = PeopleListView.FocusedItem;
                PeopleItem.SubItems[item].Text = controlParseDict[item];
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) return;
            e.Handled = true;
        }
    }
}
