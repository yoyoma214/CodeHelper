using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using CodeHelper.Items;
using CodeHelper.Core.Services;
//using Generator.Config;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class ConnectionPackageNode : BaseNode
    {
        public ConnectionPackageNode()
            : base()
        {
            this.TreeNode.Text = this.TreeNode.Name = "连接串";
            this.EnableDelete = false;
            this.EnableEdit = false;
            this.EnableRefresh = false;
            this.EnableRename = false;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "039";
        }
        //public ConnectionPackageNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("新增连接", this.NewConnection_Click);            
            return menu;
        }
        void NewConnection_Click(object sender, EventArgs args)
        {
            ConnectionNode child = new ConnectionNode();
            
            child.Text=child.Name = Guid.NewGuid().ToString();
            child.DataInfo =  DBGlobalService.CurrentProject.CreateConnectionType();
            ConnectionEditFrm frm = new ConnectionEditFrm();
            frm.UpdateConn(child);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                child.Text = child.Name;                
                child.Parent = this;                
                this.OnRefresh(sender, args);
            }            
        }
        public override void Save()
        {
            //while (GlobalService.CurrentProject.HasConnection())
            //{
            //    GlobalService.CurrentProject.RemoveConnection();
            //}

            //foreach (ConnectionNode connNode in this.Children)
            //{
            //    GlobalService.CurrentProject.AddConnection(
            //        (Project.ConnectionType)connNode.DataInfo);
            //}

            base.Save();
        }
        public void Reset(System.Collections.IEnumerable connectionTypes)
        {
            this.Children.Clear();

            foreach (ConnectionType connType in connectionTypes)
            {
                ConnectionNode connNode = new ConnectionNode();
                connNode.DataInfo = connType;
                connNode.Parent = this;
                
                GlobalService.ModelManager.RegistDb(connType);

            }
        }
    }
}
