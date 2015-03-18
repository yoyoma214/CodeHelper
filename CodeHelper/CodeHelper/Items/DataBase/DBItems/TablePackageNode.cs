using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Generator.Config;
using System.Windows.Forms;
using Project;
using System.Collections;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class TablePackageNode : BaseNode
    {
        public TablePackageNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "表";
            this.EnableDelete = false;
            this.EnableEdit = false;
            this.EnableRefresh = false;
            this.EnableRename = false;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "133";
        }
        //public TablePackageNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}
        public override void Save()
        {                                                
            //foreach (TableNode node in this.Children)
            //{
            //    Project.TableType table = (Project.TableType)node.DataInfo;
            //    ConnectionType connectionType = this.Parent.DataInfo as ConnectionType;                
            //    connectionType.AddTable(table);
            //}
            base.Save();
        }
        public void Reset(IEnumerable tableTypes, string connectionString)
        {
            this.Children.Clear();
            foreach (TableType tableType in tableTypes)
            {
                TableNode tableNode = new TableNode();
                tableNode.DataInfo = tableType;
                //tableNode.ConncetionString = connectionString;

                tableNode.Parent = this;
            }
        }

        public void ResetViews(IEnumerable tableTypes, string connectionString)
        {
            this.Children.Clear();
            foreach (TableType tableType in tableTypes)
            {
                ViewNode tableNode = new ViewNode();
                tableNode.DataInfo = tableType;
                //tableNode.ConncetionString = connectionString;

                tableNode.Parent = this;
            }
        }
    }
}
