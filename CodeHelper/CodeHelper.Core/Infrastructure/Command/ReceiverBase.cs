using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using System.Windows.Forms;

namespace CodeHelper.Core.Infrastructure.Command
{
    public class ReceiverBase : IReceiver
    {
        public delegate bool ExitProcessHandler();
        public delegate bool ExitProcessCompletedHandler();

        public delegate bool LoadFileHandler(string file);
        public delegate bool LoadFileCompletedHandler(string file);

        public delegate bool OpenFileHandler(string file);
        public delegate bool OpenFileCompletedHandler(string file);

        public delegate bool OpenCloseFileHandler(Guid fileId);
        public delegate bool OpenCloseFileCompletedHandler(Guid fileId);

        public delegate bool RenameFileHandler(string oldName, string newName);
        public delegate bool RenameFileCompletedHandler(string oldName, string newName);

        public delegate bool DeleteFileHandler(string file);
        public delegate bool DeleteFileCompletedHandler(string file);

        public delegate bool DeleteFolderHandler(string file);
        public delegate bool DeleteFolderCompletedHandler(string file);

        public delegate bool OpenNullProjectHandler();
        public delegate bool OpenNullProjectCompletedHandler();

        public delegate bool OpenProjectHandler(string prj);
        public delegate bool OpenProjectCompletedHandler(string prj);

        public delegate bool CloseProjectHandler(string prj);
        public delegate bool CloseProjectCompletedHandler(string prj);

        public delegate bool NewProjectHandler(string prj);
        public delegate bool NewProjectCompletedHandler(string prj);

        public delegate bool NewNullProjectHandler();
        public delegate bool NewNullProjectCompletedHandler();

        public delegate void PropertySelectedHandler(object obj);

        public event ExitProcessHandler OnExitProcess;
        public event ExitProcessCompletedHandler OnExitProcessCompleted;

        public event LoadFileHandler OnLoadFile;
        public event LoadFileCompletedHandler OnLoadFileCompleted;

        public event OpenFileHandler OnOpenFile;
        public event OpenFileCompletedHandler OnOpenFileCompleted;

        public event RenameFileHandler OnRenameFile;
        public event RenameFileCompletedHandler OnRenameFileCompleted;

        public event OpenCloseFileHandler OnCloseFile;
        public event OpenCloseFileCompletedHandler OnCloseFileCompleted;

        public event DeleteFileHandler OnDeleteFile;
        public event DeleteFileCompletedHandler OnDeleteFileCompleted;

        public event DeleteFolderHandler OnDeleteFolder;
        public event DeleteFolderCompletedHandler OnDeleteFolderCompleted;

        public event OpenNullProjectHandler OnOpenNullProject;
        public event OpenNullProjectCompletedHandler OnOpenNullProjectCompleted;

        public event OpenProjectHandler OnOpenProject;
        public event OpenProjectCompletedHandler OnOpenProjectCompleted;

        public event CloseProjectHandler OnCloseProject;
        public event CloseProjectCompletedHandler OnCloseProjectCompleted;

        public event NewProjectHandler OnNewProject;
        public event NewProjectCompletedHandler OnNewProjectCompleted;

        public event NewNullProjectHandler OnNewNullProject;
        public event NewNullProjectCompletedHandler OnNewNullProjectCompleted;

        public event PropertySelectedHandler OnPropertySelected;

        private List<IReceiver> _Listeners = new List<IReceiver>();

        public List<IReceiver> Listeners
        {
            get
            {
                return _Listeners;
            }
        }

        public ReceiverBase()
            : base()
        {
        }  

        public virtual void OpenFile(string file)
        {
            if (OnOpenFile != null)
                OnOpenFile(file);

            Listeners.ForEach(x=>x.OpenFile(file));

            if (OnOpenFileCompleted != null)
                OnOpenFileCompleted(file);
        }

        public virtual void RenameFile(string oldName, string newName)
        {
            if (OnRenameFile != null)
                OnRenameFile(oldName, newName);

            Listeners.ForEach(x => x.RenameFile(oldName, newName));

           if (OnRenameFileCompleted != null)
               OnRenameFileCompleted(oldName, newName);
        }

        public virtual void OpenProject(string prj)
        {
            if (this.OnOpenProject != null)
                this.OnOpenProject(prj);

            this.Listeners.ForEach(x =>
                x.OpenProject(prj)
                );

            if (this.OnOpenProjectCompleted != null)
                this.OnOpenProjectCompleted(prj);
        }

        public virtual void CloseProject(string prj)
        {
            if (OnCloseProject != null)
                OnCloseProject(prj);

            Listeners.ForEach(x => x.CloseProject(prj));

            if (OnCloseProjectCompleted != null)
                OnCloseProjectCompleted(prj);
        }

        public void NewProject(string prj)
        {
            if (OnNewProject != null)
                OnNewProject(prj);

            Listeners.ForEach(x => x.NewProject(prj));

            if (OnNewProjectCompleted != null)
                OnNewProjectCompleted(prj);
        }

        public void NewProject()
        {
            if (OnNewNullProject != null)
            {
                OnNewNullProject();
            }

            Listeners.ForEach(x => x.NewProject());

            if (OnNewNullProjectCompleted != null)
                OnNewNullProjectCompleted();

         }

        public void OpenProject()
        {
            if (OnOpenNullProject != null)
                OnOpenNullProject();

            Listeners.ForEach(x => x.OpenProject());

            if (OnOpenNullProjectCompleted != null)
                OnOpenNullProjectCompleted();
        }


        public void LoadFile(string file)
        {
            if (OnLoadFile != null)
                OnLoadFile(file);

            Listeners.ForEach(x => x.LoadFile(file));

            if (OnLoadFileCompleted != null)
                OnLoadFileCompleted(file);
        }


        public void DeleteFile(string file)
        {
            if (OnDeleteFile != null)
                OnDeleteFile(file);

            Listeners.ForEach(x => x.DeleteFile(file));

            if (OnDeleteFileCompleted != null)
                OnDeleteFileCompleted(file);
        }

        public void DeleteFolder(string folder)
        {
            if (OnDeleteFolder != null)
                OnDeleteFolder(folder);

            Listeners.ForEach(x => x.DeleteFolder(folder));

            if (OnDeleteFolderCompleted != null)
                OnDeleteFolderCompleted(folder);
        }


        public void ExitProcess()
        {
            if (OnExitProcess != null)
                OnExitProcess();

            Listeners.ForEach(x => x.ExitProcess());

            if (OnExitProcessCompleted != null)
                OnExitProcessCompleted();
        }


        public void CloseFile(Guid fileId)
        {
            if (this.OnCloseFile != null)
                OnCloseFile(fileId);

            Listeners.ForEach(x => x.CloseFile(fileId));

            if (this.OnCloseFileCompleted != null)
                OnCloseFileCompleted(fileId);
        }

        public void PropertySelect(object obj)
        {
            if (this.OnPropertySelected != null)
                OnPropertySelected(obj);

            Listeners.ForEach(x => x.PropertySelect(obj));
        }
    }
}
