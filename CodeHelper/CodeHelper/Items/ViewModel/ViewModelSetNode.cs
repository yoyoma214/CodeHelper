using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.UI;
using System.Windows.Forms;
using CodeHelper.Core.Command;
using CodeHelper.Commands.ViewModel;

namespace CodeHelper.Items.ViewModel
{
    class ViewModelSetNode : FolderNode
    {
        public ViewModelSetNode()
            : base("ViewModel", "ViewModel")
        {
            
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "ViewModel");

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

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.ViewModel_Extension))
            {
                var dmNode = new ViewModelNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }
        }
        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "ViewModel");

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


            menu.MenuItems.Add("新建View模型", this.OnNewViewModel);


            return menu;
        }

        protected void OnNewViewModel(object sender, EventArgs args)
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

            var fileName = System.IO.Path.Combine(this.Path, newName) + Dict.Extenstions.ViewModel_Extension;
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataModel = new ViewModelNode();

            dataModel.Parent = this;

            dataModel.FileName = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.Name = dataModel.Text = System.IO.Path.GetFileNameWithoutExtension(fileName);
            dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmd = CommandHostManager.Instance().Get<NewViewModelCommand>
                (CommandHostManager.HostType.ViewModel, Dict.Commands.NewViewModel);

            cmd.File = dataModel.FullName;

            cmd.Execute();

            //cmdHost.RunCommand(Dict.Commands.NewXmlModel);
        }
    }
}
