using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.UI;
using System.Windows.Forms;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;
using CodeHelper.Commands.XmlModel;

namespace CodeHelper.Items.XmlModel
{
    class XmlModelSetNode : FolderNode
    {
        public XmlModelSetNode()
            : base("XmlModel", "XmlModel")
        {
            
        }

        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "XmlModel");

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


            menu.MenuItems.Add("新建XML模型", this.OnNewDataModel);


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
           
            var fileName = System.IO.Path.Combine(this.Path, newName) + Dict.Extenstions.XmlModel_Extension;
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataModel = new XmlModelNode();

            dataModel.Parent = this;

            dataModel.FileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.Name = dataModel.Text = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.XmlMode);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewXmlModel)
                as NewXmlModelCommand;

            cmd.File = dataModel.FullName;

            cmdHost.RunCommand(Dict.Commands.NewXmlModel);
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
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "XmlModel");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //var directory = new DirectoryInfo(dir);
            //foreach (var dm in directory.GetFiles("*.xm"))
            //{
            //    var dmNode = new XmlModelNode();
            //    dmNode.FullName = dm.FullName;
            //    dmNode.Parent = this;
            //}
            base.Load();
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.XmlModelSet;
            }
        }

        protected override void LoadFile()
        {
            //var dir = new DirectoryInfo(this.Path);

            //foreach (var f in dir.GetFiles())
            //{
            //    if (f.Extension == Dict.Extenstion.XmlModel_Extension)
            //    {
            //        var file_node = NodeFactory.Create(Dict.NodeType.XmlModel, f.Name, f.Name);
            //        file_node.Parent = this;
            //    }
            //}

            var directory = new DirectoryInfo(Path);

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.XmlModel_Extension))
            {
                var dmNode = new XmlModelNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }
        }
    }
}

