using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Project;
using CodeHelper.Items;
//using Generator.Config;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class SqlPackageNode:BaseNode
    {
        public string ConnectionString { get; set; }
        public SqlPackageNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "查询";
            this.EnableDelete = false;
            this.EnableEdit = false;
            this.EnableRefresh = false;
            this.EnableRename = false;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "133";
        }
        //public SqlPackageNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            menu.MenuItems.Add(0,new MenuItem("新增", this.NewSql_Click));
            return menu;
        }
        void NewSql_Click(object sender, EventArgs args)
        {
            SqlEditFrm frm = new SqlEditFrm();
            frm.ConnectionString = DBGlobalService.ConnectionString;

            frm.Save += new SqlEditFrm.OnSave(frm_Save);
            frm.ShowDialog();

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    SqlNode sqlNode = new SqlNode();
            //    sqlNode.ConnectionString = this.ConnectionString;
            //    sqlNode.DataInfo = frm.GetItem();
            //    sqlNode.Parent = this;
            //}
        }

        void frm_Save(SqlType sql,ref int hashcode)
        {            

            foreach (var child in this.Children)
            {
                if (child.Name == sql.Name)
                {
                    if (hashcode != child.GetHashCode())
                    {
                        MessageBox.Show("名称不能重复");
                        return;
                    }
                }
            }
            if (hashcode == 0)
            {
                SqlNode sqlNode = new SqlNode();
                sqlNode.ConnectionString = this.ConnectionString;
                sqlNode.DataInfo = sql;
                sqlNode.Parent = this;
                hashcode = sqlNode.GetHashCode();
            }
            DBGlobalService.Save();
        }

        public override void Save()
        {            
            //foreach (SqlNode node in this.Children)
            //{
            //    ((Project.ConnectionType)this.Parent.DataInfo).AddSql(
            //        (Project.SqlType)node.DataInfo);                
            //}
            base.Save();
        }

        internal void Reset(List<SqlType> sqlTypes)
        {
            this.Children.Clear();

            var orderSqls = sqlTypes.OrderBy(x => x.Name).ToList();

            foreach (SqlType sqlType in orderSqls)
            {
                SqlNode sqlNode = new SqlNode();
                sqlNode.ConnectionString = this.ConnectionString;
                sqlNode.DataInfo = sqlType;
                sqlNode.Parent = this;
            }
        }

    }
}
