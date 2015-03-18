using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;

namespace CodeHelper.DataBaseHelper.UI
{
    public partial class ShowCodeFrm : Form
    {
        public ShowCodeFrm()
        {
            InitializeComponent();

            this.textEditorControl1.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            
        }

        public void SetText(string text)
        {
            this.textEditorControl1.Text = text;
            this.textEditorControl1.Invalidate();
        }
    }
}
