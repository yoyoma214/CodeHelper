using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;
using CodeHelper.UI;

namespace CodeHelper.Items.DataModel
{
    class DataModelSetNode : FolderNode
    {
        public DataModelSetNode():base("DataModel","DataModel")
        {
                     
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            this.EnableEdit = false;

            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新建数据模型", this.OnNewDataModel);
       

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

            var fileName = System.IO.Path.Combine(this.Path, newName) + ".dm";
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();
            
            var dataModel = new DataModelNode();

            dataModel.Parent = this;
            dataModel.Text = dataModel.Name = newName;
            dataModel.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.DataModel);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewDataModel)
                as NewDataModelCommand;

            cmd.File = dataModel.FullName;
            dataModel.FileId = Guid.NewGuid();

            cmdHost.RunCommand(Dict.Commands.NewDataModel);
        }

        //public override bool IsFolder
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}

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

        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "DataModel");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Save();
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "DataModel");

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
                return Dict.NodeType.DataModelSet;
            }
        }

        protected override void LoadFile()
        {
            var directory = new DirectoryInfo(Path);

            foreach (var dm in directory.GetFiles( "*" + Dict.Extenstions.DataModel_Extension))
            {
                var dmNode = new DataModelNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }

            base.LoadFile();
        }
    }
}
