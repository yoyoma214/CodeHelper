using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Repository;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.Forms
{
    class FormFolderNode : BaseNode
    {
        public FormFolderNode()
            : base()
        {
            this.Name = this.Text = "表单";
        }
        public override string Name
        {
            get
            {
                if (this.FormFolder != null)
                {
                    return this.FormFolder.Name;
                }
                return base.Name;
            }
            set
            {
                //base.Name = value;
                //this.Text = value;
                base.Name = value;
                if (this.FormFolder != null)
                {
                    this.FormFolder.Name = value;
                }
            }
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新增文件夹", OnNewFolder);
            menu.MenuItems.Add("新增表单", OnNewFormView);

            return menu;
        }

        public override string Text
        {
            get
            {
                if (this.formFolder != null)
                    return this.formFolder.Name;

                return base.Text;
            }
            set
            {
               
            }
        }
        FormViewFolder formFolder = null;
        internal FormViewFolder FormFolder
        {
            get
            {
                return formFolder;
            }
            set
            {
                formFolder = value;

                foreach (var folder in this.formFolder.FormViewFolders)
                {
                    var folderNode = new FormFolderNode();
                    folderNode.formFolder = folder;
                    this.Children.Add(folderNode);
                }
                foreach (var formView in this.formFolder.FormViews)
                {
                    var serviceNode = new FormNode();
                    serviceNode.FormView = formView;
                    this.Children.Add(serviceNode);
                }

                this.Text = this.Name = value.Name;
            }
        }

        protected virtual void OnNewFolder(object sender, EventArgs args)
        {
            var srvNode = new FormFolderNode();

            var folder = formFolder.CreateFormViewFolder();
            folder.Name = "NewFolder" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            srvNode.formFolder = folder;
            this.formFolder.FormViewFolders.AddChild(folder);
            this.Children.Add(srvNode);
            srvNode.Text = srvNode.Name = folder.Name;
            this.TreeNode.Expand();
        }

        protected virtual void OnNewFormView(object sender, EventArgs args)
        {
            var srvNode = new FormNode();

            var formView = formFolder.CreateFormView();
            formView.Name = "NewFormView" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            srvNode.FormView = formView;
            this.formFolder.FormViews.AddChild(formView);
            this.Children.Add(srvNode);

            this.TreeNode.Expand();
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);

            this.FormFolder.RemoveSelf();
        }
        public override void Save()
        {
            base.Save();
            //foreach (var child in this.Children)
            //{
            //    child.Save();
            //    if (child is ServiceFolderNode)
            //    {                    
            //    }
            //}
        }
    }
}
