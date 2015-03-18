using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using System.Windows.Forms;
using CodeHelper.UI;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataView;

namespace CodeHelper.Items.DataView
{
    class DataViewSetNode : FolderNode
    {
        public DataViewSetNode()
            : base("DataView", "DataView")
        {
            
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            this.EnableEdit = false;

            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新建数据视图", this.OnNewDataView);

            return menu;
        }

        private void OnNewDataView(object sender, EventArgs args)
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

            var fileName = System.IO.Path.Combine(this.Path, newName) + Dict.Extenstions.DataView_Extension;
            if (File.Exists(fileName))
            {
                MessageBox.Show("文件已经存在");
                return;
            }

            var writer = File.CreateText(fileName);
            writer.Flush();
            writer.Close();

            var dataView = new DataViewNode();

            dataView.Parent = this;
            dataView.Text = dataView.Name = newName;
            dataView.FullName = fileName;

            this.TreeNode.Expand();

            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.DataView);
            var cmd = cmdHost.GetCommand(Dict.Commands.NewDataView)
                as NewDataViewCommand;

            cmd.File = dataView.FullName;

            cmdHost.RunCommand(Dict.Commands.NewDataView);
        }

        public override void Save()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "DataView");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Save();
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.DataViewSet;
            }
        }

        public override void Load()
        {
            var dir = System.IO.Path.Combine(GlobalService.CurrentPrj_Dir, "DataView");

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            base.Load();
        }

        protected override void LoadFile()
        {
         
            var directory = new DirectoryInfo(Path);

            foreach (var dm in directory.GetFiles("*" + Dict.Extenstions.DataView_Extension))
            {
                var dmNode = new DataViewNode();
                dmNode.FullName = dm.FullName;
                dmNode.Parent = this;
            }
        }
    }
}

