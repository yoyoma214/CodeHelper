using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.UI;
using System.Windows.Forms;
using CodeHelper.Core.Command;
using CodeHelper.Commands.WorkFlow;
using CodeHelper.Common;

namespace CodeHelper.Items.WorkFlow
{
    class WorkFlowSetNode : FolderNode
    {
        public WorkFlowSetNode()
            : base("WorkFlow", "WorkFlow")
        {
         
        }

        public override string NameSpace
        {
            get
            {
                if (this.Parent is DesignProjectNode)
                {
                    return "";
                }
                return base.NameSpace;
            }
        }

        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "WorkFlow");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Save();
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            this.EnableEdit = false;

            var menu = base.GetPopMenu();


            menu.MenuItems.Add("新建Workflow模型", this.OnNewDataModel);


            return menu;
        }
        protected void OnNewDataModel(object sender, EventArgs args)
        {
            var dlg = new NewFrm();

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var newName = dlg.GetName();
            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("名称不能为空");
                return;
            }

            var fileName = System.IO.Path.Combine(this.Path, newName) + Dict.Extenstions.WorkFlow_Extension;
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataModel = new WorkFlowNode();

            dataModel.Parent = this;

            dataModel.FileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.Name = dataModel.Text = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.WorkFlow);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewWorkFlow)
                as NewWorkFlowCommand;

            cmd.File = dataModel.FullName;

            cmdHost.RunCommand(Dict.Commands.NewWorkFlow);
        }

        public override void OnDoubleClick()
        {
            if (this.TreeNode.IsExpanded)
            {
                this.TreeNode.ExpandAll();
            }
            else
            {
                this.TreeNode.Collapse();
            }

            base.OnDoubleClick();
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "WorkFlow");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            base.Load();
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.WorkFlowSet;
            }
        }

        protected override void LoadFile()
        {
            var directory = new DirectoryInfo(Path);

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.WorkFlow_Extension))
            {
                var dmNode = new WorkFlowNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }
        }

        public override bool CanCapture(BaseNode node)
        {
            if (node.NodeType != Dict.NodeType.WorkFlow && node.NodeType != Dict.NodeType.WorkFlowSet)
            {
                return false;
            }

            return true;
        }

        public override void CaptureIO(BaseNode node)
        {
            if (node.NodeType == Dict.NodeType.WorkFlow)
            {
                var wf = node as WorkFlowNode;
                var oldFile = wf.FullName;
                var fullName = System.IO.Path.Combine(this.Path, System.IO.Path.GetFileName(wf.FullName));
                System.IO.File.Move(oldFile, fullName);
            }
            else if (node.NodeType == Dict.NodeType.WorkFlowSet)
            {
                var folder = node as FolderNode;
                var oldFolder = folder.Path;
                var path = System.IO.Path.Combine(this.Path, folder.Name);
                System.IO.Directory.Move(oldFolder, path);
            }
        }                

        public override bool CaptureMovedNode(BaseNode node)
        {                 
            this.Children.Add(node);

            this.Save();

            return true;
        }
    }
}

