using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.DataBaseHelper;
using Project;

namespace CodeHelper.DataBase.UI
{
    public partial class SelectConnectionFrm : Form
    {
        public ConnectionType Connection;

        public SelectConnectionFrm()
        {
            InitializeComponent();
            
            List<string> conns = new List<string>();

            
            foreach (var conn in DBGlobalService.CurrentProject.Connections.OrderBy(x=>x.Name))
            {
                //conns.Add(conn.Name);    
                this.cbConnections.Items.Add(conn);
            }

            this.cbConnections.DisplayMember = "Name";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            this.Connection = this.cbConnections.SelectedItem as ConnectionType;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
