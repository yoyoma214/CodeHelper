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
    public partial class EditSqlStatementFrm : Form
    {
        public EditSqlStatementFrm()
        {
            InitializeComponent();
            this.textEditorControl1.Text = "";
        }
        string sql = null;
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sql = this.textEditorControl1.Text.Trim();
        }

        private void btnCancl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetSql(string sql)
        {
            this.sql = sql;
            this.textEditorControl1.Text = sql;
        }
        public string GetSql()
        {
            return sql;
        }
    }
}
