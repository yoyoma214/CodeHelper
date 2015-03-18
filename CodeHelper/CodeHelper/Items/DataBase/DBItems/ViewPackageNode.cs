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
    class ViewPackageNode : BaseNode
    {
        public ViewPackageNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "视图";
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

        public void Reset(List<TableType> tableTypes, string connectionString)
        {
            this.Children.Clear();

            //排序            
            var orderTables = tableTypes.OrderBy(x => x.Name).ToList();

            foreach (TableType tableType in orderTables)
            {
                ViewNode tableNode = new ViewNode();
                tableNode.DataInfo = tableType;
                //tableNode.ConncetionString = connectionString;

                tableNode.Parent = this;
            }
        }
    }
}
