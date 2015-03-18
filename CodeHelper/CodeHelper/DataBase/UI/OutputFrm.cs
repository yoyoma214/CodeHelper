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

namespace CodeHelper.DataBaseHelper
{
    public partial class OutputFrm : Form
    {
        TextEditorControl textEditor = new TextEditorControl();
        public OutputFrm()
        {
            InitializeComponent();
            this.textEditor.Document.HighlightingStrategy =
                 HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            this.textEditor.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(this.textEditor);
        }
    }
}
