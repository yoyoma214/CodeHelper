using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using System.Windows.Forms;
using CodeHelper.DataBaseHelper.Extensions;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public class ColumnSetNode:BaseNode
    {
        public ColumnSetNode()
            : base()
        {
            //this.Text = this.Name = "列";          
        }

        public ColumnSetNode(ColumnSchema[] columns = null)
        {
            this.columns = columns; 
        }
        
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                this.OnUpdate();
            }
        }
        private ColumnSchema[] columns;
        public ColumnSchema[] Columns
        {
            get
            {
                var list = new List<ColumnSchema>();
                foreach (var node in this.Children)
                {
                    var colNode = node as ColumnNode;
                    var column = new ColumnSchema();
                    column.IsPK = colNode.IsPK;
                    column.Name = colNode.Name;
                    column.NativeType = colNode.DbType;
                    column.Precision = colNode.Precision;
                    column.Scale = colNode.Scale;
                    column.Size = colNode.Size;
                    column.DataType = colNode.SystemType.Name;
                    column.SystemType = colNode.SystemType;
                    column.AllowDBNull = colNode.AllowDBNull;
                    list.Add(column);
                }

                return list.ToList().OrderByName().ToArray();                
            }
            set
            {

                columns = value;

                if (value == null)
                {
                    this.Children.Clear();
                }
                else
                {
                    var hasNodes = from n in this.Children 
                           join col in value
                           on n.Name equals col.Name
                           select n;                              
                    
                    //移除不存在的列
                    for (int i = 0; i < this.Children.Count; i++)
                    {
                        if (!hasNodes.Contains(this.Children[i]))
                        {
                            this.Children.RemoveAt(i);
                            i--;
                        }
                    }
                    //更新存在的列
                    foreach (ColumnNode columnNode in hasNodes)
                    {
                        //value.SingleOrDefault(col => col.Name.Equals(columnNode.Name));
                        columnNode.Column = value.SingleOrDefault(col => col.Name.Equals(columnNode.Name));
                    }
                    //获得已存在的列名集合
                    var hasColumns = from col in value
                            join n in hasNodes on col.Name equals n.Name                                                     
                            select col.Name;
                    //添加不存在的列
                    foreach (ColumnSchema column in value)
                    {
                        if (!hasColumns.Contains(column.Name))
                       {
                           ColumnNode columnNode = NodeFactory.CreateNode<ColumnNode>();// new ColumnNode();
                            columnNode.Column = column;
                            columnNode.Parent = this;
                        }
                    }
                }
            }
        }

        private ColumnSetType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<ColumnSetType>();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                dataInfo.Name = this.Name;
                //while (this.dataInfo.HasColumn())
                //    this.dataInfo.RemoveColumn();
                this.dataInfo.Columns.RemoveAll();

                foreach (ColumnNode column in this.Children)
                {
                    dataInfo.Columns.AddChild((ColumnType)column.DataInfo);
                }
                return dataInfo;
            }
            set
            {
          
                this.Children.Clear();
                this.dataInfo =(ColumnSetType) value;
                this.Text = this.Name = this.dataInfo.Name;
                if (this.Name == "Staff_Position")
                {
                }
                foreach (ColumnType columnType in this.dataInfo.Columns)
                {
                    ColumnNode columnNode = NodeFactory.CreateNode<ColumnNode>();// new ColumnNode();
                    columnNode.DataInfo = columnType;
                    columnNode.Parent = this;
                }
            }
        }

        public override void Save()
        {
            //while (this.dataInfo.HasColumn())
            //    this.dataInfo.RemoveColumn();

            //foreach (ColumnNode column in this.Children)
            //{
            //    dataInfo.AddColumn((ColumnType)column.DataInfo);
            //}
            base.Save();
        }
        protected override void OnUpdate()
        {
            this.Text = "列集:" + this.Name;
            base.OnUpdate();
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            this.Children.Clear();
            //base.OnDelete(sender, args);
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            foreach (MenuItem m in menu.MenuItems)
            {
                if (m.Text.Equals("删除"))
                    m.Text = "删除所有列";
            }
            return menu;
        }
    }
}
