using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Services;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;
using System.Diagnostics;

namespace CodeHelper.Items
{
    public class ModelNode : BaseNode, IFile
    {
        public ModelNode()
            : base("Model", "Model")
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "001";            
        }

        public ModelNode(string name, string text)
            : base(name, text)
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "001";   
        }

        public Guid? FileId
        {
            get;
            set;
        }

        public virtual string FileName { get; set; }

        public virtual string NameSpace { get; set; }

        public virtual string Extension
        {
            get { return "unknown"; }
            set { }
        }

        string fullName = null;

        public string FullName
        {
            get
            {
                //if (this.FileId.HasValue)
                //{
                //    var model = GlobalService.ModelManager.GetModel(this.FileId.Value);
                //    Debug.Assert(model == this);
                //    return model.File
                //}
                return fullName;
            }
            set
            {
                fullName = value;
            }
        }

        public virtual void Open()
        {

        }

        public virtual void Close()
        {

        }

        public override void Load()
        {
            this.Name = Path.GetFileNameWithoutExtension(this.FullName);
            this.FileName = Path.GetFileName(this.FullName);
            base.Load();

            
            var model = GlobalService.ModelManager.MakeSureModel(this.FullName);
            this.FileId = model.FileId;
        }

        protected override void OnRename(object sender, EventArgs args)
        {
            //var cmdHost = CommandHostManager.Instance().Get(
            //  CommandHostManager.HostType.Common);
            //var cmd = cmdHost.GetCommand(BaseCommand.RenameModel)
            //    as RenameModelCommand;

            var model = GlobalService.ModelManager.MakeSureModel(this.FullName);

            var oldName = this.FullName;

            base.OnRename(sender, args);

            this.FullName = this.FullName.Replace(this.FileName, this.Name + Extension);
            var newName = this.FullName;
            if (oldName != newName)
            {
                //cmdHost.RunCommand(BaseCommand.RenameModel);

                OnRenameSelf(oldName, newName);
            }
        }

        internal override void OnRenameSelf(string oldPath, string newPath)
        {
            this.FullName = this.FullName.Replace(oldPath, newPath);

            if ( this.FileId.HasValue)
            {
               var model = GlobalService.ModelManager.GetModel(this.FileId.Value);

               model.File = this.FullName;
            }

            var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
            if (cmdHost_common != null)
            {
                var cmd = cmdHost_common.GetCommand(Dict.Commands.RenameModel)
                as RenameModelCommand;

                cmd.OldName = System.IO.Path.Combine(oldPath , this.Name + this.Extension);
                cmd.NewName = System.IO.Path.Combine(newPath, this.Name + this.Extension);

                if (cmd.OldName != cmd.NewName)
                {
                    cmdHost_common.RunCommand(Dict.Commands.RenameModel);
                }
            }

            base.OnRenameSelf(oldPath, newPath);

            if (oldPath != newPath)
            {
                File.Move(oldPath, newPath);
            }
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);
        }

        internal override void OnDeleteSelf()
        {
            base.OnDeleteSelf();
                        
            GlobalService.ModelManager.Remove(this.FileId.Value);

            if (System.IO.File.Exists(this.fullName))
            {
                System.IO.File.Delete(this.fullName);
            }
        }

        public override void Save()
        {
            
        }
    }
}
