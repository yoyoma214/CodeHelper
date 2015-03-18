using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using CodeHelper.Editors;
using CodeHelper.Core.Error;

namespace CodeHelper.Core.Infrastructure
{
    public interface IEditor
    {
        EditorControl Editor { get; set; }

        string Text { get; set; }

        void NotifyError(ParseErrorInfo error);
    }
}
