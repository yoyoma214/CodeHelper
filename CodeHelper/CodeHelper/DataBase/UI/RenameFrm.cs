using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeHelper.DataBaseHelper
{
    public partial class RenameFrm : Form
    {
        public RenameFrm()
        {
            InitializeComponent();
            this.txtCurrentName.ReadOnly = true;
        }
        private string _currentName = "";
        public string CurrentName
        {
            get { return this._currentName; }
            set
            {
                this._currentName = value;
                this.txtCurrentName.Text = value;
            }
        }
        public string NewName
        {
            get;
            set;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            if (string.IsNullOrWhiteSpace(this.txtNewName.Text))
            {
                MessageBox.Show("新名字不能为空");
                return;
            }

            this.NewName = this.txtNewName.Text.Trim();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
