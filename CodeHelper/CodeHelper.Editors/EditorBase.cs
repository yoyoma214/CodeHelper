using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Editors;
using CodeHelper.Core.Error;

namespace CodeHelper.Editors
{
    public class EditorBase : IEditor
    {

        EditorControl textEditor = new EditorControl();


        public EditorControl Editor
        {
            get
            {
                return textEditor;
                //this.textEditor.TextChanged += new EventHandler(textEditor_TextChanged);
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void textEditor_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public string Text
        {
            get
            {
                return this.Editor.Text;
            }
            set
            {
                this.Editor.Text = value;
            }
        }

        public void NotifyError(ParseErrorInfo error)
        {
            this.Editor.Errors.Add(error);
        }
    }
}
