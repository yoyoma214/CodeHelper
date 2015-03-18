using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Generator.Config;
using System.Data;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.EF.StorageModels;
using CodeHelper.DataBaseHelper.EF;
using CodeHelper.Core;
using CodeHelper.Core.DbConfig;
using CodeHelper.Items;
using CodeHelper.DataBase.UI;
using CodeHelper.DataBaseHelper.Common;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class ConnectionNode : BaseNode
    {
        private TablePackageNode _tablePkgNode = new TablePackageNode();
        private ViewPackageNode _viewPackageNode = new ViewPackageNode();
        private SqlPackageNode _sqlPkgNode = new SqlPackageNode();
        private TableRepositoryNode _tableRepositoryNode = new TableRepositoryNode();
        private TableMappingNode _tableMappingNode = new TableMappingNode();
        private TableStatusNode _tableStatusNode = new TableStatusNode();
        private QueryNode _queryNode = new QueryNode();

        public ConnectionNode()
            : base()
        {
            this.TreeNode.Text = this.TreeNode.Name = "";
            this._tablePkgNode.Parent = this;
            this._viewPackageNode.Parent = this;
            this._sqlPkgNode.Parent = this;
            this._queryNode.Parent = this;
            this._tableRepositoryNode.Parent = this;
            this._tableMappingNode.Parent = this;
            this._tableStatusNode.Parent = this;

            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "190";
        }
        //public ConnectionNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}
        string _conncetionString = null;
        public string ConncetionString
        {
            get
            {
                return this._conncetionString;
            }
            set
            {
                this._conncetionString = value;
                this._sqlPkgNode.ConnectionString = value;
            }
        }

        public string DbContexUsingClause
        {
            get
            {
                return this.dataInfo.DbContexUsingClause;
            }
            set
            {
                this.dataInfo.DbContexUsingClause = value;
            }
        }

        public bool UseAutoMapper
        {
            get
            {
                return this.dataInfo.UseAutoMapper;
            }
            set
            {
                this.dataInfo.UseAutoMapper = value;
                DBGlobalService.UseAutoMapper = value;
            }
        }

        public DatabaseType DbType { get; set; }

        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            menu.MenuItems.Add("比较EF设计", this.CompareEFDesign_Click);
            menu.MenuItems.Add("验证模型", this.ValidateModel_Click);
            menu.MenuItems.Add("更新设计阶段", this.UpdateDesignModel_Click);
            menu.MenuItems.Add("生成数据词典", this.GenerateDBDict_Click);
            menu.MenuItems.Add("和其他连接串比较", this.CompareOtherConnection_Click);

            //menu.MenuItems.Add("编辑", this.Edit_Click);
            return menu;
        }
        protected override void OnEdit(object sender, EventArgs args)
        {
            this.Edit_Click(sender, args);
            //base.OnEdit(sender, args);
        }
        void Edit_Click(object sender, EventArgs args)
        {
            ConnectionEditFrm frm = new ConnectionEditFrm();
            frm.UpdateConn(this);
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
        }
        public override void Save()
        {

            //while (dataInfo.Sqls..HasSql())
            //    dataInfo.RemoveSql();
            //while (dataInfo.HasTable())
            //    dataInfo.RemoveTable();

            dataInfo.Sqls.RemoveAll();
            dataInfo.Tables.RemoveAll();
            dataInfo.Views.RemoveAll();

            this.dataInfo.Tables.RemoveAll();

            foreach (TableNode tableNode in this._tablePkgNode.Children)
            {
                this.dataInfo.Tables.AddChild((TableType)tableNode.DataInfo);
            }

            foreach (ViewNode viewNode in this._viewPackageNode.Children)
            {
                this.dataInfo.Views.AddChild((TableType)viewNode.DataInfo);
            }

            foreach (SqlNode sqlNode in this._sqlPkgNode.Children)
            {
                this.dataInfo.Sqls.AddChild((SqlType)sqlNode.DataInfo);
            }

            base.Save();
        }
        private ConnectionType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<ConnectionType>();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                dataInfo.Name = this.Name;
                dataInfo.ConnectionString = this.ConncetionString;
                dataInfo.DbType = (int)this.DbType;
                //while (dataInfo.HasSql())
                //    dataInfo.RemoveSql();
                //dataInfo.Sqls.RemoveAll();

                //while (dataInfo.HasTable())
                //    dataInfo.RemoveTable();
                //dataInfo.Tables.RemoveAll();

                foreach (TableNode tableNode in this._tablePkgNode.Children)
                {
                    this.dataInfo.Tables.AddChild((TableType)tableNode.DataInfo);
                }

                foreach (ViewNode viewNode in this._viewPackageNode.Children)
                {
                    this.dataInfo.Views.AddChild((TableType)viewNode.DataInfo);
                }

                foreach (SqlNode sqlNode in this._sqlPkgNode.Children)
                {
                    this.dataInfo.Sqls.AddChild((SqlType)sqlNode.DataInfo);
                }

                this.dataInfo.TableRepository = (TableRepositoryType)this._tableRepositoryNode.DataInfo;
                this.dataInfo.TableRefMapping = (TableRefMappingType)this._tableMappingNode.DataInfo;
                this.dataInfo.TableStatus = (TableStatusType)this._tableStatusNode.DataInfo;
                this.dataInfo.Query = (QueryType)this._queryNode.DataInfo;

                return dataInfo;
            }
            set
            {
                this.dataInfo = (ConnectionType)value;
                this.Name = this.dataInfo.Name;
                this.ConncetionString = this.dataInfo.ConnectionString;
                this.DbType = (DatabaseType)this.dataInfo.DbType;
                DBGlobalService.DbType = this.DbType;
                DBGlobalService.ConnectionString = this.ConncetionString;
                this._tablePkgNode.Reset(this.dataInfo.Tables, this.ConncetionString);
                this._viewPackageNode.Reset(this.dataInfo.Views.ToList(), this.ConncetionString);
                this._tableRepositoryNode.DataInfo = this.dataInfo.TableRepository ?? this._tableRepositoryNode.DataInfo;
                this._tableMappingNode.DataInfo = this.dataInfo.TableRefMapping ?? this._tableMappingNode.DataInfo;
                this._tableStatusNode.DataInfo = this.dataInfo.TableStatus ?? this._tableStatusNode.DataInfo;
                this._queryNode.DataInfo = this.dataInfo.Query ?? this._queryNode.DataInfo;

                this._queryNode.Reset();

                this._sqlPkgNode.Reset(this.dataInfo.Sqls.ToList());
                this.sortTables();
            }
        }
        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);
        }

        public void OnChange()
        {
            var cfg_name = this.Name + "_EF_Edmx";
            var cfg = System.Configuration.ConfigurationManager.AppSettings[cfg_name];
            if (cfg == null)
            {
                DBGlobalService.EFConceptualModels = null;
                DBGlobalService.EFStorageModels = null;
                return;
            }

            if (!System.IO.File.Exists(cfg))
            {
                DBGlobalService.EFConceptualModels = null;
                DBGlobalService.EFStorageModels = null;
                return;
            }

            EF.StorageModels.Schema ef_storage = new EF.StorageModels.Schema();
            EF.ConceptualModels.Schema ef_concept = new EF.ConceptualModels.Schema();
            EF.Mappings.Mapping mapping = new EF.Mappings.Mapping();
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(cfg);
                var schema_storage = doc.ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[0];
                ef_storage.Parse(schema_storage);

                var schema_concept = doc.ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[0];
                ef_concept.Parse(schema_concept);

                var mappingNode = doc.ChildNodes[1].ChildNodes[1].ChildNodes[5].ChildNodes[0];
                mapping.Parse(mappingNode);

                DBGlobalService.EFStorageModels = ef_storage;
                DBGlobalService.EFConceptualModels = ef_concept;
                DBGlobalService.EFMappings = mapping;

                EFManager.Instance().Reset();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return;
            }
        }
        protected override void OnRefresh(object sender, EventArgs args)
        {
            //获取最新的表
            try
            {
                DbSchema.DatabaseSchema db = DatabaseSchema.CreateInstance(this.DbType);
                db.ConnectionString = this.ConncetionString;
                //db.Provider = new DbSchema.DbSchemaProvider.SqlSchemaProvider();
                var tables = db.Tables;

                TablePackageNode tablePkgNode = null;
                foreach (BaseNode n in this.Children)
                {
                    if (n is TablePackageNode)
                    {
                        tablePkgNode = (TablePackageNode)n;
                    }
                }
                this.TreeNode.TreeView.BeginUpdate();
                foreach (DbSchema.TableSchema table in tables)
                {

                    if (table.IsView)
                    {
                        bool exsited = false;

                        foreach (ViewNode each in this._viewPackageNode.Children)
                        {
                            if (each.Name.Equals(table.Name))
                            {
                                exsited = true;
                                each.Table = table;
                                break;
                            }
                        }

                        if (!exsited)
                        {
                            ViewNode tableNode = new ViewNode();

                            tableNode.Text = tableNode.Name = table.Name;
                            tableNode.Parent = _viewPackageNode;
                            tableNode.Table = table;
                        }
                    }
                    else
                    {
                        bool exsited = false;

                        foreach (TableNode each in tablePkgNode.Children)
                        {
                            if (each.Name.Equals(table.Name))
                            {
                                exsited = true;
                                each.Table = table;
                                break;
                            }
                        }

                        if (!exsited)
                        {
                            TableNode tableNode = new TableNode();

                            tableNode.Text = tableNode.Name = table.Name;
                            tableNode.Parent = tablePkgNode;
                            tableNode.Table = table;
                        }
                    }
                }

                this.sortTables();
                this.TreeNode.TreeView.EndUpdate();
                //检查EF

            }
            catch (Exception ex)
            {
                MessageBox.Show("失败:" + ex.Message);
            }

            base.OnRefresh(sender, args);
        }

        private void sortTables()
        {
            List<TreeNode> tNodes = new List<System.Windows.Forms.TreeNode>();
            foreach (TreeNode n in this._tablePkgNode.TreeNode.Nodes)
            {
                tNodes.Add(n);
            }

            this._tablePkgNode.TreeNode.Nodes.Clear();

            var orderNodes = tNodes.OrderBy((n) => { return n.Text; });
            foreach (TreeNode t in orderNodes)
            {
                this._tablePkgNode.TreeNode.Nodes.Add(t);
            }
        }

        private void ValidateModel_Click(object sender, EventArgs args)
        {
            DBGlobalService.FireClearError();

            //validate cfg
            var conn = ConnectionManager.Get(this.ConncetionString);

            conn.Parse_TableRelation(this.dataInfo.TableRefMapping.Settings);
            conn.Parse_TableRepository(this.dataInfo.TableRepository.Settings);

        }

        private void UpdateDesignModel_Click(object sender, EventArgs args)
        {
            MessageBox.Show("设计中...");
        }

        private void GenerateDBDict_Click(object sender, EventArgs args)
        {
            MessageBox.Show("设计中...");
        }

        private void CompareEFDesign_Click(object sender, EventArgs args)
        {
            EF.StorageModels.Schema ef_storage = new EF.StorageModels.Schema();
            EF.ConceptualModels.Schema ef_concept = new EF.ConceptualModels.Schema();
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                var cfg = System.Configuration.ConfigurationManager.AppSettings["EF_Edmx"];
                doc.Load(cfg);
                var schema_storage = doc.ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[0];
                ef_storage.Parse(schema_storage);

                var schema_concept = doc.ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[0];
                ef_concept.Parse(schema_concept);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }


            if (this._tablePkgNode == null && this._tablePkgNode.Children.Count == 0)
            {
                MessageBox.Show("没有表");
                return;
            }

            StringBuilder builder = new StringBuilder();
            List<string> newTables = new List<string>();
            //提示db新增加的表
            foreach (var table in this._tablePkgNode.Children)
            {
                if (!ef_storage.EntityTypes.ContainsKey(table.Name))
                {
                    newTables.Add(table.Name);
                }
            }

            var index = 1;
            newTables.ForEach(x => builder.AppendLine(
                string.Format("数据库中新增的表:{0} {1}", index++, x)
                ));
            List<string> notExsitedTables = new List<string>();

            //提示db不存在的表
            ef_storage.EntityTypes.Keys.ToList().ForEach(x =>
            {
                if (this._tablePkgNode.Children.Count(y => y.Name == x) == 0)
                {
                    notExsitedTables.Add(x);
                }
            });
            index = 1;
            notExsitedTables.ForEach(x => builder.AppendLine(
                string.Format("数据库中不存在的表:{0} {1}", index++, x)
                ));


            //提示db更新的表
            var sharedTable = ef_storage.EntityTypes.Where(
                x => this._tablePkgNode.Children.Count(
                    y => y.Name == x.Key) > 0).ToList();

            foreach (var table in sharedTable)
            {
                var entityType = table.Value;

                var dbTable = this._tablePkgNode.Children.FirstOrDefault(x => x.Name == table.Key)
                    as TableNode;

                //db多的字段
                var newFields = new List<ColumnSchema>();
                dbTable.GetColumnSetNode().Columns.ToList().ForEach(x =>
                    {
                        if (!table.Value.Propertys.ContainsKey(x.Name))
                        {
                            newFields.Add(x);
                        }
                    }
                    );

                index = 0;
                newFields.ForEach(x => builder.AppendLine(
                    string.Format("数据表{0}新增的字段: {1} {2}", table.Key, x.Name, x.NativeType)
                ));


                //db少的字段
                var noFields = new List<Property>();
                entityType.Propertys.ToList().ForEach(x =>
                {
                    if (dbTable.GetColumnSetNode().Columns.Count(y => y.Name == x.Key) == 0)
                    {
                        noFields.Add(x.Value);
                    }

                });

                noFields.ForEach(x => builder.AppendLine(
                    string.Format("数据表{0}缺少的字段: {1} {2}", table.Key, x.Name, x.Type)
                ));

                //db更新的字段
                foreach (var property in entityType.Propertys)
                {
                    var column = dbTable.GetColumnSetNode().Columns.FirstOrDefault(x => x.Name == property.Key);
                    if (column == null)
                        continue;

                    if (property.Value.Nullable != column.AllowDBNull)
                    {
                        builder.AppendLine(
                            string.Format("数据表{0}更改的字段: {1} {2}", table.Key, column.Name, column.AllowDBNull ? "数据库为可空" : "数据库为非空")
                    );
                    }

                    //if (property.Value.Type == "uniqueidentifier" && column.NativeType == "Guid")
                    //{
                    //    continue;

                    //}
                    var type = property.Value.Type;

                    if (type.IndexOf("(") > 0)
                    {
                        type = type.Substring(0, type.IndexOf("("));
                    }
                    if (type != column.NativeType)
                    {
                        builder.AppendLine(
                            string.Format("数据表{0}更改的字段: {1} {2},数据库类型为{3}", table.Key, column.Name, type, column.NativeType));
                    }

                }

            }

            this.OnGenerate(this, builder);
        }

        private void CompareOtherConnection_Click(object sender, EventArgs args)
        {
            try
            {
                var frm = new SelectConnectionFrm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var otherConn = frm.Connection;
                    if (otherConn == null || otherConn.Name == this.Name)
                    {
                        MessageBox.Show("必须选择其他连接串");
                        return;
                    }

                    if (this._tablePkgNode == null && this._tablePkgNode.Children.Count == 0)
                    {
                        MessageBox.Show("没有表");
                        return;
                    }

                    StringBuilder builder = new StringBuilder();

                    List<TableType> thisTables = this.dataInfo.Tables.ToList();
                    List<TableType> otherTables = otherConn.Tables.ToList();

                    List<TableType> thisViews = this.dataInfo.Views.ToList();
                    List<TableType> otherViews = otherConn.Views.ToList();

                    this.CompareTable(false, thisTables, otherTables, builder);
                    builder.AppendLine();
                    builder.AppendLine(new string('-', 100));
                    builder.AppendLine();
                    this.CompareTable(true, thisViews, otherViews, builder);
                    builder.AppendLine();
                    builder.AppendLine(new string('-', 100));
                    builder.AppendLine();
                    this.CompareViewCode(otherConn, thisViews, otherViews, builder);
                    builder.AppendLine();
                    builder.AppendLine(new string('-', 100));
                    builder.AppendLine();
                    this.CompareFunctionCode(otherConn, builder);
                    this.OnGenerate(this, builder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void CompareTable(bool isView,List<TableType> thisObjs, List<TableType> otherObjs,StringBuilder builder)
        {
            var objType = isView ? "视图" : "表";

                  List<string> newTables = new List<string>();
                //提示db新增加的表
                foreach (var table in thisObjs)
                {                    
                    if (otherObjs.FindTable(table.Name) == null)
                    {
                        newTables.Add(table.Name);
                    }
                }

                var index = 1;
                newTables.Sort();
                foreach (var table in newTables)
                {
                    builder.AppendLine(
                        string.Format("数据库中新增的{0}:{1} {2}",objType, index++, table)
                    );
                }

                List<string> notExsitedTables = new List<string>();

                //提示db不存在的表
                foreach (var other in otherObjs)
                {           
                    if (thisObjs.FindTable(other.Name) == null)
                    {
                        notExsitedTables.Add(other.Name);
                    }
                }

                index = 1;
                notExsitedTables.Sort();
                foreach (var table in notExsitedTables)
                {
                    builder.AppendLine(
                        string.Format("数据库中不存在的{0}:{1} {2}",objType, index++, table)
                    );
                }
               
                //提示db更新的表
                var sharedTable = new List<TableType>();

                foreach (var table in thisObjs)
                {
                    if (newTables.Contains(table.Name) ||
                         notExsitedTables.Contains(table.Name))
                        continue;

                    sharedTable.Add(table);
                }

                sharedTable= sharedTable.SortAsc();

                foreach (var table in sharedTable)
                {
                    //var entityType = table.Value;

                    var dbTable = table;
                    var otherTable = otherObjs.FindTable(table.Name);
                    //db多的字段
                    var newFields = new List<ColumnType>();
                    foreach (var column in dbTable.ColumnSet.Columns.ToList().SortAsc())
                    {
                        if (otherTable.FindColumn(column.Name) == null)
                            newFields.Add(column);
                    }

                    index = 0;
                    foreach (var f in newFields)
                    {
                        builder.AppendLine(
                       string.Format("数据{0}{1}新增的字段: {2} {3}", objType, table.Name, f.Name, f.DbType)
                   );
                    }


                    //db少的字段
                    var noFields = new List<ColumnType>();
                    foreach (var otherColumn in otherTable.ColumnSet.Columns.ToList().SortAsc())
                    {
                        if (dbTable.FindColumn(otherColumn.Name) == null)
                        {
                            noFields.Add(otherColumn);
                        }
                    }

                    foreach (var f in noFields)
                    {
                        builder.AppendLine(
                       string.Format("数据{0}{1}缺少的字段: {2} {3}", objType, table.Name, f.Name, f.DbType)
                   );
                    }


                    //db更新的字段
                    foreach (var column in dbTable.ColumnSet.Columns.ToList().SortAsc())
                    {

                        var otherColumn = otherTable.FindColumn(column.Name);
                        if (otherColumn == null)
                            continue;

                        if (column.AllowDBNull != otherColumn.AllowDBNull)
                        {
                            builder.AppendLine(
                                string.Format("数据{0}{1}更改的字段: {2} {3}", objType, table.Name, column.Name, column.AllowDBNull ? "数据库为可空" : "数据库为非空")
                        );
                        }

                        if (column.DbType != otherColumn.DbType)
                        {
                            builder.AppendLine(
                                string.Format("数据{0}{1}更改的字段: {2} {3},数据库类型为{4} VS {5}", objType, table.Name, column.Name, column.SystemType, column.DbType, otherColumn.DbType));
                        }

                    }

                }
        
        }

        private void CompareViewCode(ConnectionType otherConn, List<TableType> thisObjs, List<TableType> otherObjs, StringBuilder builder)
        {
            try
            {
                var helper = new DbHelper(this.dataInfo);
                var otherHelper = new DbHelper(otherConn);
                var views = new List<string>();
                foreach (var thisView in thisObjs)
                {
                    if (otherObjs.FindTable(thisView.Name) != null)
                    {
                        views.Add(thisView.Name);
                        continue;
                    }
                }

                var v_str = "";
                for (var index = 0; index < views.Count; index++)
                {
                    if (index > 0)
                        v_str += ",";

                    v_str += string.Format("'{0}'", views[index]);
                }

                var sql = string.Format(@"SELECT obj.name,m.definition
FROM sys.sql_modules m JOIN sys.objects obj
ON m.object_id= obj.object_id    
  and obj.type='v'
and obj.name in ({0}) order by obj.name", v_str);

                var thisDs = helper.ExecuteDataSet(sql);

                var otherDs = otherHelper.ExecuteDataSet(sql);

                for (var index = 0; index < thisDs.Tables[0].Rows.Count; index++)
                {
                    var thisRow = thisDs.Tables[0].Rows[index];
                    var otherRow = otherDs.Tables[0].Rows[index];

                    var thisSql = thisRow["definition"].ToString().Trim();
                    var otherSql = otherRow["definition"].ToString().Trim();

                    var thisReader = new System.IO.StringReader(thisSql);                    
                    var otherReader = new System.IO.StringReader(otherSql);

                    var thisFirstLine = thisReader.ReadLine().Replace("[", "").Replace("]","");
                    var otherFirstLine = otherReader.ReadLine().Replace("[", "").Replace("]", "");

                    if (thisFirstLine != otherFirstLine)
                    {
                        builder.AppendFormat("View Difference {0}", thisRow["name"].ToString());
                        builder.AppendLine();
                        continue;
                    }

                    var this_ = thisReader.ReadToEnd();
                    var other_ = otherReader.ReadToEnd();

                    if (this_ != other_)
                    {
                        builder.AppendFormat("View Difference {0}", thisRow["name"].ToString());
                        builder.AppendLine();
                        continue;
                    }

                    //if (thisRow["definition"].ToString().Trim() != otherRow["definition"].ToString().Trim())
                    //{
                    //    builder.AppendFormat("View Difference {0}", thisRow["name"].ToString());
                    //    builder.AppendLine();
                    //}
                }

                helper.Close();
                otherHelper.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CompareFunctionCode(ConnectionType otherConn,StringBuilder builder)
        {
            var helper = new DbHelper(this.dataInfo);
            var otherHelper = new DbHelper(otherConn);
            var views = new List<string>();   

            var v_str = "";
            for (var index = 0; index < views.Count; index++)
            {
                if (index > 0)
                    v_str += ",";

                v_str += string.Format("'{0}'", views[index]);
            }

            var sql = string.Format(@"SELECT obj.type,obj.name,m.definition
FROM sys.sql_modules m JOIN sys.objects obj
ON m.object_id= obj.object_id    
  and obj.type in ('if','fn')
order by obj.name", v_str);

            var thisDs = helper.ExecuteDataSet(sql);

            var otherDs = otherHelper.ExecuteDataSet(sql);

            #region 判断本地多的函数
            for (var index = 0; index < thisDs.Tables[0].Rows.Count; index++)
            {
                var thisRow = thisDs.Tables[0].Rows[index];
               

                var this_type = thisRow["type"].ToString().Trim();
                var this_definition = thisRow["definition"].ToString().Trim();
                var this_name = thisRow["name"].ToString().Trim();

                bool exsited = false;
                var func_type = "";
                if (this_type.Equals("if", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "表值函数";
                }
                else if (this_type.Equals("fn", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "值函数";
                }

                for (var j = 0; j < otherDs.Tables[0].Rows.Count; j++)
                {
                    var otherRow = otherDs.Tables[0].Rows[j];
                    var other_type = otherRow["type"].ToString().Trim();
                    var other_definition = otherRow["definition"].ToString().Trim();
                    var other_name = otherRow["name"].ToString().Trim();

                    if (this_type == other_type && this_name == other_name)
                    {
                        exsited = true;
                        continue;
                    }
                }

                if (!exsited)
                {
                    builder.AppendFormat("本地新增{0} ： {1}", func_type, this_name);
                    builder.AppendLine();
                }
            }
            #endregion

            #region 判断本地少的函数
            for (var index = 0; index < otherDs.Tables[0].Rows.Count; index++)
            {

                var otherRow = otherDs.Tables[0].Rows[index];
                var other_type = otherRow["type"].ToString().Trim();
                var other_definition = otherRow["definition"].ToString().Trim();
                var other_name = otherRow["name"].ToString().Trim(); 
                bool exsited = false;
                var func_type = "";
                if (other_type.Equals("if", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "表值函数";
                }
                else if (other_type.Equals("fn", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "值函数";
                }

                for (var j = 0; j < thisDs.Tables[0].Rows.Count; j++)
                {
                    var thisRow = thisDs.Tables[0].Rows[j];
                    var this_type = thisRow["type"].ToString().Trim();
                    var this_definition = thisRow["definition"].ToString().Trim();
                    var this_name = thisRow["name"].ToString().Trim();

                    if (this_type == other_type && this_name == other_name)
                    {
                        exsited = true;
                        continue;
                    }
                }

                if (!exsited)
                {
                    builder.AppendFormat("本地缺少{0} ： {1}", func_type, other_type);
                    builder.AppendLine();
                }
            }
            #endregion

            #region 判断函数内容的不同
            for (var index = 0; index < thisDs.Tables[0].Rows.Count; index++)
            {
                var thisRow = thisDs.Tables[0].Rows[index];


                var this_type = thisRow["type"].ToString().Trim();
                var this_definition = thisRow["definition"].ToString().Trim();
                var this_name = thisRow["name"].ToString().Trim();

                var func_type = "";
                if (this_type.Equals("if", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "表值函数";
                }
                else if (this_type.Equals("fn", StringComparison.OrdinalIgnoreCase))
                {
                    func_type = "值函数";
                }

                for (var j = 0; j < otherDs.Tables[0].Rows.Count; j++)
                {
                    var otherRow = otherDs.Tables[0].Rows[j];
                    var other_type = otherRow["type"].ToString().Trim();
                    var other_definition = otherRow["definition"].ToString().Trim();
                    var other_name = otherRow["name"].ToString().Trim();

                    if (this_type == other_type && this_name == other_name)
                    {
                        if (this_definition != other_definition)
                        {
                            builder.AppendFormat("{0} 内容不同： {1}", func_type, this_name);
                            builder.AppendLine();
                        }
                        continue;
                    }
                }


            }
            #endregion
        }
    }
}
        
    

