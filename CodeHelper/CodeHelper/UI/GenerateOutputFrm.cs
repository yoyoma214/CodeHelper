using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace CodeHelper.UI
{
    public partial class GenerateOutputFrm : Form
    {
        TextEditorControl editor = new TextEditorControl();

        public GenerateOutputFrm()
        {
            InitializeComponent();
            this.Controls.Add(editor);
            editor.Dock = DockStyle.Fill;

            editor.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
        }

        public string Content
        {
            get
            {
                return this.editor.Text;
            }
            set
            {
                this.editor.Text = value;
            }
        }
    }
}
