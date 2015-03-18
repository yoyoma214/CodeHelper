using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Generator.Config;
using System.Data;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.GenerateUnit.GenModel;
using CodeHelper.DataBaseHelper.GenerateUnit.GenView;
using CodeHelper.DataBaseHelper.GenerateUnit.GenEF;
using CodeHelper.DataBaseHelper.GenerateUnit.GenWcf;
using CodeHelper.DataBaseHelper.GenerateUnit.NewOA;
using CodeHelper.DataBaseHelper.GenerateUnit.GenExport;
using CodeHelper.DataBaseHelper.GenerateUnit.GenMVC;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public class DBModelNode : BaseNode
    {
        public enum SourceType
        {
            Unknown = -1, FromCustom = 0, FromSql = 1, FromTable = 2
        }
        public SourceType ModelType
        {
            get;
            set;
        }
        public string Namespace
        {
            get;
            set;
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
        private string _columnSetName = "";
        public string ColumnSetName
        {
            get
            {
                return this._columnSetName;
            }
            set
            {
                this._columnSetName = value;
            }
        }
        //private ListViewOperationNode listViewOperatioNode = new ListViewOperationNode();
        public DBModelNode()
            : base()
        {
            this.Text = "模型:";
            this.Name = "";
            //this.listViewOperatioNode.Parent = this;

            //this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "274";
        }
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            //menu.MenuItems.Add("刷新", this.Refresh_Click);   
            MenuItem nHibernatItmes = new MenuItem("生成NHibernate");
            nHibernatItmes.MenuItems.Add("生成实体对象", this.CreateNHEntity_Click);
            //menu.MenuItems.Add(nHibernatItmes);

            MenuItem nEFItmes = new MenuItem("生成EF");
            nEFItmes.MenuItems.Add("生成实体对象", this.CreateEF_Click);
            nEFItmes.MenuItems.Add("生成实体对象Map", this.CreateEFMap_Click);
            menu.MenuItems.Add(nEFItmes);

            MenuItem nNewOARepositoryItmes = new MenuItem("生成NewOA的Repository");
            nNewOARepositoryItmes.MenuItems.Add("生成Repository接口", this.CreateNewOAIRepository_Click);
            nNewOARepositoryItmes.MenuItems.Add("生成Specification规约", this.CreateNewOASpecification_Click);
            nNewOARepositoryItmes.MenuItems.Add("生成Repository实现", this.CreateNewOARepository_Click);
            menu.MenuItems.Add(nNewOARepositoryItmes);

            MenuItem nWcfItmes = new MenuItem("生成WCF");
            nWcfItmes.MenuItems.Add("生成Dto", this.CreateWcfDto_Click);
            nWcfItmes.MenuItems.Add("生成实体转Dto", this.CreateWcfEFToDto_Click);
            nWcfItmes.MenuItems.Add("生成Dto转实体", this.CreateWcfDtoToEF_Click);
            nWcfItmes.MenuItems.Add("-");
            nWcfItmes.MenuItems.Add("生成基本Service", this.CreateWcfBaseService_Click);
            nWcfItmes.MenuItems.Add("-");
            nWcfItmes.MenuItems.Add("生成基本CCFLowService", this.CreateWcfBaseCCFLowService_Click);
            menu.MenuItems.Add(nWcfItmes);

            MenuItem nViewModelItmes = new MenuItem("生成View模型");
            nViewModelItmes.MenuItems.Add("生成ViewModel", this.CreateViewModelDto_Click);
            nViewModelItmes.MenuItems.Add("生成ViewModel转Wcf Dto", this.CreateViewModelToWcfDto_Click);
            nViewModelItmes.MenuItems.Add("生成Wcf Dto转ViewModel", this.CreateWcfDtoToViewModel_Click);
            menu.MenuItems.Add(nViewModelItmes);

            MenuItem nViewItems = new MenuItem("生成View");
            nViewItems.MenuItems.Add("生成编辑页面Model", this.CreateEditViewModel_Click);
            nViewItems.MenuItems.Add("生成编辑页面", this.CreateEditView_Click);            
            menu.MenuItems.Add(nViewItems);

            MenuItem nActionItems = new MenuItem("生成MVC");
            nActionItems.MenuItems.Add("生成Action", this.CreateActions_Click);
            menu.MenuItems.Add(nActionItems);

            menu.MenuItems.Add("生成报表配置", this.CreatExport_Click);

            //menu.MenuItems.Add("生成模型代码", this.CreateMode_Click);
            //menu.MenuItems.Add("生成列表页", this.CreateListView_Click);
            //menu.MenuItems.Add("生成列表页后台代码", this.CreateListViewCS_Click);
            //menu.MenuItems.Add("生成新增页", this.CreateAddView_Click);
            //menu.MenuItems.Add("生成新增页后台代码", this.CreateAddViewCS_Click);
            //menu.MenuItems.Add("生成编辑页", this.CreateEditView_Click);
            //menu.MenuItems.Add("生成只读页", this.CreateReadonlyView_Click);

            foreach (MenuItem m in menu.MenuItems)
            {
                if (m.Text.Equals("删除"))
                    m.Text = "删除所有字段";
            }
            return menu;
        }
        void CreateNHEntity_Click(object sender, EventArgs args)
        {
            GenModel gen = new GenModel((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateEF_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            var table = this.Reslove(typeof(TableNode), null);
            var gen = new GenEFEntity((ModelType)this.DataInfo, columnSetNode, table as TableNode);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateTableHtmllDto_Click(object sender, EventArgs args)
        {
            var gen = new GenTableHtml((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        private void CreateEditViewModel_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)base.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            GenEditViewModel view = new GenEditViewModel((ModelType)this.DataInfo, columnSetNode);
            StringBuilder builder = new StringBuilder();
            view.Generate(builder);
            this.OnGenerate(this, builder);
        }

        private void CreateActions_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)base.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            GenActions view = new GenActions((ModelType)this.DataInfo, columnSetNode);
            StringBuilder builder = new StringBuilder();
            view.Generate(builder);
            this.OnGenerate(this, builder);
        }

        private void CreateEditView_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)base.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            GenEditView view = new GenEditView((ModelType)this.DataInfo, columnSetNode);
            StringBuilder builder = new StringBuilder();
            view.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateViewModelDto_Click(object sender, EventArgs args)
        {
            var gen = new GenViewModel((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateViewModelToWcfDto_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            var gen = new GenConvertViewModelToWcfDto((ModelType)this.DataInfo, columnSetNode);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateWcfDtoToViewModel_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            var gen = new GenConverWcfDtoTotViewMode((ModelType)this.DataInfo, columnSetNode);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateWcfDto_Click(object sender, EventArgs args)
        {
            var gen = new GenDto((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateNewOAIRepository_Click(object sender, EventArgs args)
        {
            var gen = new GenIRepository((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateNewOASpecification_Click(object sender, EventArgs args)
        {
            var gen = new GenSepcification((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateNewOARepository_Click(object sender, EventArgs args)
        {
            var gen = new GenRepository((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateEFMap_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);

            var gen = new GenEFMap((ModelType)this.DataInfo, columnSetNode);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateWcfEFToDto_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);

            var gen = new GenConvertEFToDto((ModelType)this.DataInfo, columnSetNode);

            StringBuilder builder = new StringBuilder();

            gen.Generate(builder);

            this.OnGenerate(this, builder);
        }


        void CreateWcfDtoToEF_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);

            var gen = new GenConverDtoTotEF((ModelType)this.DataInfo, columnSetNode);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        private void CreateWcfBaseService_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)base.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            GenBaseService service = new GenBaseService((ModelType)this.DataInfo, columnSetNode);
            StringBuilder builder = new StringBuilder();
            service.Generate(builder);
            this.OnGenerate(this, builder);
        }

        private void CreateWcfBaseCCFLowService_Click(object sender, EventArgs args)
        {
            ColumnSetNode columnSetNode = (ColumnSetNode)base.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            var service = new GenBaseCCFlowService((ModelType)this.DataInfo, columnSetNode);
            StringBuilder builder = new StringBuilder();
            service.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreatExport_Click(object sender, EventArgs args)
        {
            var gen = new GenReportConfig((ModelType)this.DataInfo);
            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }

        void CreateMode_Click(object sender, EventArgs args)
        {
            GenModel gen = new GenModel((ModelType)this.DataInfo);

            StringBuilder builder = new StringBuilder();
            gen.Generate(builder);
            this.OnGenerate(this, builder);
        }
        protected override void OnEdit(object sender, EventArgs args)
        {
            EditModelFrm frm = new EditModelFrm();
            ColumnSetNode columnSetNode = (ColumnSetNode)this.Reslove(typeof(ColumnSetNode), this.ColumnSetName);
            frm.UpdateModel(this, columnSetNode);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Children.Clear();

                //更新模型
                IList<EditModelFrm.FieldItem> items = frm.FieldItems;

                foreach (EditModelFrm.FieldItem item in items)
                {
                    FieldNode node = NodeFactory.CreateNode<FieldNode>();// new FieldNode();
                    node.Name = item.Name;
                    node.ColumnName = item.ColumnName;
                    node.Description = item.Description;
                    node.NullAble = item.NullAble;
                    node.SystemType = SchemaUtility.GetSystemType(DBGlobalService.DbType, item.SystemType);
                    node.Parent = this;
                }
            }
            base.OnEdit(sender, args);
        }
        void EditModel_Click(object sender, EventArgs args)
        {
        }
        void Refresh_Click(object sender, EventArgs args)
        {
        }
        void CreateListView_Click(object sender, EventArgs args)
        {
            //System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
            //w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteRaw(this.DataInfo.DomNode.OuterXml);
            //w.Flush();
            //w.Close();
            //GenListView gen = new GenListView(@"Xsl/ListView.xslt", "1.xml");
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);
        }
        void CreateListViewCS_Click(object sender, EventArgs args)
        {
            //System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
            //w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteRaw(this.DataInfo.DomNode.OuterXml);
            //w.Flush();
            //w.Close();
            //GenListView gen = new GenListView(@"Xsl/ListViewCS.xslt", "1.xml");
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);
        }
        void CreateAddView_Click(object sender, EventArgs args)
        {
            //System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
            //w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteRaw(this.DataInfo.DomNode.OuterXml);
            //w.Flush();
            //w.Close();
            //GenListView gen = new GenListView(@"Xsl/NewView.xslt", "1.xml");
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);
        }
        void CreateAddViewCS_Click(object sender, EventArgs args)
        {
            //System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
            //w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //w.WriteRaw(this.DataInfo.DomNode.OuterXml);
            //w.Flush();
            //w.Close();
            //GenListView gen = new GenListView(@"Xsl/NewViewCS.xslt", "1.xml");
            //StringBuilder builder = new StringBuilder();
            //gen.Generate(builder);
            //this.OnGenerate(this, builder);
        }

        void CreateReadonlyView_Click(object sender, EventArgs args)
        {
        }

        private ModelType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<ModelType>();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.Name = this.Name;
                this.dataInfo.ColumnSetName = this.ColumnSetName;

             
                    this.dataInfo.Fields.RemoveAll();                

                foreach (BaseNode node in this.Children)
                {
                    if (node is FieldNode)
                    {
                        this.dataInfo.Fields.AddChild((FieldType)node.DataInfo);
                    }
                    //if (node is ListViewOperationNode)
                    //{
                    //    this.dataInfo.AddListViewOperation((ListViewOperationType)node.DataInfo);
                    //}
                }
                return this.dataInfo;
            }
            set
            {
                this.dataInfo = (ModelType)value;
                this.Name = this.dataInfo.Name;
                this.ColumnSetName = this.dataInfo.ColumnSetName;
                for (int i = 0; i < this.Children.Count; i++)
                {
                    if (this.Children[i] is FieldNode)
                    {
                        this.Children.RemoveAt(i);
                        i--;
                    }
                }
                foreach (FieldType fieldType in this.dataInfo.Fields)
                {
                    FieldNode fieldNode = NodeFactory.CreateNode<FieldNode>();// new FieldNode();
                    fieldNode.DataInfo = fieldType;
                    fieldNode.Parent = this;
                }
                //if (this.dataInfo.HasListViewOperation())
                //{
                //    this.listViewOperatioNode.DataInfo = this.dataInfo.ListViewOperation;
                //}
            }
        }
        public override void Save()
        {
            base.Save();
        }
        protected override void OnUpdate()
        {
            this.Text = "模型:" + this.Name;
            base.OnUpdate();
        }
        protected override void OnDelete(object sender, EventArgs args)
        {
            this.Children.Clear();
            base.OnDeleteChild(this);
        }
        protected override BaseNode OnReslove(Type nodeType, string name)
        {
            if (this.GetType().Equals(nodeType) && string.IsNullOrWhiteSpace(name))
                return this;

            return base.OnReslove(nodeType, name);
        }

       
    }
}
