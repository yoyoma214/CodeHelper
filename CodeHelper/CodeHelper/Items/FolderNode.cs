using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using CodeHelper.Common;

namespace CodeHelper.Items
{
    public class FolderNode : BaseNode
    {
        public override string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Path))
                {
                    return System.IO.Path.GetFileNameWithoutExtension(this.Path);
                }

                return base.Name;
            }
            set
            {
                base.Name = value;

                if (!string.IsNullOrWhiteSpace(this.Path))
                {
                    this.Path = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(this.Path), value);
                }
            }
        }

        public virtual string NameSpace
        {
            get
            {
                var ns = this.Name;
                if (this.Parent is FolderNode)
                {
                    var t = ((FolderNode)this.Parent).NameSpace;
                    if ( !string.IsNullOrWhiteSpace(t))
                        ns = t + "." + ns;
                }
                return ns;
            }
        }

        public override string Text
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Name))
                    return Name;

                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        protected override bool EnableDelete
        {
            get
            {
                if ( (this.Parent as FolderNode) == null)
                {
                    return false;

                }
                return base.EnableDelete;
            }
            set
            {
                base.EnableDelete = value;
            }
        }

        protected override bool EnableRename
        {
            get
            {
                if ((this.Parent as FolderNode) == null)
                {
                    return false;

                }
                return base.EnableRename;
            }
            set
            {
                base.EnableRename = value;
            }
        }

        protected override bool EnableEdit
        {
            get
            {
                if ((this.Parent as FolderNode) == null)
                {
                    return false;

                }
                return base.EnableEdit;
            }
            set
            {
                base.EnableEdit = value;
            }
        }

        public FolderNode()
            : base("Folder", "Folder")
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "129";            
        }

        public FolderNode(string name, string text)
            : base(name, text)
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "129";   
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();
            menu.MenuItems.Add("新建文件夹", this.OnNewFolder);
            menu.MenuItems.Add("-");
            menu.MenuItems.Add("在Windows资源管理器中打开文件夹", this.OnOpenFolder);
            menu.MenuItems.Add("-");
            return menu;
        }

        string path = null;

        public string Path
        {
            get
            {
                //if (this.path == null )
                //    return GlobalService
                return path;
            }
            internal set
            {
                path = value;
            }
        }

        protected void OnNewFolder(object sender, EventArgs args)
        {
            var s = "新建文件夹";

            var list = this.Children.Where(x => x.IsFolder);

            var newFolderList = list.Where(x => x.Name.StartsWith(s)).ToList();

            int? maxIndex = null;

            int? nodeIndex = null;

            newFolderList.ForEach(x =>
            {
                int index = 0;

                if (int.TryParse(x.Name.Replace(s, ""), out index))
                {
                    maxIndex = maxIndex > index ? maxIndex : index;
                    nodeIndex = x.Index;
                }
            });

            maxIndex = maxIndex ?? 0;

            var name = s + (maxIndex++);

            var newFolder = NodeFactory.Create(this.NodeType, s, s) as FolderNode;

            newFolder.Name = newFolder.Text = s + (maxIndex++);

            newFolder.Path = System.IO.Path.Combine(this.Path,newFolder.Name);

            if (!Directory.Exists(newFolder.Path))
            {
                Directory.CreateDirectory(newFolder.Path);
            }            

            this.Children.Insert((nodeIndex.HasValue ? nodeIndex.Value + 1 : 0), newFolder);

            this.TreeNode.Expand();
            
        }

        protected void OnOpenFolder(object sender, EventArgs args)
        {
            var psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e," + this.Path;
            System.Diagnostics.Process.Start(psi);

        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            BaseNode parent = this.Parent;

            OnDeleteSelf();
            
            this.Parent = null;
            
        }

        internal override void OnDeleteSelf()
        {
            base.OnDeleteSelf();

            if ( Directory.Exists(this.Path ))
            {
                Directory.Delete(this.Path);
            }
        }

        protected override void OnRename(object sender , EventArgs args)
        {
            string oldPath = this.Path;

            base.OnRename(sender, args);
            this.Path = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(this.Path) , this.Name );

            string newPath = this.Path;

            if (oldPath != newPath)
            {
                OnRenameSelf(oldPath, newPath);
            }
        }

        internal override void OnRenameSelf(string oldPath, string newPath)
        {
            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
            }

            base.OnRenameSelf(oldPath, newPath);
        }

        public override void Load()
        {            
            if (Directory.Exists(this.Path))
            {
                var dir = new DirectoryInfo(this.Path);

                foreach (var d in dir.GetDirectories())
                {
                    var dir_node = NodeFactory.Create(this.NodeType, d.Name, d.Name) as FolderNode;
                    dir_node.Path = d.FullName;
                    
                    dir_node.Parent = this;
                }

                this.LoadFile();
            }

            base.Load();
        }

        protected virtual void LoadFile()
        {

        }

        public virtual bool CanCapture(BaseNode node)
        {
            return false;
        }

        public virtual void CaptureIO(BaseNode node)
        {
        }

        public virtual bool CaptureMovedNode(BaseNode node)
        {
            return true;
        }

        public override bool IsFolder
        {
            get
            {
                return true;
            }
        }
        //protected virtual void LoadFile()
        //{
        //    //var dir = new DirectoryInfo(this.Path);
         
        //    //foreach (var f in dir.GetFiles())
        //    //{
        //    //    //var file_node = NodeFactory
        //    //}
        //}
    }
}
