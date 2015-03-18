using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;          
namespace CodeHelper.Core.Infrastructure.Model
{
    public delegate void OnChanged(IModel model);
    public delegate void OnSaved(IModel model);
    public delegate void OnParsed(IModel model,bool success);
    public delegate void OnInvokeParse(IModel model,int charIndex);
    public delegate void OnChangeName(IModel model,string oldName , string newName);
    public delegate void OnRemoved(IModel model);

    public interface IModel
    {
        Guid FileId { get; set; }

        event OnChanged Changed;

        event OnSaved Saved;

        event OnParsed Parsed;

        bool IsParsed { get; }

        //string NameSpace { get; set; }

        void SetParsed(bool success);

        event OnInvokeParse InvokeParse;

        //void Parse();

        event OnChangeName ChangeName;

        event OnRemoved Removed;
            
        string File { get; set; }

        bool Opened { get; set; }

        bool Modifed { get; set; }

        string Content { get; set; }

        void Parse(int charIndex);

        ParseType ParseType { get; set; }

        void Open();

        void Save();

        //int InputCharLineIndex { get; set; }
        //int InputChar
        //char InputChar { get; set; }

    }
}
