using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
//using ConfigSectionsLib;
using System.Configuration;
//using Generator.Config;
using CodeHelper.DataBaseHelper.Items;
using CodeHelper.DataBaseHelper.Items.DBItems;
using Project;
using System.Threading;
using CodeHelper.DataBaseHelper.Sql;
using CodeHelper.DataBaseHelper.Repository;
using CodeHelper.Xml;
using CodeHelper.DataBaseHelper.Items.Services;
using CodeHelper.DataBaseHelper.Items.Ajaxs;
using CodeHelper.DataBaseHelper.Items.Forms;
using CodeHelper.Core;
using System.IO;
using CodeHelper.Core.DbConfig;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper
{
    public delegate void DelegateChangeText(string s);
    public partial class MainFrm : Form
    {
        TextEditorControl textEditor = new TextEditorControl();
        //TreeNode ConnectionPkgNode = null;
        //TreeNode CustomModePkgNode = null;
        TreeNode ProjectTreeNode
        {
            get
            {
                if (this.treeView1.Nodes.Count > 0)
                    return (TreeNode)this.treeView1.Nodes[0];

                return null;
            }
        }
        DBProjectNode ProjectNode
        {
            get
            {
                if (this.ProjectTreeNode != null)
                {
                    return this.ProjectTreeNode.Tag as DBProjectNode;
                }
                return null;
            }
        }
       
        public MainFrm()
        {
            InitializeComponent();
            InitIcon();

            this.treeView1.ImageList = DBGlobalService.Icons;

            this.textEditor.Dock = DockStyle.Fill;
            this.panelWorkArea.Controls.Add(this.textEditor);            
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            this.treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            CodeHelper.Core.Services.GlobalService.ResloveTableAgent = new ResloveTableAgent();

            ConnectionManager.OnValidateError += new ValidateError(ConnectionManager_OnValidateError);
            DBGlobalService.OnClearError += new DBGlobalService.ClearError(GlobalService_OnClearError);
            //打开上一次处理的工程
            try
            {
                DBGlobalService.ProjectFile = System.Configuration.ConfigurationManager.AppSettings["CurrentProject"];
                var doc = new Document();
                doc.Load(DBGlobalService.ProjectFile);
                DBGlobalService.CurrentProjectDoc = doc; 
                DBGlobalService.CurrentProject = new ProjectType(doc);
                DBGlobalService.SaveProject += new DBGlobalService.SaveDelegate(GlobalService_SaveProject);
                
                this.CreateTree();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.WindowState = FormWindowState.Maximized;
        }

        void GlobalService_OnClearError()
        {
            this.dataGridView1.Rows.Clear();
        }

        void ConnectionManager_OnValidateError(string connStr, string message)
        {
            this.dataGridView1.Rows.Add(connStr, message);
        }

        void GlobalService_SaveProject()
        {
            this.SaveMenuItem_Click(null, null);
        }

        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //GlobalService.ConnectionString = null;
            //GlobalService.DbType = DatabaseType.UnKnown;
            //BaseNode node = e.Node.Tag as BaseNode;
            //while (node != null)
            //{
            //    if (node is ConnectionNode)
            //    {
            //        GlobalService.ConnectionString = ((ConnectionNode)node).ConncetionString;
            //        GlobalService.DbType = ((ConnectionNode)node).DbType;
            //        break;
            //    }
            //    node = node.Parent;
            //}

            //GlobalService.ConnectionString = null;
            //GlobalService.DbType = DatabaseType.UnKnown;
            //BaseNode node = e.Node.Tag as BaseNode;
            //while (node != null)
            //{
            //    if (node is ConnectionNode)
            //    {
            //        GlobalService.ConnectionString = ((ConnectionNode)node).ConncetionString;
            //        GlobalService.DbType = ((ConnectionNode)node).DbType;
            //        ((ConnectionNode)node).OnChange();
            //        break;
            //    }
            //    node = node.Parent;
            //}
      
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            //GlobalService.ConnectionString = null;
            DBGlobalService.DbType = DatabaseType.UnKnown;
            BaseNode node = e.Node.Tag as BaseNode;
            while (node != null)
            {
                if (node is ConnectionNode)
                {
                    DBGlobalService.ConnectionString = ((ConnectionNode)node).ConncetionString;
                    DBGlobalService.DbType = ((ConnectionNode)node).DbType;
                    DBGlobalService.DbContexUsingClause = ((ConnectionNode)node).DbContexUsingClause;
                    ((ConnectionNode)node).OnChange();
                    break;
                }
                node = node.Parent;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.Clicks == 1)
            {
                node = e.Node.Tag as BaseNode;
                if (node != null)
                {
                    //if (e.Node.BackColor != Color.White)
                    //{
                    //    e.Node.ForeColor = Color.Black;
                    //}
                    ContextMenu menu = node.GetPopMenu();
                    e.Node.ContextMenu = menu;
                    e.Node.ContextMenu.Show(this.treeView1, e.Location);
                    e.Node.ContextMenu = null;                                        
                }
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                node = e.Node.Tag as BaseNode;
                if (node != null)
                {
                    this.propertyGrid1.SelectedObject = node;
                }
            }
        }

        private void NewProjectMenuItem_Click(object sender, EventArgs e)
        {
            if (new CreatePorjectFrm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.treeView1.Nodes.Clear();
                this.CreateTree();
            }
        }
        private void CreateTree()
        {
            this.treeView1.BeginUpdate();
            DBProjectNode projNode = new DBProjectNode();
            projNode.DataInfo = DBGlobalService.CurrentProject;
            this.treeView1.Nodes.Add(projNode.TreeNode);
            TreeEventSource eventSource = new TreeEventSource(projNode);
            eventSource.Refresh += new RefreshDelegate(eventSource_Refresh);
            eventSource.Generate += new GenerateDelegate(eventSource_Generate);

            /*
            //load biz config
            var bizCfg = GlobalService.ProjectFile.Replace(".xml", ".biz.xml");
            var doc = new Document();
            BusinessCfg cfg = null;
            if (System.IO.File.Exists(bizCfg))
            {
                doc.Load(bizCfg);
                cfg = new BusinessCfg(doc);
            }
            else
            {
                cfg = doc.CreateNode<BusinessCfg>();
                doc.Root = cfg;
                cfg.ServiceFolder = doc.CreateNode<ServiceFolder>();
                cfg.AjaxFolder = doc.CreateNode<AjaxFolder>();
                cfg.FormViewFolder = doc.CreateNode<FormViewFolder>();
            }

            GlobalService.BusinessCfgDoc = doc;
           
            var serviceNode = new ServiceFolderNode();
            serviceNode.ServiceFolder = cfg.ServiceFolder;

            projNode.Children.Add(serviceNode);

            var ajaxNode = new AjaxFolderNode();
            ajaxNode.Dom = cfg.AjaxFolder.Dom;

            projNode.Children.Add(ajaxNode);

            var formNode = new FormFolderNode();
            if (string.IsNullOrWhiteSpace(cfg.FormViewFolder.Name))
                cfg.FormViewFolder.Name = "表单";

            formNode.FormFolder = cfg.FormViewFolder; 

            projNode.Children.Add(formNode);

            doc.Save(bizCfg);
            
             */
            this.treeView1.EndUpdate();
            return;

            projNode.Name = projNode.Text = "工程";

            #region 连接字符串

            ConnectionPackageNode connPkgNode = new ConnectionPackageNode();
            connPkgNode.Parent = projNode;
            connPkgNode.Text = connPkgNode.Name = "连接串";

            foreach (Project.ConnectionType connectionRow in DBGlobalService.CurrentProject.Connections)
            {

                ConnectionNode connNode = new ConnectionNode();
                connNode.Name = connNode.Text = connectionRow.Name;
                connNode.ConncetionString = connectionRow.ConnectionString;
                connNode.Parent = connPkgNode;
                //表

                TablePackageNode tablePkgNode = new TablePackageNode();
                tablePkgNode.Name = tablePkgNode.Text = "表";
                tablePkgNode.Parent = connNode;

                foreach (Project.TableType tableRow in connectionRow.Tables)
                {

                    TableNode tableNode = new TableNode();
                    tableNode.Text = tableNode.Name = tableRow.Name;
                    tableNode.Parent = tablePkgNode;

                }

                //sql
                SqlPackageNode sqlPkgNode = new SqlPackageNode();
                sqlPkgNode.Text = sqlPkgNode.Name = "查询";
                sqlPkgNode.Parent = connNode;

                foreach (Project.SqlType sqlRow in connectionRow.Sqls)
                {

                    SqlNode sqlNode = new SqlNode();
                    sqlNode.Name = sqlNode.Text = sqlRow.Name;
                    sqlNode.Parent = sqlPkgNode;

                    DBModelNode modeNode = new DBModelNode();
                    modeNode.Text = modeNode.Name = sqlRow.Name;

                    modeNode.Parent = sqlNode;
                }
            }
            #endregion

            #region 自定义模型

            //CustomModelSetNode customModlePkgNode = new CustomModelSetNode();
            //customModlePkgNode.Text = customModlePkgNode.Name = "自定义模型";
            //customModlePkgNode.Parent = projNode;

            //if (GlobalService.CurrentProject.HasCustomModelSet())
            //{
            //    foreach (Project.ModelType row in GlobalService.CurrentProject.CustomModelSet.MyModels)
            //    {

            //        ModelNode modeNode = new ModelNode();
            //        modeNode.ModelType = ModelNode.SourceType.FromCustom;
            //        modeNode.Name = modeNode.Text = row.Name.Value;
            //        modeNode.Parent = customModlePkgNode;
            //    }
            //}
            #endregion
        }

        void eventSource_Generate(BaseNode node, StringBuilder builder)
        {
            this.panelOutput.Controls.Clear();
            //this.panelWorkArea.Controls.Remove(this.textEditor);
            this.textEditor = new TextEditorControl();
            this.textEditor.Dock = DockStyle.Fill;
            this.panelOutput.Controls.Add(this.textEditor);     
            this.textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            //this.textEditor.Document.Remove(0, this.textEditor.Document.TextLength);
            //this.textEditor.Validate();
            //this.textEditor.Update();
            //this.textEditor.ActiveTextAreaControl.TextArea.Update();
            this.textEditor.Document.TextContent = builder.ToString();
            //this.textEditor.Text = builder.ToString();
            this.panelOutput.Invalidate(true);
        }

        void eventSource_Refresh(BaseNode node)
        {
            //TreeNode targetNode = this.GetTreeNodeByTag(node);
            //this.FindModel(this.ProjectTreeNode, node, ref targetNode);
            //if (targetNode != null)
            //{
            //    this.RefreshTreeNode(node, targetNode);
            //    this.treeView1.Update();
            //}
            
        }
        TreeNode GetTreeNodeByTag(BaseNode node)
        {
            TreeNode target = null;
            this.GetTreeNodeByTag(this.ProjectTreeNode, node, ref target);
            return target;
        }
        void GetTreeNodeByTag(TreeNode treeNode ,BaseNode node , ref TreeNode target)
        {
            if (treeNode.Tag.Equals(node))
            {
                target = treeNode;
            }
            foreach (TreeNode child in treeNode.Nodes)
            {
                this.GetTreeNodeByTag(child, node, ref target);
            }
        }
        void RefreshTreeNode(BaseNode node , TreeNode treeNode)
        {
            //treeNode.Name = treeNode.Text = node.Name;
            //treeNode.Tag = node;

            if (!treeNode.Name.Equals(node.Name))
            {
                TreeNode newTreeNode = new TreeNode();
                newTreeNode.Text = newTreeNode.Name = node.Name;
            }
            
            foreach (BaseNode eachNode in node.Children)
            {
                foreach (TreeNode eachTreeNode in treeNode.Nodes)
                {
                    if (eachTreeNode.Name.Equals(eachNode))
                    {
                         
                    }
                }
                TreeNode newTreeNode = new TreeNode();
                this.RefreshTreeNode(eachNode,newTreeNode);
                treeNode.Nodes.Add(newTreeNode);
            }

        }

        void FindModel(TreeNode node ,BaseNode baseNode, ref TreeNode treeNode )
        {            
            if ( node.Tag != null &&  node.Tag.Equals( baseNode))
            {
                treeNode = node;
                return;
            }
            foreach (TreeNode each in node.Nodes)
            {
                FindModel(each, baseNode, ref treeNode);
            }
            
        }

        private void OpenProjectMenuItem_Click(object sender, EventArgs e)
        {
            if (new OpenProjectFrm().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.CreateTree();
                this.treeView1.ExpandAll();
                System.Configuration.ConfigurationManager.AppSettings["CurrentProject"] = DBGlobalService.ProjectFile;
                //System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                Configuration config = ConfigurationManager .OpenExeConfiguration(ConfigurationUserLevel .None);
                if (config.AppSettings.Settings["CurrentProject"] != null)
                {
                    config.AppSettings.Settings["CurrentProject"].Value = DBGlobalService.ProjectFile;
                }
                else
                {
                    config.AppSettings.Settings.Add("CurrentProject",DBGlobalService.ProjectFile);
                }
                 
                config.Save(ConfigurationSaveMode.Full);
                //config.Save();

                ConfigurationManager.RefreshSection("appSettings");

            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProjectNode.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败:"+ex.Message);
            }
            System.Configuration.ConfigurationManager.AppSettings["CurrentProject"] = DBGlobalService.ProjectFile;               

        }

        void InitIcon()
        {
            var dir = new DirectoryInfo(@"Images\Bonus\ICO\");
            //this.treeView1.ImageList = new ImageList();

            foreach (var icon in dir.GetFiles("*.ico"))
            {
                DBGlobalService.Icons.Images.Add(Path.GetFileNameWithoutExtension(icon.Name), Image.FromFile(icon.FullName));
                //this.treeView1.ImageList.Images.Add(Path.GetFileNameWithoutExtension(icon.Name), Image.FromFile(icon.FullName));
            }
        }
    }
}
