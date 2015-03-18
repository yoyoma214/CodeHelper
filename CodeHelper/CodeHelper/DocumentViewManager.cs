using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;
using WeifenLuo.WinFormsUI.Docking;
using CodeHelper.AssembleLayer;
using System.Windows.Forms;
using System.IO;
using CodeHelper.UI.DockPanels;
using CodeHelper.Core.Services;
using CodeHelper.Core.Infrastructure.Model;
using System.Diagnostics;
using CodeHelper.Core.Command;
using CodeHelper.Commands.DataModel;

namespace CodeHelper
{
    class DocumentViewManager : IReceiverHolder
    {
        ReceiverBase m_receiver = new ReceiverBase();

        DockPanel m_documentViewContainer = null;

        List<FileTabPanel> m_documentViews = new List<FileTabPanel>();

        private DocumentViewManager() { }

        private static DocumentViewManager instance = new DocumentViewManager();

        public static void Init(DockPanel documentView)
        {
            instance.Initial(documentView);
        }

        internal void Initial(DockPanel documentView)
        {
            this.m_documentViewContainer = documentView;
            this.m_receiver.OnLoadFile += new ReceiverBase.LoadFileHandler(m_receiver_OnLoadFile);
            this.m_receiver.OnOpenFile += new ReceiverBase.OpenFileHandler(receiver_OnOpenFile);
            this.m_receiver.OnCloseFile += new ReceiverBase.OpenCloseFileHandler(m_receiver_OnCloseFile);

            this.m_documentViewContainer.ActiveContentChanged += new EventHandler(m_documentViewContainer_ActiveContentChanged);
            this.m_documentViewContainer.ActiveDocumentChanged += new EventHandler(m_documentViewContainer_ActiveDocumentChanged);
            this.m_documentViewContainer.ActivePaneChanged += new EventHandler(m_documentViewContainer_ActivePaneChanged);

            this.m_documentViewContainer.ContentRemoved += new EventHandler<DockContentEventArgs>(m_documentViewContainer_ContentRemoved);
            this.m_documentViewContainer.ControlRemoved += new ControlEventHandler(m_documentViewContainer_ControlRemoved);
        }

        void m_documentViewContainer_ControlRemoved(object sender, ControlEventArgs e)
        {
            
        }

        void m_documentViewContainer_ContentRemoved(object sender, DockContentEventArgs e)
        {
            
        }

        bool m_receiver_OnCloseFile(Guid fileId)
        {
            var docView = this.m_documentViews.FirstOrDefault(x => (Guid)x.Tag == fileId);
            if (docView != null)
            {
                this.m_documentViews.Remove(docView);
                //docView.Close();                
            }

            return false;
        }

        public static DocumentViewManager Instance()
        {
            return instance;
        }

        public void AddView(FileTabPanel docView)
        {
            //docView.HideOnClose = true;

            this.m_documentViews.Add(docView);

            docView.FormClosing += new FormClosingEventHandler(docView_FormClosing);
            docView.TabPageContextMenu = new ContextMenu();
            docView.TabPageContextMenu.MenuItems.Add(new MenuItem("保存", menuSave_Click));
            docView.TabPageContextMenu.MenuItems.Add(new MenuItem("关闭", menuClose_Click));
            docView.TabPageContextMenu.MenuItems.Add(new MenuItem("除此之外全关闭", menuCloseOther_Click));
            docView.TabPageContextMenu.MenuItems.Add(new MenuItem("复制完整路径", menuCopyPath_Click));
            docView.TabPageContextMenu.MenuItems.Add(new MenuItem("打开所在的文件夹", menuOpenFolder_Click));
            foreach (MenuItem menu in docView.TabPageContextMenu.MenuItems)
            {
                menu.Tag = docView;
            }
        }

        public FileTabPanel GetView(string fileName)
        {
            return this.m_documentViews.FirstOrDefault(x => x.FileName == fileName);
        }

