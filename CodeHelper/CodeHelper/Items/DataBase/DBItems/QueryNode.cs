using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.UI;
using System.Windows.Forms;
using System.Drawing;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public class QueryNode : BaseNode
    {
        protected QueryType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<QueryType>();

        public string Settings
        {
            get;
            set;
        }

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.Name = (this.Name) = this.Text;
                this.dataInfo.Queries.RemoveAll();
                this.dataInfo.Sqls.RemoveAll();

                foreach (var q in this.Children)
                {
                    if (q is SqlNode)
                        this.dataInfo.Sqls.AddChild(q.DataInfo);
                    if (q is QueryNode)
                        this.dataInfo.Queries.AddChild(q.DataInfo);
                }
               
                return this.dataInfo;
            }
            set
            {
                this.dataInfo = (QueryType)value;

                foreach (var sql in this.dataInfo.Sqls)
                {
                    var sqlNode = new SqlNode();
                    sqlNode.DataInfo = sql;
                    sqlNode.Parent = this;
                }

                foreach (var q in this.dataInfo.Queries)
                {
                    var queryNode = new QueryNode();
                    queryNode.DataInfo = q;
                    queryNode.Name = queryNode.Text = q.Name;
                    queryNode.Parent = this;
                }
            }
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {         
            ContextMenu menu = base.GetPopMenu();
            //menu.MenuItems.Add("刷新", this.Refresh_Click);   
            
            menu.MenuItems.Add("新增查询", this.NewSql_Click);
            menu.MenuItems.Add("新增查询集", this.NewSqlSet_Click);
            return menu;
        }

        void NewSql_Click(object sender, EventArgs args)
        {
            var frm = new SqlEditFrm();
            frm.ConnectionString = DBGlobalService.ConnectionString;

            frm.Save += new SqlEditFrm.OnSave(frm_Save);
            frm.ShowDialog();

            //this.TreeNode.ForeColor
        }

        void NewSqlSet_Click(object sender, EventArgs args)
        {
            var queryNode = new QueryNode();
            queryNode.Text =queryNode.Name =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
            queryNode.Parent = this;

            //this.dataInfo.Queries.AddChild(queryNode.dataInfo);
        }

        void frm_Save(SqlType sql, ref int hashcode)
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
                sqlNode.ConnectionString = DBGlobalService.ConnectionString;
                sqlNode.DataInfo = sql;
                sqlNode.Parent = this;
                this.dataInfo.Sqls.AddChild(sql);
                hashcode = sqlNode.GetHashCode();
            }
            DBGlobalService.Save();
        }

        public QueryNode()
        {
            this.Text = this.Name = "查询集";
            this.EnableRefresh = false;

            //this.TreeNode.BackColor = Color.Azure;

            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "133";
        }

        internal void Reset()
        {
            if (this.Parent is ConnectionNode)
            {
                this.EnableDelete = false;
                this.EnableRename = false;                
            }
          
        }
    }
}
