using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using CodeHelper.AssembleLayer;
using CodeHelper.Items;
using CodeHelper.Core.Infrastructure.Command;
using WeifenLuo.WinFormsUI.Docking;
using CodeHelper.Domain.Model;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Commands.DataModel;
using CodeHelper.Commands.XmlModel;
using CodeHelper.Commands;
using CodeHelper.Commands.DataView;
using CodeHelper.Commands.ViewModel;
using CodeHelper.Commands.WorkFlow;

namespace CodeHelper
{
    public partial class MainFrm : IReceiverHolder
    {

        //DocumentViewManager m_documentViewManager = null;

        public MainFrm()
        {
            InitializeComponent();
            //Workspace.ProjectView = this.splitContainer1.Panel1;
            GlobalService.ModelManager = ModelManager.Instance();
            GlobalService.DepencyManager = DepencyManager.Instance();

            DocumentViewManager.Init(this.m_workspace);

            this.IsMdiContainer = true;
           
            this.m_deserializeDockContent = new DeserializeDockContent(this.GetContentFromPersistString);

            this.receiver.Listeners.Add(this.m_prjPanel.Receiver);
            this.receiver.Listeners.Add(this.m_propertyPanel.Receiver);
            this.receiver.Listeners.Add(DocumentViewManager.Instance().Receiver);
            this.receiver.Listeners.Add(GlobalService.ModelManager.Receiver);
            this.receiver.Listeners.Add(GlobalService.EditorContextManager.Receiver);

            this.Load += new EventHandler(MainFrm_Load);
            this.FormClosing += new FormClosingEventHandler(MainFrm_FormClosing);

            this.receiver.OnOpenProjectCompleted += new ReceiverBase.OpenProjectCompletedHandler(receiver_OnOpenProjectCompleted);
            
            //this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
            //this.treeView1.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseDoubleClick);
            Application.Idle += new EventHandler(Application_Idle);

            this.InitIcon();

            //this.dgvError.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvError_RowPostPaint);
            //this.dgvError.CellDoubleClick += new DataGridViewCellEventHandler(dgvError_CellDoubleClick);

            
            //GlobalService.ModelManager.ParseError += new OnParseError(GlobalService_ParseError);
            //StringTemplateGroup.RegisterGroupLoader(new PathGroupLoader(AppDomain.CurrentDomain.BaseDirectory, null));

            this.WindowState = FormWindowState.Maximized;

            //this.receiver.OnOpenNullProject += new ReceiverBase.OpenNullProjectHandler(receiver_OnOpenNullProject);

        }

        bool receiver_OnOpenProjectCompleted(string prj)
        {
            this.Text += "---" + System.IO.Path.GetFileName(prj);
            return false;
        }

        void Init()
        {                       

            var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
            cmdHost_common.AddCommand(new RenameModelCommand(this.Receiver));

            cmdHost_common.AddCommand(new CloseProjectCommand(this.Receiver));
            cmdHost_common.AddCommand(new ExitProcessCommand(this.Receiver));

            cmdHost_common.AddCommand(new NewProjectCommand(this.Receiver));
            cmdHost_common.AddCommand(new OpenProjectCommand(this.Receiver));
            cmdHost_common.AddCommand(new CloseFileCommand(this.Receiver));

            var cmdHost_dm = CommandHostManager.Instance().Get(CommandHostManager.HostType.DataModel);

            cmdHost_dm.AddCommand(new OpenDataModelCommand(this.Receiver));
            cmdHost_dm.AddCommand(new NewDataModelCommand(this.Receiver));

            var cmdHost_xm = CommandHostManager.Instance().Get(CommandHostManager.HostType.XmlMode);

            cmdHost_xm.AddCommand(new OpenXmlModelCommand(this.Receiver));
            cmdHost_xm.AddCommand(new NewXmlModelCommand(this.Receiver));

            var cmdHost_dv = CommandHostManager.Instance().Get(CommandHostManager.HostType.DataView);

            cmdHost_dv.AddCommand(new OpenDataViewCommand(this.Receiver));
            cmdHost_dv.AddCommand(new NewDataViewCommand(this.Receiver));

            var cmdHost_wf = CommandHostManager.Instance().Get(CommandHostManager.HostType.WorkFlow);
            cmdHost_wf.AddCommand(new OpenWorkFlowCommand(this.Receiver));
            cmdHost_wf.AddCommand(new NewWorkFlowCommand(this.Receiver));

            CommandHostManager.Instance().AddCommand(CommandHostManager.HostType.ViewModel,
                new NewViewModelCommand(this.receiver));

            CommandHostManager.Instance().AddCommand(CommandHostManager.HostType.ViewModel,
               new OpenViewModelCommand(this.receiver));

            CommandHostManager.Instance().AddCommand(CommandHostManager.HostType.Common,
              new PropertySelectCommand(this.receiver));

            var prj = System.Configuration.ConfigurationManager.AppSettings["CurrentProject"];

            if (prj != null)
            {
                if (Directory.Exists(prj))
                {
                    GlobalService.CurrentPrj_Name = Path.GetFileName(prj);
                    GlobalService.CurrentPrj_Dir = prj;
                    this.Receiver.OpenProject(prj);

                    //OpenPrject();
                }
            }
        }

        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }
    }
}

