using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Project;
using Microsoft.ApplicationBlocks.Data;
using CodeHelper.DataBaseHelper.DbSchema;
using System.ComponentModel;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class SqlNode:BaseNode
    {               
        private DataTableSetNode _dataTableSet = new DataTableSetNode();
        private ModelSetNode _modelSet = new ModelSetNode();
        public SqlNode()
            : base()
        {
            this._dataTableSet.Parent = this;
            this._modelSet.Parent = this;
            this.EnableRefresh = false;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "274";
        }
        [ReadOnly(true)]
        public string ConnectionString { get; set; }
        public int ModelId { get; set; }
        public string Content
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                return this.dataInfo.SqlStatement;
            }
        }
        ///// <summary>
        ///// 分页内容DataTable名字
        ///// </summary>
        //public string PagerContentDT { get; set; }
        ///// <summary>
        ///// 分页记录总数DataTable名字
        ///// </summary>
        //public string PagerRecordCountDT { get; set; }
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();            
            
            //menu.MenuItems.Add("生成模型", this.CreateMode_Click);
            //menu.MenuItems.Add("生成数据层", this.CreateDAL_Click);
            //menu.MenuItems.Add("生成逻辑层", this.CreateBLL_Click);
            return menu;
        }
        void CreateMode_Click(object sender, EventArgs args)
        {
            this.OnRefresh(sender,args);
        }
        void CreateDAL_Click(object sender, EventArgs args)
        {
            //GenSqlDALBase genDal =GenSqlDALBase.CreateInstance((SqlType)this.DataInfo);
            //StringBuilder builder = new StringBuilder();
            //genDal.Generate(builder);
            //this.OnGenerate(this, builder);
        }
        void CreateBLL_Click(object sender, EventArgs args)
        {
            //GenSqlBLL genBll = new GenSqlBLL((SqlType)this.DataInfo);
            //StringBuilder builder = new StringBuilder();
            //genBll.Generate(builder);
            //this.OnGenerate(this, builder);
        }

        private SqlType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<SqlType>();

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                dataInfo.Name = this.Name;     
                //dataInfo.AddPagerContentTable(this.PagerContentDT??""));
                //dataInfo.AddPagerRecordCountTable(this.PagerRecordCountDT??""));

                //while (this.dataInfo.HasColumnSet())
                //    this.dataInfo.RemoveColumnSet();
                
                //while (this.dataInfo.HasModel())
                //    this.dataInfo.RemoveModel();

                //foreach (ModelNode m in this._modelSet.Children)
                //{
                //    this.dataInfo.AddModel((ModelType)m.DataInfo);
                //}

                //foreach (ColumnSetNode col in this._dataTableSet.Children)
                //{
                //    this.dataInfo.AddColumnSet((ColumnSetType)col.DataInfo);
                //}
                return dataInfo;
            }
            set
            {
                dataInfo = (SqlType)value;
                this.Text= this.Name = dataInfo.Name;
                dataInfo.OnName_ProperyChanged += new CodeHelper.Xml.ProperyChanged<string>(dataInfo_OnName_ProperyChanged);
                //this.PagerContentDT = dataInfo.HasPagerContentTable()? dataInfo.PagerContentTable.Value : "";
                //this.PagerRecordCountDT = dataInfo.HasPagerRecordCountTable()? dataInfo.PagerRecordCountTable.Value:"";

                //foreach (ColumnSetType columnSet in this.dataInfo.MyColumnSets)
                //{
                //    ColumnSetNode columnSetNode = new ColumnSetNode();
                //    columnSetNode.DataInfo = columnSet;
                //    columnSetNode.Parent = this._dataTableSet;
                //}
                //foreach (ModelType model in this.dataInfo.MyModels)
                //{
                //    ModelNode modelNode = new ModelNode();
                //    modelNode.DataInfo = model;
                //    modelNode.Parent = this._modelSet;
                //}
            }
        }

        void dataInfo_OnName_ProperyChanged(string oldValue, string newVal)
        {
            this.Text = this.Name = newVal;
        }

        protected override void OnRefresh(object sender, EventArgs args)
        {
            try
            {
                return;

                this._dataTableSet.Children.Clear();

                DataSet ds =
                    SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, this.Content);
                List<DBModelNode> modelNodeList = new List<DBModelNode>();
                List<ColumnSetNode> columnSetNodeList = new List<ColumnSetNode>();

                #region [构造ColumnSetNode ModelNode]
                foreach (DataTable dataTable in ds.Tables)
                {
                    ColumnSetType columnSet = new ColumnSetType();
                    ColumnSetNode columnSetNode = new ColumnSetNode();
                    columnSetNode.Name = dataTable.TableName;
                    columnSetNodeList.Add(columnSetNode);

                    DBModelNode modelNode = new DBModelNode();
                    modelNode.Name = dataTable.TableName;
                    modelNode.ColumnSetName = dataTable.TableName;
                    modelNodeList.Add(modelNode);

                    foreach (DataColumn dataColumn in dataTable.Columns)
                    {
                        ColumnNode columnNode = NodeFactory.CreateNode<ColumnNode>();// new ColumnNode();
                        columnNode.AllowDBNull = dataColumn.AllowDBNull;
                        columnNode.DbType = SchemaUtility.GetDbType(DBGlobalService.DbType,dataColumn.DataType.Name).ToString();
                        columnNode.Description = "";
                        columnNode.IsPK = false;
                        columnNode.Name = dataColumn.ColumnName;
                        columnNode.Precision = 0;
                        columnNode.Scale = 0;
                        columnNode.Size = 0;
                        columnNode.SystemType = dataColumn.DataType;
                        columnNode.Parent = columnSetNode;

                        FieldNode fieldNode = NodeFactory.CreateNode<FieldNode>();// new FieldNode();
                        fieldNode.Description = "";
                        fieldNode.Name = dataColumn.ColumnName;
                        fieldNode.ColumnName = dataColumn.ColumnName;
                        fieldNode.NullAble = dataColumn.AllowDBNull;
                        fieldNode.SystemType = dataColumn.DataType;
                        fieldNode.Parent = modelNode;
                    }
                    columnSetNode.Parent = this._dataTableSet;
                }
                #endregion

                var hasModel = from n in this._modelSet.Children
                               join m in modelNodeList on
                               ((DBModelNode)n).ColumnSetName equals m.ColumnSetName
                               where n is DBModelNode
                               select n;

                #region 更新存在的模型
                foreach (DBModelNode modelNode in hasModel)
                {
                    var columnSet = from colset in columnSetNodeList
                                    where colset.Name == modelNode.ColumnSetName
                                    select colset;
                    ColumnSetNode csNode = columnSet.First();

                    foreach (BaseNode  node in modelNode.Children)
                    {
                        FieldNode fieldNode = node as FieldNode;
                        if (fieldNode == null)
                            continue;

                        if (string.IsNullOrWhiteSpace(fieldNode.ColumnName))
                            continue;

                        var column = from col in csNode.Children
                                     where col.Name == fieldNode.Name
                                     select col;

                        bool needModify = true;
                        ColumnNode colNode = (ColumnNode)column.FirstOrDefault();
                        if (colNode != null && colNode.Name.Equals(fieldNode.ColumnName)
                            && colNode.SystemType.Equals(fieldNode.SystemType)
                            && colNode.AllowDBNull.Equals(fieldNode.NullAble))
                        {
                            needModify = false;
                        }
                        fieldNode.OnColumnModify(needModify);
                    }
                    //添加不存在的字段
                    DBModelNode newModelNode = modelNodeList.Find((m) => { return m.ColumnSetName.Equals(modelNode.ColumnSetName); });
                    for (int i = 0; i < newModelNode.Children.Count; i++)
                    {
                        if (newModelNode.Children[i] is FieldNode)
                        {
                            FieldNode fNode = (FieldNode)newModelNode.Children[i];
                            var exsitNode = modelNode.Children.FirstOrDefault((n) => 
                                (n is FieldNode) &&
                                n.Name.Equals(fNode.Name)
                                );
                            if (exsitNode == null)
                            {
                                fNode.Parent = null;
                                modelNode.Children.Add(fNode);
                                i--;
                            }
                        }
                    }
                }

                #endregion

                #region 插入不存在的模型
                var hasModelNameList = from n in hasModel
                                       select ((DBModelNode)n).ColumnSetName;

                foreach (DBModelNode m in modelNodeList)
                {
                    if (!hasModelNameList.Contains(m.ColumnSetName))
                    {
                        m.Parent = this._modelSet;
                    }
                }

                #endregion
                base.OnRefresh(sender, args);
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message);
            }
        }

        public override void Save()
        {
            base.Save();
        }

        protected override BaseNode OnReslove(Type nodeType, string name)
        {
            foreach (ColumnSetNode node in this._dataTableSet.Children)
            {
                if (node.GetType().Equals(nodeType) && node.Name.Equals(name))
                {
                    return node;
                }
            }
            foreach (DBModelNode node in this._modelSet.Children)
            {
                if (node.GetType().Equals(nodeType) && node.Name.Equals(name))
                {
                    return node;
                }
            }
            return null;
        }
        protected override void OnEdit(object sender, EventArgs args)
        {
            SqlEditFrm frm = new SqlEditFrm(this.GetHashCode());
            frm.Save += new SqlEditFrm.OnSave(frm_Save);
            frm.UpdateItem(this.dataInfo,this.ConnectionString);
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //if ( this.dataInfo.HasPagerContentTable ())
                //    this.PagerContentDT = this.dataInfo.PagerContentTable.Value;
                //if ( this.dataInfo.HasPagerRecordCountTable())
                //    this.PagerRecordCountDT = this.dataInfo.PagerRecordCountTable.Value;
            }
            base.OnEdit(sender, args);
        }

        void frm_Save(SqlType sql,ref int hashcode)
        {
            //hashcode = this.GetHashCode();

            //比较名称是否重复
            foreach (var n in this.Parent.Children)
            {
                if (n.Name == sql.Name)
                {
                    if (hashcode != this.GetHashCode())
                    {
                        MessageBox.Show("名称不能重复");
                        return;
                    }
                }
            }

            DBGlobalService.Save();
        }
    }
}
