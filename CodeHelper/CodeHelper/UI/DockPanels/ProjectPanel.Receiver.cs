using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;
using CodeHelper.Items;
using CodeHelper.Core.Services;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper;
using CodeHelper.Xml;
using Project;
using CodeHelper.Core;
using CodeHelper.DataBaseHelper.Sql;
using CodeHelper.Core.DbConfig;

namespace CodeHelper.UI.DockPanels
{
    partial class ProjectPanel: IReceiverHolder
    {
        TreeView treeView1;
        //DesignProjectNode mDesignNode;
        //DBProjectNode mDataBaseNode;

        public ProjectPanel()
            : base()
        {
            InitializeComponent();
        }        

        protected override void OnLoad(EventArgs e)
        {
            treeView1 = new TreeView();

            treeView1.ImageList = GlobalService.Icons;

            treeView1.Dock = DockStyle.Fill;

            //var treeView2 = new TreeView();
            //treeView2.Nodes.Add("aaa");
            //treeView2.Dock = DockStyle.Fill;
            //treeView2.BackColor = Color.AliceBlue;

            this.Controls.Add(treeView1);
            //this.Controls.Add(treeView2);

            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            this.treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
            this.treeView1.DragEnter += new DragEventHandler(treeView1_DragEnter);
            this.treeView1.DragLeave += new EventHandler(treeView1_DragLeave);
            this.treeView1.DragDrop += new DragEventHandler(treeView1_DragDrop);
            this.treeView1.DragOver += new DragEventHandler(treeView1_DragOver);
            this.treeView1.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            this.treeView1.AllowDrop = true;

            this.ShowIcon = false;
            this.TabText = this.Text = "工程";
            base.OnLoad(e);
            
            //this.receiver.OnOpenProject += new ReceiverBase.OpenProjectHandler(receiver_OnOpenProject);
            this.receiver.OnNewNullProject += new ReceiverBase.NewNullProjectHandler(receiver_OnNewNullProject);
            this.receiver.OnOpenProject += new ReceiverBase.OpenProjectHandler(receiver_OnOpenProject);
            this.receiver.OnOpenNullProject += new ReceiverBase.OpenNullProjectHandler(receiver_OnOpenNullProject);
            this.receiver.OnOpenFile += new ReceiverBase.OpenFileHandler(receiver_OnOpenFile);

            CodeHelper.Core.Services.GlobalService.ResloveTableAgent = new ResloveTableAgent();

            ConnectionManager.OnValidateError += new ValidateError(ConnectionManager_OnValidateError);
            DBGlobalService.OnClearError += new DBGlobalService.ClearError(GlobalService_OnClearError);
        }
        void GlobalService_OnClearError()
        {
            //this.dataGridView1.Rows.Clear();
        }

        void ConnectionManager_OnValidateError(string connStr, string message)
        {
            //this.dataGridView1.Rows.Add(connStr, message);
        }

        void treeView1_DragOver(object sender, DragEventArgs e)
        {
            this.MyOldNode.BackColor = Color.White;
        }

        void treeView1_DragLeave(object sender, EventArgs e)
        {
            //this.MyOldNode.BackColor = Color.Blue;
        }

