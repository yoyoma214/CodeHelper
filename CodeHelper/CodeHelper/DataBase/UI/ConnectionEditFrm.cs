using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.Core;

namespace CodeHelper.DataBaseHelper
{
    public partial class ConnectionEditFrm : Form
    {
        internal ConnectionNode Connection
        {
            private set;
            get;
        }

        public ConnectionEditFrm()
        {
            InitializeComponent();
            IList< KeyValuePair<DatabaseType, string>> list = new List< KeyValuePair<DatabaseType, string>>{
            new KeyValuePair<DatabaseType, string>(DatabaseType.SqlServer, "SqlServer"),
            new KeyValuePair<DatabaseType, string>(DatabaseType.Oracle, "Oracle"),
            new KeyValuePair<DatabaseType, string>(DatabaseType.MySql, "MySql"),
            new KeyValuePair<DatabaseType, string>(DatabaseType.Access, "Access"),            
            new KeyValuePair<DatabaseType, string>(DatabaseType.Postgres, "Postgres")};
            this.cmbDbType.ValueMember = "Value";
            this.cmbDbType.SelectedValue = "Key";
            this.cmbDbType.DataSource = list;            
          
            //this.cmbDbType.Items.Add(new KeyValuePair<DataBaseType, string>(DataBaseType.SqlServer, ""));
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {

                DbSchema.DatabaseSchema db = DatabaseSchema.CreateInstance(((KeyValuePair<DatabaseType, string>)this.cmbDbType.SelectedItem).Key);
                db.ConnectionString = this.txtConnectionString.Text.Trim();
                //db.Provider = new DbSchema.DbSchemaProvider.SqlSchemaProvider();
                //var tables = db.Tables;
                if (db.TestConnect())
                {
                    MessageBox.Show("链接成功");
                    return;
                }

                MessageBox.Show("链接失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show("链接失败:" + ex.Message);
            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {            
            if (this.Connection == null)
            {
                this.Connection = new ConnectionNode();    
            }
            this.Connection.Name = this.txtName.Text.Trim();
            this.Connection.ConncetionString = this.txtConnectionString.Text.Trim();
            this.Connection.DbType = ((KeyValuePair<DatabaseType, string>)this.cmbDbType.SelectedItem).Key;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void UpdateConn( ConnectionNode conn )
        {
            this.Connection = conn;
            this.txtConnectionString.Text = conn.ConncetionString;
            this.txtName.Text = conn.Name;
            this.cmbDbType.SelectedValue = conn.DbType.ToString();            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.Connection != null)
            {
                this.txtConnectionString.Text = this.Connection.ConncetionString;
                this.txtName.Text = this.Connection.Name;
            }
            else
            {
                this.txtName.Text = "";
                this.txtConnectionString.Text = "";
            }
        }
    }
}
