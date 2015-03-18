using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataView;
using ICSharpCode.TextEditor;
using CodeHelper.Domain.Model;
using CodeHelper.Common;
using CodeHelper.UI;
using CodeHelper.Core.Parse.ParseResults.DataModels;

namespace CodeHelper.Items.DataView
{
    class DataViewNode : ModelNode
    {
        TextEditorControl textEditor = null;

        public override System.Windows.Forms.Control GetEditor()
        {
            //return base.GetEditor();
            if (textEditor == null)
                textEditor = new TextEditorControl();

            return textEditor;
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.DataView;
            }
        }

        public override string FileName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.FullName))
                {
                    return "";
                }

                return System.IO.Path.GetFileName(this.FullName);
            }
        } 

        public override string Extension
        {
            get { return Dict.Extenstions.DataView_Extension; }
            set { }
        }        

        public override void Load()
        {
            this.Name = Path.GetFileNameWithoutExtension(this.FullName);

            base.Load();
        }

        public override void OnDoubleClick()
        {
            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.DataView);
            var cmd = cmdHost.GetCommand(Dict.Commands.OpenDataView)
                as OpenDataViewCommand;

            cmd.File = this.FullName;

            cmdHost.RunCommand(Dict.Commands.OpenDataView);

            base.OnDoubleClick();
        }
    }
}
