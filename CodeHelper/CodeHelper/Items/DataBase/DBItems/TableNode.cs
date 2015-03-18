using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CodeHelper.DataBaseHelper.GenerateUnit.GenModel;
using CodeHelper.DataBaseHelper.DbSchema;
using Project;
//using Generator.GenerateUnit.GenDAL;
//using Generator.GenerateUnit.GenBLL;
using CodeHelper.DataBaseHelper.GenerateUnit;
using CodeHelper.Items;
//using Generator.GenerateUnit.GenDAL.SqlServer;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class TableNode : BaseNode
    {
        private ColumnSetNode _columnSetNode = new ColumnSetNode();        
        private DBModelNode _modelNode = new DBModelNode();
        private TableSchema _Table = null;
        //public string ConncetionString { get; set; }
        //public DatabaseType DbType { get; set; }
        public ColumnSetNode GetColumnSetNode()
        {
            return this._columnSetNode;
        }
        public DBModelNode GetModelNode()
        {
            return this._modelNode;
        }
        internal TableSchema Table
        {
            get { return this._Table; }
            set
            {
                this._Table = value;
                this._columnSetNode.Name = value.Name;
                this._columnSetNode.Columns = Table.Columns.ToArray();
            }
        }
        public TableNode()
            : base()
        {
            this._columnSetNode.Parent = this;
            this._modelNode.Parent = this;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "274";
        }
        //public TableNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}

        //public int ModelId { get; set; }
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            menu.MenuItems.Add("生成模型", this.CreateMode_Click);
            //menu.MenuItems.Add("生成数据层代码", this.CreateDAL_Click);
            //menu.MenuItems.Add("生成逻辑层代码", this.CreateBLL_Click);
            //menu.MenuItems.Add("生成批量导出sql", this.CreatePatchExportSql_Click);
            //menu.MenuItems.Add("生成测试数据sql", this.CreateDataSql_Click);
            //menu.MenuItems.Add("生成NHibernate", new MenuItem[]{
            //    new MenuItem("生成XML",this.CreateNHibernate_XML_Click),
            //    new MenuItem("生成Model",this.CreateNHibernate_Model_Click),
            //    new MenuItem("生成Model(get;set)",this.CreateNHibernate_ModelSimple_Click),
            //    new MenuItem("生成DAL",this.CreateNHibernate_DAL_Click),         
            //});
            return menu;
        }
        void CreateMode_Click(object sender, EventArgs args)
        {          
            this.OnRefresh(sender, args);            
        }
        void CreateDAL_Click(object sender, EventArgs args)
        {
            if (this._modelNode.Children.Count < 2)
            {
                MessageBox.Show("请先生成模型");
                return;
            }
            //GenTableDALBase gen =GenTableDALBase.CreateInstance((TableType)this.DataInfo, GlobalService.ConnectionString);

            StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            this.OnGenerate(this, builder);            
        }
        void CreateBLL_Click(object sender, EventArgs args)
        {
            //if (this._modelNode.Children.Count < 2)
            //{
            //    MessageBox.Show("请先生成模型");
            //    return;
            //}
            //GenBLL gen = new GenBLL((TableType)this.DataInfo);
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);            
        }
        void CreatePatchExportSql_Click(object sender, EventArgs args)
        {
            //System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
            //w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteRaw(this.DataInfo.DomNode.OuterXml);
            //w.Flush();
            //w.Close();
            //BaseXSLTGen gen = new BaseXSLTGen(@"Xsl/PatchExportSql.xslt", "1.xml");
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);
        }
        private void CreateDataSql_Click(object sender, EventArgs args)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0 ; i < 100 ; i ++ )
            {
                builder.Append("INSERT INTO " + this.Name + "(");
                foreach (ColumnType col in this.dataInfo.ColumnSet.Columns)
                {
                    if (col.IsPK)
                        continue;
                    builder.Append(col.Name + ",");
                }
                builder.Remove(builder.Length - 1, 1);
                builder.Append(")Values(");
                foreach (ColumnType col in this.dataInfo.ColumnSet.Columns)
                {
                    if (col.IsPK)
                        continue;
                    switch (col.SystemType)
                    {
                        case "String":
                            builder.Append("'" +col.Name + i + "',");
                            break;
                        case "Int32":
                        case "Int64":
                            builder.Append("1,");
                            break;
                        case "DateTime":
                            builder.Append("'" +DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss") + "',");
                            string s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
                            break;
                        case "Boolean":
                            builder.Append((i % 2 == 0 ? "1" : "0") + ",");
                            break;
                        default:
                            builder.Append("未知数据类型" + ",");
                            break;
                    }                    
                }
                builder.Remove(builder.Length - 1, 1);
                builder.AppendLine(");");
            }
            this.OnGenerate(this, builder);
        }
        private void CreateNHibernate_XML_Click(object sender, EventArgs args)
        {
            var builder = new StringBuilder();
            builder.Append(GeneratorUtil.TabString(0) + "<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(0) + "<hibernate-mapping xmlns=\"urn:nhibernate-mapping-2.2\" namespace=\"\" assembly=\"\" default-lazy=\"true\">");
            builder.AppendFormat(GeneratorUtil.TabString(1) + "<class name=\"{0}\" table=\"{0}\" dynamic-update=\"true\">", this.Name);
            builder.AppendLine();

            ColumnSchema idCol = null;
            var columns = this._columnSetNode.Columns;
            foreach (var col in columns)
            {
                if(col.IsPK)
                {
                    idCol = col;
                    break;
                }
            }
            
            if ( idCol != null )
            {
                if (idCol.Size == 0)
                {
                    builder.AppendFormat(GeneratorUtil.TabString(2) + "<id name=\"{0}\" column=\"{0}\" type=\"{1}\" unsaved-value=\"0\">"
                    , GetStandardName(idCol.Name), idCol.SystemType.ToString());
                }
                else
                {
                    builder.AppendFormat(GeneratorUtil.TabString(2) + "<id name=\"{0}\" column=\"{0}\" not-null=\"true\" type=\"{1}\" length=\"{2}\" unsaved-value=\"0\">"
                        , GetStandardName(idCol.Name), idCol.SystemType.ToString(), idCol.Size == -1 ? int.MaxValue : idCol.Size);
                }
                builder.AppendLine();
                bool ident = false;
                foreach (var exp in idCol.Expands)
                {
                    if (exp.Key.ToString().ToLower() == "isident" && exp.Value.ToString().ToLower() == "true")
                    {
                        ident = true;
                        break;
                    }
                }
                builder.AppendFormat(GeneratorUtil.TabString(3) + "<generator class=\"{0}\" />", ident ? "native" : "assigned");                
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(2) + "</id>");
            }
            foreach (var col in columns)
            {
                if (!col.IsPK)
                {
                    if (col.Size == 0)
                    {
                        builder.AppendFormat(GeneratorUtil.TabString(2) + "<property name=\"{0}\" column=\"{0}\"  type=\"{1}\" />"
                            , GetStandardName(col.Name), col.SystemType.ToString());
                    }
                    else
                    {
                        builder.AppendFormat(GeneratorUtil.TabString(2) + "<property name=\"{0}\" column=\"{0}\" type=\"{1}\" length=\"{2}\" />"
                            , GetStandardName(col.Name), col.SystemType.ToString(), col.Size == -1 ? int.MaxValue : col.Size);
                    }
                    builder.AppendLine();
                }
            }
            builder.AppendLine(GeneratorUtil.TabString(1) + "</class>");
            builder.AppendLine(GeneratorUtil.TabString(0) + "</hibernate-mapping>");
            this.OnGenerate(this, builder);
        }
        private bool AllowDBNull(ColumnSchema col)
        {
            if ( !col.AllowDBNull )
                return false;

            var type = col.SystemType;
            if (type.IsValueType && !type.Name.EndsWith("String"))
            {
                return true;
            }

            return false;
        }

        private string GetStandardName(string name)
        {
            return name.ToUpper()[0] + name.Substring(1);
        }

        private void CreateNHibernate_Model_Click(object sender, EventArgs args)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(GeneratorUtil.TabString(0) + "public class {0}", GetStandardName(this.Name));
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(0) + "{");
            foreach (var col in this._columnSetNode.Columns)
            {
                builder.AppendFormat(GeneratorUtil.TabString(1) + "private {0}{1} _{2};", col.SystemType, AllowDBNull(col) ? "?" : "", GetStandardName(col.Name));
                builder.AppendLine();
            }
            builder.AppendLine();
            foreach (var col in this._columnSetNode.Columns)
            {
                builder.AppendFormat(GeneratorUtil.TabString(1) + "public virtual {0}{1} {2}", col.SystemType, AllowDBNull(col) ? "?" : "", GetStandardName(col.Name));
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(1) + "{");
                builder.AppendFormat(GeneratorUtil.TabString(2) + "get");
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(2) + "{");
                builder.AppendFormat(GeneratorUtil.TabString(3) + "return _{0};",GetStandardName(col.Name));
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(2) + "}");
                builder.AppendLine(GeneratorUtil.TabString(2) + "set");
                builder.AppendLine(GeneratorUtil.TabString(2) + "{");
                builder.AppendFormat(GeneratorUtil.TabString(3) + "_{0}=value;", GetStandardName(col.Name));
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(2) + "}");  
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(1) + "}");    
            }
            builder.AppendLine(GeneratorUtil.TabString(0) + "}");
            this.OnGenerate(this, builder);
        }

        private void CreateNHibernate_ModelSimple_Click(object sender, EventArgs args)
        {
            var builder = new StringBuilder();
            builder.AppendFormat(GeneratorUtil.TabString(0) + "public class {0}", GetStandardName(this.Name));
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(0) + "{");
            builder.AppendLine();
            foreach (var col in this._columnSetNode.Columns)
            {
                builder.AppendFormat(GeneratorUtil.TabString(1) + "public virtual {0}{1} {2}", col.SystemType, AllowDBNull(col) ? "?" : "", GetStandardName(col.Name));
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(1) + "{");
                builder.AppendFormat(GeneratorUtil.TabString(2) + "get;set;");
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(1) + "}");
            }
            builder.AppendLine(GeneratorUtil.TabString(0) + "}");
            this.OnGenerate(this, builder);
        }

        private void CreateNHibernate_DAL_Click(object sender, EventArgs args)
        {

        }

        private TableType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<TableType>();

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                dataInfo.Name = this.Name;
                while (this.dataInfo.ColumnSet != null )
                    this.dataInfo.ColumnSet.RemoveSelf();
                while (this.dataInfo.Model != null)
                    this.dataInfo.Model.RemoveSelf();

                foreach (BaseNode node in this.Children)
                {
                    if (node is ColumnSetNode)
                    {
                        //this.dataInfo.ColumnSet = this.dataInfo.CreateColumnSetType();
                        this.dataInfo.ColumnSet = (ColumnSetType)node.DataInfo;
                    }
                    else if (node is DBModelNode)
                    {
                        this.dataInfo.Model = (ModelType)node.DataInfo;
                    }
                }
                return dataInfo;
            }
            set
            {
                dataInfo = (TableType)value;
                this.Name = dataInfo.Name;
                if (this.Name == "Template")
                {

                }
                this._columnSetNode.DataInfo = dataInfo.ColumnSet;
                this._modelNode.DataInfo = dataInfo.Model;
            }
        }

        public override void Save()
        {
            if (this.Name == "Seat_Seat")
            {
            }
            base.Save();
        }
        protected override void OnRefresh(object sender, EventArgs args)
        {
            this.TreeNode.TreeView.BeginUpdate();

            //获取最新的表
            try
            {
                DbSchema.DatabaseSchema db = DatabaseSchema.CreateInstance(DBGlobalService.DbType);
                db.ConnectionString = DBGlobalService.ConnectionString;
                //db.Provider = new DbSchema.DbSchemaProvider.SqlSchemaProvider();
                var temp = db.GetTable(this.Name);
                if (temp == null)
                    throw new Exception("数据库不存在该表:" + this.Name);

                this.Table = db.GetTable(this.Name);                

                this._modelNode.ColumnSetName = this.Table.Name;

                if ( string.IsNullOrWhiteSpace(_modelNode.Name))
                {
                    this._modelNode.Name = this.Table.Name;
                }

                this._modelNode.Children.Clear();

                foreach (ColumnSchema column in this.Table.Columns)
                {
                    //如果没有该列对应字段，则添加
                    var exsitedNode = from n in this._modelNode.Children
                                      where (n is FieldNode) && ((FieldNode)n).ColumnName == column.Name
                                      select n;
                    if (exsitedNode.Count() == 0)
                    {
                        FieldNode fNode = NodeFactory.CreateNode<FieldNode>();// new FieldNode();
                        fNode.Assign(column);
                        fNode.Parent = this._modelNode;
                    }
                    else
                    {
                        ((FieldNode)exsitedNode.ElementAt(0)).Assign(column);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("失败:" + ex.Message);
            }
            base.OnRefresh(sender, args);
            this.TreeNode.TreeView.EndUpdate();
        }
        protected override BaseNode OnReslove(Type nodeType, string name)
        {
            foreach (BaseNode node in this.Children)
            {
               if ( node.GetType().Equals(nodeType) && node.Name.Equals(name))
                   return node;
            }
            return base.OnReslove(nodeType, name);
        }
        protected override void OnDeleteChild(BaseNode child)
        {
            if (child is DBModelNode)
            {

            }
            base.OnDeleteChild(child);
        }
        
    }
}
