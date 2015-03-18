using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.EditorController;
using System.Windows.Forms;
using System.Drawing;
using CodeHelper.Core.Infrastructure.Model;
using ICSharpCode.TextEditor.Document;

namespace CodeHelper.Domain.Controller.EditorController
{
    public class DataViewEditorController : BaseEditorController
    {
        public string Text { get; set; }

        protected override void OnInputChar(char c, int offset, System.Drawing.Point location)
        {
            if (c == '.' || c == ';' || c == '}')
            {
                //call to parse file     
                location.X += (int)this.editorContainer.Editor.Font.Size;
                location.Y += (int)this.editorContainer.Editor.Font.Height;
                var text = this.editorContainer.Text;
                //var index = this.editorContainer.Editor.Document

                this.model.Parse(offset);

                this.model.Parsed += new OnParsed((o, a) => { });
                                 
            }
        }

        void ShowMenu(ContextMenu menu, Point location)
        {
            menu.Show(this.editorContainer.Editor, location);
        }

        public override ContextMenu PopMenuOnKey(Keys key)
        {
            var menu = base.PopMenuOnKey(key);
            if (key == Keys.OemPeriod)
            {

            }
            return menu;
        }

        protected override void OnKeyPreview(KeyEventArgs e, Point location)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                this.SaveFile();
            }
            base.OnKeyPreview(e, location);
        }

        protected override void OnBind()
        {
            base.OnBind();

            this.editorContainer.Editor.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            //this.editorContainer.Editor.Document.HighlightingStrategy =
            //    HighlightingStrategyFactory.CreateHighlightingStrategyForFile("SyntaxMode.xml");

        }
    }
}
