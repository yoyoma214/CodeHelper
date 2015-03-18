using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Model;
using System.Windows.Forms;
using CodeHelper.Core.Error;

namespace CodeHelper.Core.Infrastructure
{
    public enum RePositionType
    {
        Info,Error
    }

    public interface IEditorController
    {
        //void Dot();
        //IEditor editorContainer = null;
               
        //IModel Model { get; set; }

        ContextMenu PopMenuOnKey(Keys key);

        void Bind(IEditor editorContainer, IModel model);

        void OpenFile();

        void NewFile();

        void CloseFile();

        void SaveFile();

        void Search(string s);

        void Replace(string s, string r);

        void Comments();

        void NoComments();

        void Undo();

        void Redo();

        void Cut();

        void Paste();

        void RePosition(int line, int charPositionInLine, RePositionType type, string message);

        bool Parse(out ParseErrorInfo errors);
    }
}
