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
    public partial class dlgNewPerson : Form
    {
        private string _personName;

        public string PersonName
        {
            get { return _personName; }
            set { _personName = value; }
        }

        private string _personLastname;

        public string PersonLastname
        {
            get { return _personLastname; }
            set { _personLastname = value; }
        }
        
        public dlgNewPerson()
        {
            InitializeComponent();
        }

        private bool CheckFields()
        {
            this.PersonName = this.txtName.Text.Trim();
            this.PersonLastname = this.txtLastname.Text.Trim();

            if ((this.PersonName.CompareTo(string.Empty) == 0)||(this.PersonLastname.CompareTo(string.Empty) == 0))
            {
                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Some fields are empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void dlgNewPerson_Load(object sender, EventArgs e)
        {
            this.txtName.Text = PersonName;
            this.txtLastname.Focus();
        }
    }
}
