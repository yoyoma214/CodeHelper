using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.UI;
using CodeHelper.Core.Services;
using CodeHelper.Items;
using CodeHelper.Core.Command;
using CodeHelper.Items.DataModel;
using System.IO;
using CodeHelper.AssembleLayer;
using CodeHelper.Commands.DataModel;
using CodeHelper.Commands.XmlModel;
using CodeHelper.Core.Error;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Domain.Model;
using CodeHelper.Core.Infrastructure.Model;
using System.Threading;
//using CodeHelper.UI.Controls;
using System.Diagnostics;
using CodeHelper.UI.DockPanels;
using WeifenLuo.WinFormsUI.Docking;
using CodeHelper.Core.Infrastructure.Command;

namespace CodeHelper
{
    public partial class MainFrm : Form
    {
        private WorkSpace Workspace = new WorkSpace();
        private DeserializeDockContent m_deserializeDockContent;

        ProjectPanel m_prjPanel = new ProjectPanel();
        ErrorPanel m_errorPanel = new ErrorPanel();
        PropertyPanel m_propertyPanel = new PropertyPanel();
        //FileTabPanel m_tabsPanel = new FileTabPanel();       

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(ErrorPanel).ToString())
            {
                return this.m_errorPanel;
            }
            if (persistString == typeof(ProjectPanel).ToString())
            {
                return this.m_prjPanel;
            }
            if (persistString == typeof(PropertyPanel).ToString())
            {
                return this.m_propertyPanel;
            }

            string[] strArray = persistString.Split(new char[] { ',' });
            if (strArray.Length != 3)
            {
                return null;
            }
            if (strArray[0] != typeof(FileTabPanel).ToString())
            {
                return null;
            }
            var doc = new FileTabPanel();
            if (strArray[1] != string.Empty)
            {
                doc.FileName = strArray[1];
            }
            if (strArray[2] != string.Empty)
            {
                doc.Text = strArray[2];
            }

            //DocumentViewManager.Instance().AddView(doc);

            this.receiver.LoadFile(doc.FileName);

            return DocumentViewManager.Instance().GetView(doc.FileName);
            //var ctx = Assemble.CreateEditor(doc.FileName);

            //doc.Tag = ctx.Model.FileId;

            //return doc;
        }

        void MainFrm_Load(object sender, EventArgs e)
        {
            GlobalService.UserId = System.Configuration.ConfigurationManager.AppSettings["CoreId"];

            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(path))
            {
                try
                {
                    this.m_workspace.LoadFromXml(path, this.m_deserializeDockContent);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                this.m_errorPanel = new ErrorPanel();
                this.m_prjPanel = new ProjectPanel();
                this.m_propertyPanel = new PropertyPanel();
                //this.m_tabsPanel = new TabsPanel();

                m_prjPanel.Show(this.m_workspace, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
                m_errorPanel.Show(this.m_workspace, DockState.DockBottom);
                m_propertyPanel.Show(this.m_workspace, DockState.DockRight);
                //var f = new FileTabPanel();
                //f.TabText = "1.dm";
                //f.Show(this.m_workspace, DockState.Document);
            }

            this.Init();
        }

        void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), 
                "DockPanel.config");

            //保留在2秒内关掉的文档（视为关闭工程时）在config文件中
            foreach (var docView in this.m_workspace.Documents)
            {
                var fileView = docView as FileTabPanel;

                if (fileView == null)
                    continue;

                if (!fileView.CloseTime.HasValue || fileView.CloseTime >  DateTime.Now.AddSeconds(2))
                {
                    fileView.Close();
                    continue;
                }
            }


            this.m_workspace.SaveAsXml(fileName);
            
            var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
            var cmd = cmdHost_common.GetCommand(Dict.Commands.ExitProcess);
            cmd.Execute();

        }

        void InitIcon()
        {
            var dir = new DirectoryInfo(@"Images\Bonus\ICO\");
            //this.treeView1.ImageList = new ImageList();

            foreach(var icon in dir.GetFiles("*.ico"))
            {
                GlobalService.Icons.Images.Add(Path.GetFileNameWithoutExtension(icon.Name), Image.FromFile(icon.FullName));
                //this.treeView1.ImageList.Images.Add(Path.GetFileNameWithoutExtension(icon.Name), Image.FromFile(icon.FullName));
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if ( DateTime.Now.Millisecond % 10 == 1 )
                GlobalService.GoIdle(sender, e);
        }
        

        private void mnuNewProject_Click(object sender, EventArgs e)
        {
            this.receiver.NewProject();            
        }

        private void mnuOpenProject_Click(object sender, EventArgs e)
        {
            var dlg = new OpenProjectFrm();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.receiver.OpenProject();
            }
        }
         

        private void mnuSave_Click(object sender, EventArgs e)
        {
            if (GlobalService.EditorContextManager.CurrentContext == null)
                return;

            if (GlobalService.EditorContextManager.CurrentContext.Model.Modifed == false)
                return;

            GlobalService.EditorContextManager.CurrentContext.Controller.SaveFile();
        }

        private void mnuSaveAll_Click(object sender, EventArgs e)
        {
            CodeHelper.DataBaseHelper.DBGlobalService.Save();
        }            
    }
}
