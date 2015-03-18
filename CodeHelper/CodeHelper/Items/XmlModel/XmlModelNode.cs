using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.Core.Command;
using CodeHelper.Commands.XmlModel;
using CodeHelper.Domain.Model;
using CodeHelper.UI;
using CodeHelper.GenerateUnit.XmlModels;
using CodeHelper.Core.Parse.ParseResults.XmlModels;

namespace CodeHelper.Items.XmlModel
{
    class XmlModelNode : ModelNode
    {
        public XmlModelNode()
            : base("XmlModel", "XmlModel")
        {
        }

        public XmlModelNode(string name,string text)
            : base(name, text)
        {
        }

        public override string Extension
        {
            get
            {
                return Dict.Extenstions.XmlModel_Extension;
            }
            set
            {
                base.Extension = value;
            }
        }
        
        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();
            menu.MenuItems.Add("生成DOM操作类", OnGenerateDomOperClass);
            menu.MenuItems.Add("生成DOM操作类(Silverlight)", OnGenerateSLDomOperClass);
            menu.MenuItems.Add("生成ConfigurationSection操作类", OnGenerateConfigurationSection);
            return menu;
        }

        private void OnGenerateDomOperClass(object sender, EventArgs args)
        {
            var m = ModelManager.Instance().MakeSureParseModule(this.FullName);

            if (m == null)
            {
                return;
                //ModelManager.Instance().MakeSureModel(this.FullName);
            }

            var dlg = new GenerateOutputFrm();
            var gen = new GenDomOperClass(m as XmModelDB);
            var sb = new StringBuilder();
            gen.Generate(sb);
            dlg.Content = sb.ToString();
            dlg.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dlg.Show();
        }

        private void OnGenerateSLDomOperClass(object sender, EventArgs args)
        {
            var m = ModelManager.Instance().MakeSureParseModule(this.FullName);

            if (m == null)
            {
                return;
                //ModelManager.Instance().MakeSureModel(this.FullName);
            }

            var dlg = new GenerateOutputFrm();
            var gen = new GenSLDomOperClass(m as XmModelDB);
            var sb = new StringBuilder();
            gen.Generate(sb);
            dlg.Content = sb.ToString();
            dlg.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dlg.Show();
        }

        private void OnGenerateConfigurationSection(object sender, EventArgs args)
        {
            var m = ModelManager.Instance().MakeSureParseModule(this.FullName);

            if (m == null)
            {
                return;
                //ModelManager.Instance().MakeSureModel(this.FullName);
            }

            var dlg = new GenerateOutputFrm();
            var gen = new GenerateConfigurationSection(m as XmModelDB);
            var sb = new StringBuilder();
            gen.Generate(sb);
            dlg.Content = sb.ToString();
            dlg.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dlg.Show();
        }

        public override void OnDoubleClick()
        {
            var cmdHost = CommandHostManager.Instance().Get(
                CommandHostManager.HostType.XmlMode);
            var cmd = cmdHost.GetCommand(Dict.Commands.OpenXmlModel)
                as OpenXmlModelCommand;

            cmd.File = this.FullName;

            cmdHost.RunCommand(Dict.Commands.OpenXmlModel);
            
            base.OnDoubleClick();
        }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.XmlModel;
            }
        }
    }
}
