using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RealTimeItemSelector
{
    public partial class Form1 : Form
    {
        private List<People> _peopleList;
        private BindingList<People> _finalList;

        public List<People> PeopleList
        {
            get { return _peopleList; }
            set { _peopleList = value; }
        }

        public BindingList<People> FinalList
        {
            get { return _finalList; }
            set { _finalList = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtName.Text = string.Empty;
            this.lbIntellilist.Items.Clear();

            PeopleList = PeopleHelper.CreatePeople();
            FinalList = new BindingList<People>();

            this.lbIntellilist.DataSource = PeopleList;

            this.lbFinalList.DataSource = FinalList;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string input = this.txtName.Text.Trim().ToLower();

            List<People> tempList = (from p in _peopleList
                                    where p.Fullname.ToLower().Contains(input)
                                    select p).ToList<People>();
            this.lbIntellilist.DataSource = tempList;
        }

        private void lbResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (this.lbIntellilist.SelectedItem is People)
                {
                    this.FinalList.Add((People)this.lbIntellilist.SelectedItem);
                }

                this.txtName.Text = string.Empty;
                this.txtName.Focus();
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) && (this.txtName.Text.Trim().CompareTo(string.Empty) != 0))
            {
                dlgNewPerson dialog = new dlgNewPerson();
                dialog.PersonName = this.txtName.Text.Trim();

                dialog.ShowDialog();

                if (dialog.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    People person = new People();
                    person.Id = PeopleList.Max(p => p.Id) + 1;
                    person.Name = dialog.PersonName;
                    person.Lastname = dialog.PersonLastname;

                    PeopleList.Add(person);
                    FinalList.Add(person);

                    this.txtName.Text = string.Empty;
                }
            }
        }
    }
}