        void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //设置拖放类型为移动           
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            //获取节点的数据内容           
            object MyData = e.Data.GetData(typeof(TreeNode));
            //如果节点有数据，拖放目标允许移动           
            if (MyData != null)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
            TreeView MyTreeView = (TreeView)sender;
            TreeNode MyNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));
            if (MyNode != null)
            {
                //改变进入节点的背景色               
                //MyNode.BackColor = Color.Blue;
                //保存此节点，进入下一个时还原背景色                
                MyOldNode = MyNode;
            }
        }

        void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            BaseNode MyNode = ((TreeNode)e.Data.GetData(typeof(TreeNode))).Tag as BaseNode;
            TreeView MyTreeView = (TreeView)sender;            
            //得到当前鼠标进入的节点            
            FolderNode MyTargetNode = MyTreeView.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y))).Tag as FolderNode;
            //类型错误，需要在加载时更正为workflowset
            if (MyTargetNode != null)            
            {
                if (!MyTargetNode.IsFolder)
                    return;

                if (!MyTargetNode.CanCapture(MyNode))
                {
                    MessageBox.Show("不接受该类型节点");
                    return;
                }

                MyTargetNode.CaptureIO(MyNode);

                MyNode.OnDeleteSelf();

                var rslt = MyTargetNode.CaptureMovedNode(MyNode);

                if (!rslt)
                {
                    MessageBox.Show("移动失败");
                    return;
                }

                //BaseNode MyTargetParent = MyTargetNode.Parent;                
                //删除拖放的节点                
                //MyNode.TreeNode.Remove();               
                
                //添加到目标节点                
                //MyTargetNode.Children.Add(MyNode);                
                
                MyTargetNode.TreeNode.BackColor = Color.White;               
                MyTreeView.SelectedNode = MyTargetNode.TreeNode;           
            }       
        }        
        //保存前一个鼠标进入的节点        
        private TreeNode MyOldNode; 
        
        bool receiver_OnOpenFile(string file)
        {
            //var model = GlobalService.ModelManager.MakeSureModel(file);
            //if ( model != null )
            //{
            //DocumentViewManager.Instance().
            return false;
        }

        bool receiver_OnNewNullProject()
        {
            var dlg = new CreatePorjectFrm();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //建立工程树形结构
                var root = NodeFactory.Create(Dict.NodeType.Project, GlobalService.CurrentPrj_Name, GlobalService.CurrentPrj_Name);

                NodeFactory.Create(Dict.NodeType.XmlModelSet).Parent = root;
                NodeFactory.Create(Dict.NodeType.DataModelSet).Parent = root;
                NodeFactory.Create(Dict.NodeType.DataViewSet).Parent = root;
                NodeFactory.Create(Dict.NodeType.ViewModelSet).Parent = root;
                NodeFactory.Create(Dict.NodeType.WorkFlowSet).Parent = root;

                foreach (var node in root.Children)
                {
                    var folderNode = node as FolderNode;
                    if (folderNode == null)
                        continue;

                    folderNode.Path = Path.Combine(GlobalService.CurrentPrj_Dir, node.Name);
                }

                this.treeView1.Nodes.Add(root.TreeNode);
                root.Save();

                this.treeView1.ExpandAll();
            }

            return false;
        }


        void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseNode node = e.Node.Tag as BaseNode;

            if (node != null)
            {
                node.OnDoubleClick();
            }

        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            BaseNode node = e.Node.Tag as BaseNode;

            DBGlobalService.DbType = DatabaseType.UnKnown;

            while (node != null)
            {
                if (node is ConnectionNode)
                {
                    DBGlobalService.ConnectionString = ((ConnectionNode)node).ConncetionString;
                    DBGlobalService.DbType = ((ConnectionNode)node).DbType;
                    DBGlobalService.DbContexUsingClause = ((ConnectionNode)node).DbContexUsingClause;
                    DBGlobalService.UseAutoMapper = ((ConnectionNode)node).UseAutoMapper;
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
                    var cmd = CommandHostManager.Instance().Get<PropertySelectCommand>(CommandHostManager.HostType.Common, Dict.Commands.PropertySelect);
                    cmd.SelectedObj = node;
                    cmd.Execute();
                    //CommandHostManager.Instance().Run(CommandHostManager.HostType.Common, Dict.Commands.PropertySelect);
                    //this.Receiver.PropertySelect(node);
                }
            }
        }

        bool receiver_OnOpenProject(string prj)
        {
            OpenPrject();

            return true;
        }

        bool receiver_OnOpenNullProject()
        {
            OpenPrject();

            return true;
        }

        private void OpenPrject()
        {
            //建立工程树形结构
            var root = NodeFactory.Create(Dict.NodeType.Project, GlobalService.CurrentPrj_Name, GlobalService.CurrentPrj_Name);
            root.Text += "(设计阶段)";
            //mDesignNode = new DesignProjectNode();
            //mDataBaseNode = new DBProjectNode();

            //mDesignNode.Parent = root;

            NodeFactory.Create(Dict.NodeType.XmlModelSet).Parent = root;
            NodeFactory.Create(Dict.NodeType.DataModelSet).Parent = root;
            //NodeFactory.Create(Dict.NodeType.DataViewSet).Parent = root;
            //NodeFactory.Create(Dict.NodeType.ViewModelSet).Parent = root;
            //NodeFactory.Create(Dict.NodeType.WorkFlowSet).Parent = root;

            foreach (var node in root.Children)
            {
                var folderNode = node as FolderNode;
                if (folderNode == null)
                    continue;

                folderNode.Path = Path.Combine(GlobalService.CurrentPrj_Dir, node.Name);
            }

            root.Load();

            //mDataBaseNode.Load();
            
            this.treeView1.Nodes.Add(root.TreeNode);
            
            LoadDB();

            DBGlobalService.SaveProject += new DBGlobalService.SaveDelegate(DBGlobalService_SaveProject);

            root.TreeNode.Expand();

            //this.mDesignNode.TreeNode.Expand();
            //this.mDataBaseNode.TreeNode.Expand();

            //this.Listeners.ForEach(
            //    x => x.OpenProject(Path.Combine(GlobalService.CurrentPrj_Dir)));
        }

        ReceiverBase receiver = new ReceiverBase();

        void DBGlobalService_SaveProject()
        {
            try
            {
                var db = this.treeView1.Nodes[1].Tag as DBProjectNode;
                db.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败:" + ex.Message);
            }
        }

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        #region 数据库管理

        private void LoadDB()
        {
            string selectDir = GlobalService.CurrentPrj_Dir;
            string projectName = GlobalService.CurrentPrj_Name;

            string path = System.IO.Path.Combine(selectDir, "");

            DBGlobalService.ProjectFile = System.IO.Path.Combine(path, projectName + ".xml");
            var doc = new Document();
            ProjectType prj = null;
            if (!System.IO.File.Exists(DBGlobalService.ProjectFile))
            {
                var stream = System.IO.File.Create(DBGlobalService.ProjectFile);
                stream.Close();
                prj = doc.CreateNode<ProjectType>();
            }
            else
            {
                doc.Load(DBGlobalService.ProjectFile);
                prj = new ProjectType(doc);
            }
            
            DBGlobalService.CurrentProjectDoc = doc;
    
            DBGlobalService.CurrentProject = prj;
            DBGlobalService.CurrentProject.Name = projectName;

            doc.Save(DBGlobalService.ProjectFile);

            this.CreateDBTree();
        }

        private void CreateDBTree()
        {
            this.treeView1.BeginUpdate();
            DBProjectNode projNode = new DBProjectNode();
            projNode.DataInfo = DBGlobalService.CurrentProject;
            //this.mDataBaseNode = projNode;
            projNode.Text += "(持久阶段)";
            projNode.TreeNode.Expand();

            this.treeView1.Nodes.Add(projNode.TreeNode);

            foreach (var child in projNode.Children)
                child.TreeNode.Expand();

            TreeEventSource eventSource = new TreeEventSource(projNode);
            eventSource.Refresh += new RefreshDelegate(eventSource_Refresh);
            eventSource.Generate += new GenerateDelegate(eventSource_Generate);
            this.treeView1.EndUpdate();
        }

        void eventSource_Generate(BaseNode node, StringBuilder builder)
        {
            var frm = new ShowCodeFrm();
            frm.SetText(builder.ToString());
            frm.ShowDialog();
            //this.panelOutput.Controls.Clear();
            ////this.panelWorkArea.Controls.Remove(this.textEditor);
            //this.textEditor = new TextEditorControl();
            //this.textEditor.Dock = DockStyle.Fill;
            //this.panelOutput.Controls.Add(this.textEditor);
            //this.textEditor.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            ////this.textEditor.Document.Remove(0, this.textEditor.Document.TextLength);
            ////this.textEditor.Validate();
            ////this.textEditor.Update();
            ////this.textEditor.ActiveTextAreaControl.TextArea.Update();
            //this.textEditor.Document.TextContent = builder.ToString();
            ////this.textEditor.Text = builder.ToString();
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
        #endregion

        public DBGlobalService.SaveDelegate GlobalService_SaveProject { get; set; }

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPanel));
        //    this.SuspendLayout();
        //    // 
        //    // ProjectPanel
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.Name = "ProjectPanel";
        //    this.ResumeLayout(false);

        //}
    }
}
