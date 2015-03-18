using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Repository;
using System.ComponentModel;
using CodeHelper.DataBaseHelper.UI.PropertyGrids;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.Services
{
    class ServiceFolderNode : BaseNode
    {
        public ServiceFolderNode()
            : base()
        {
            this.Text = "服务";
            this.Name = "服务";           
        }

        //private string connectionString = null;
        [TypeConverter(typeof(MyConverter)), ConnectionListAttribute()] 
        public string ConnectionString
        {
            get
            {
                if (this.ServiceFolder != null)
                    return this.serviceFolder.ConnectionString;
                return "";
                //return this.connectionString;
            }
            set
            {
                //this.connectionString = value;
                if (serviceFolder != null)
                {
                    serviceFolder.ConnectionString = value;
                }
            }
        }

        //[ReadOnly(true)]
        public override string Name
        {
            get
            {
                if (this.ServiceFolder != null)
                {
                    return this.ServiceFolder.Name;
                }
                return base.Name;
            }
            set
            {
                base.Name = value;
                if (this.ServiceFolder != null)
                {
                    this.ServiceFolder.Name = value;
                }
            }
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();

            menu.MenuItems.Add("新增文件夹", OnNewFolder);
            menu.MenuItems.Add("新增服务", OnNewService);
            
            return menu;
        }

        ServiceFolder serviceFolder = null;
        internal ServiceFolder ServiceFolder
        {
            get
            {
                return serviceFolder;
            }
            set
            {
                serviceFolder = value;

                foreach (var folder in this.serviceFolder.ServiceFolders)
                {
                    var folderNode = new ServiceFolderNode();
                    folderNode.ServiceFolder = folder;
                    this.Children.Add(folderNode);
                }
                foreach (var service in this.serviceFolder.Services)
                {
                    var serviceNode = new ServiceNode();
                    serviceNode.Service = service;
                    this.Children.Add(serviceNode);
                }

                this.Name = this.Text = value.Name;
            }
        }

        protected virtual void OnNewFolder(object sender, EventArgs args)
        {
            var srvNode = new ServiceFolderNode();

            var service = serviceFolder.CreateServiceFolder();
            service.Name = "NewFolder" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");
            srvNode.ServiceFolder = service;
            this.serviceFolder.ServiceFolders.AddChild(service);
            this.Children.Add(srvNode);

            this.TreeNode.Expand();
        }

        protected virtual void OnNewService(object sender, EventArgs args)
        {
            var srvNode = new ServiceNode();
            
            var service = serviceFolder.CreateService();
            service.Name = "NewService" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:sss");            
            srvNode.Service = service;
            this.serviceFolder.Services.AddChild(service);
            this.Children.Add(srvNode);

            this.TreeNode.Expand();
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);

            this.ServiceFolder.RemoveSelf();
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
