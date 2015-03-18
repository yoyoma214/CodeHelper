using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Command
{
    public interface IReceiver
    {
        List<IReceiver> Listeners { get; }

        void LoadFile(string file);

        void OpenFile(string file);

        void CloseFile(Guid fileId);

        void DeleteFile(string file);

        void RenameFile(string oldName, string newName);

        void DeleteFolder(string folder);

        void NewProject();

        void NewProject(string prj);

        void OpenProject();

        void OpenProject(string prj);

        void CloseProject(string prj);

        void ExitProcess();

        void PropertySelect(object obj);
    }
}