        void docView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var docView = sender as FileTabPanel;
                this.m_documentViewContainer.FindForm();
                if (docView != null)
                {
                    if (docView.TabText.EndsWith("*"))
                    {
                        var result = MessageBox.Show(string.Format("是否保存文件{0}", docView.TabText.Replace("*", "")), "提醒", MessageBoxButtons.YesNoCancel);

                        if (result == DialogResult.Yes)
                        {
                            var model = GlobalService.ModelManager.GetModel((Guid)docView.Tag);
                            model.Save();
                        }

                        if (result == DialogResult.No)
                        {

                        }

                        if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }

                if (this.m_documentViews.Contains(docView))
                {
                    var cmd = CommandHostManager.Instance().Get<CloseFileCommand>
                        (CommandHostManager.HostType.Common, Dict.Commands.CloseFile);
                    cmd.FileId = (Guid)docView.Tag;
                    cmd.Execute();
                }

                docView.CloseTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ReceiverBase Receiver
        {
            get
            {
                return m_receiver;
            }
        }

        private DocumentViewManager(DockPanel documentView)
        {
            
        }

        void m_documentViewContainer_ActivePaneChanged(object sender, EventArgs e)
        {
           
        }

        void m_documentViewContainer_ActiveDocumentChanged(object sender, EventArgs e)
        {
            //GlobalService.EditorContextManager.CurrentContext = 
            //var ctx = ((WeifenLuo.WinFormsUI.Docking.DockPanel)(sender)).ActiveDocument;
            var ctx = ((WeifenLuo.WinFormsUI.Docking.DockPanel)(sender)).ActiveDocument as FileTabPanel;

            if (ctx != null)
            {
                GlobalService.EditorContextManager.SetCurrent((Guid)ctx.Tag);
            }
            
        }

        public void ActiveView(Guid fileId)
        {
            var docView = this.m_documentViews.FirstOrDefault(x => (Guid)x.Tag == fileId);
            if (docView != null)
            {
                docView.Select();
            }

        }

        void m_documentViewContainer_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        bool m_receiver_OnLoadFile(string file)
        {
            var docView = this.m_documentViews.FirstOrDefault(x => x.FileName == file);
            OpenFile(file, docView);
            return false;
        }

        bool receiver_OnOpenFile(string file)
        {
            OpenFile(file);
            return false;
        }

        void OpenFile(string file, FileTabPanel docView = null)
        {
            //如果已经打开则忽略
            var view = this.m_documentViews.FirstOrDefault(x => x.FileName == file);

            if (view != null)
            {
                view.Activate();                    
                return;
            }
            if (this.m_documentViews.Count(x => x.FileName == file) > 0)
                return;

            var editorContext = Assemble.CreateEditor(file);
            if (editorContext == null)
            {
                MessageBox.Show(string.Format("不能打开文件", file));
                return;
            }

            editorContext.EditorContainer.Editor.Dock = DockStyle.Fill;
            if (!File.Exists(file))
            {
                MessageBox.Show(string.Format("不能打开文件", file));
                return;
            }

            var text = File.ReadAllText(file);
            editorContext.EditorContainer.Text = text;
            var model = editorContext.Model;

            var page = docView == null ? new FileTabPanel() : docView;
            page.Name = (Path.GetFileName(file));
            page.TabText = page.Text = page.Name;
            page.FileName = file;
            
            //page.Name = model.File;
            page.Tag = model.FileId;
            page.ToolTipText = model.File;
            page.Controls.Add(editorContext.EditorContainer.Editor);
            page.Tag = editorContext.Model.FileId;
            page.Show(this.m_documentViewContainer, DockState.Document);

            editorContext.Model.Changed += new Core.Infrastructure.Model.OnChanged(Model_Changed);
            editorContext.Model.Saved += new OnSaved(Model_Saved);
            //this.tabControl.TabPages.Add(page);
            //this.tabControl.SelectedTab = page;
            GlobalService.EditorContextManager.CurrentContext = editorContext;
            this.AddView(page);
            //GlobalService.ModelManager.Regist(editorContext.Model);
        }

        void Model_Saved(IModel model)
        {
            var docView = this.m_documentViews.FirstOrDefault(x =>
            {
                var fileId = (Guid)x.Tag;
                return fileId == model.FileId;
            });

            if (docView != null)
            {
                if (docView.TabText.EndsWith("*"))
                {
                    docView.TabText = docView.TabText.Substring(0, docView.TabText.Length - 1);
                }
            }
        }

        void Model_Changed(IModel model)
        {
            var docView = this.m_documentViews.FirstOrDefault(x =>{
                var fileId = (Guid)x.Tag;
                return fileId == model.FileId;                
            });

            if (docView != null)
            {
                if ( docView.TabText.EndsWith("*"))
                    return ;

                docView.TabText += "*";
            }
        }

        private void menuSave_Click(object sender, EventArgs args)
        {
            var docView = ((MenuItem)sender).Tag as FileTabPanel;
            if (docView != null)
            {
                var model = GlobalService.ModelManager.GetModel((Guid)docView.Tag);
                model.Save();
            }
        }

        public void menuClose_Click(object sender, EventArgs args)
        {
            //var docView = ((MenuItem)sender).Tag as FileTabPanel;
            //var cmd = CommandHostManager.Instance().Get<CloseFileCommand>
            //    (CommandHostManager.HostType.Common, Dict.Commands.CloseFile);
            //cmd.FileId = (Guid)docView.Tag;
            //cmd.Execute();
            //if (docView.IsDisposed)
            //{
            //    docView.Close();
            //}
            //if ( 
            //this.m_documentViews.Remove(docView);

        }

        public void menuCloseOther_Click(object sender, EventArgs args)
        {
            var docView = ((MenuItem)sender).Tag as FileTabPanel;

            this.m_documentViews.ForEach(x =>
            {
                if (x != docView)
                {
                    x.Close();
                }
            });
        }

        public void menuCopyPath_Click(object sender, EventArgs args)
        {
            var docView = ((MenuItem)sender).Tag as FileTabPanel;       

            var model = GlobalService.ModelManager.GetModel((Guid)docView.Tag);

            Clipboard.SetDataObject(model.File,true);
        }

        public void menuOpenFolder_Click(object sender, EventArgs args)
        {
            var docView = ((MenuItem)sender).Tag as FileTabPanel;

            var model = GlobalService.ModelManager.GetModel((Guid)docView.Tag);

            var psi = new ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e," + Path.GetDirectoryName(model.File);
            System.Diagnostics.Process.Start(psi);
        }
    }
}
