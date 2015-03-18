using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using CodeHelper.Core.Command;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Commands.DataModel;
using System.IO;
using CodeHelper.Core.Services;
using CodeHelper.UI;
using CodeHelper.Domain.Model;
using CodeHelper.Common;
using CodeHelper.Core.Parse.ParseResults.DataModels;

namespace CodeHelper.Items.DataModel
{
    public class DataModelNode : ModelNode
    {
        TextEditorControl textEditor = null;

        public override System.Windows.Forms.Control GetEditor()
        {
            //return base.GetEditor();
            if (textEditor == null)
                textEditor = new TextEditorControl();
            
            return textEditor;
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menus = base.GetPopMenu();
            menus.MenuItems.Add("生成数据库代码", Mnu_GenerateDBCode);
            return menus;
        }

        private void Mnu_GenerateDBCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);
            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            var builder = new IndentStringBuilder();
            //module.NameSpace = ns;
            ((DmModelDB)module).RenderSql(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        public override void OnDoubleClick()
        {
            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.DataModel);
            var cmd = cmdHost.GetCommand(Dict.Commands.OpenDataModel)
                as OpenDataModelCommand;

            cmd.File = this.FullName;

            cmdHost.RunCommand(Dict.Commands.OpenDataModel);

            base.OnDoubleClick();
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
            get { return Dict.Extenstions.DataModel_Extension; }
            set { }
        }        

        public override void Save()
        {
            base.Save();
        }

        public override void Load()
        {
            this.Name = Path.GetFileNameWithoutExtension(this.FullName);
            base.Load();
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.DataModel;
            }
        }

 
    }
}
