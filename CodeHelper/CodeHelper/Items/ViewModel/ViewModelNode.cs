using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using CodeHelper.Core.Command;
using CodeHelper.Commands.ViewModel;
using System.IO;
using CodeHelper.UI;
using CodeHelper.Domain.Model;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using CodeHelper.Common;

namespace CodeHelper.Items.ViewModel
{
    class ViewModelNode : ModelNode
    {
        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.ViewModel;
            }
        }

        public ViewModelNode():base()
        {
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();
            menu.MenuItems.Add("验证语句", ValidateModel);
            menu.MenuItems.Add("生成页面代码", GenViewCode);
            return menu;
        }

        private void ValidateModel(object sender , EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            var builder = new IndentStringBuilder();
            ((ViewModelDB)module).Render(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void GenViewCode(object sender, EventArgs args)
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
            ((ViewModelDB)module).RenderView(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }
        

        public override string Extension
        {
            get { return Dict.Extenstions.ViewModel_Extension; }
            set { }
        }

        public override void Load()
        {
            this.Name = Path.GetFileNameWithoutExtension(this.FullName);

            base.Load();
        }

        public override void OnDoubleClick()
        {
            var cmd = CommandHostManager.Instance().Get<OpenViewModelCommand>(
                CommandHostManager.HostType.ViewModel,Dict.Commands.OpenViewModel);
            
            cmd.File = this.FullName;

            cmd.Execute();

            base.OnDoubleClick();
        }
    }
}
