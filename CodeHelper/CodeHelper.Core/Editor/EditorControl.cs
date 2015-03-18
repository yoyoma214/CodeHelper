using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.TextEditor;
using System.Windows.Forms;
using System.Drawing;
using ICSharpCode.TextEditor.Document;
using CodeHelper.Core.Error;
using CodeHelper.Core.UI;

namespace CodeHelper.Editors
{
    public delegate void OnInputChar(char c,int offset, Point location);
    public delegate void OnKeyPreview(KeyEventArgs e, Point location); 
   

    public class EditorControl : TextEditorControl
    {
        public event OnInputChar InputChar;
        public event OnKeyPreview KeyPreview;
        public List<ParseErrorInfo> Errors { get; set; }

        public EditorControl()
            : base()
        {
            Errors = new List<ParseErrorInfo>();
            this.TextChanged += new EventHandler(EditorControl_TextChanged);
            this.ActiveTextAreaControl.Paint += new PaintEventHandler(ActiveTextAreaControl_Paint);
            ActiveTextAreaControl.TextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(EditorControl_KeyDown);
        }

        private int FindTextReportCounter = 0;
        private string FindText = null;
        private FindFrm findFrm = null;

        void EditorControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.F)
                {
                    findFrm = new FindFrm();
                    findFrm.OnFindTextChange +=new FindTextChange(findFrm_OnFindTextChange);
                    findFrm.Show();
                }
            }
        }

        void findFrm_OnFindTextChange(string text)
        {
            if (FindText != text)
            {
                FindText = text;
                FindTextReportCounter = 0;
            }
            else
            {
                FindTextReportCounter++;
            }

            this.ActiveTextAreaControl.SelectionManager.SelectionCollection.Clear();

            var document = this.ActiveTextAreaControl.TextArea.Document;
            for (var lineIndex = 0; lineIndex < document.TotalNumberOfLines; lineIndex++)
            {
                var txt = document.GetLineSegment(lineIndex);
                foreach (var word in txt.Words)
                {
                    if (word.Word.ToLower().Contains(text.ToLower()))
                    {
                        this.ActiveTextAreaControl.SelectionManager.SelectionCollection.Add(
                            new DefaultSelection(document, new TextLocation(word.Offset, txt.LineNumber),
                                new TextLocation(word.Offset + word.Length, txt.LineNumber)));
                    }
                }
            }
            //for (var index = 0; index < this.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count;
            //    index++)
            //{
            if (this.ActiveTextAreaControl.SelectionManager.SelectionCollection.Count > FindTextReportCounter)
            {
                var select = this.ActiveTextAreaControl.SelectionManager.SelectionCollection[FindTextReportCounter];
                //this.ActiveTextAreaControl.TextArea.Caret.Position = select.StartPosition;
                //this.ActiveTextAreaControl.TextArea.Caret = new Caret(select.);
                this.ActiveTextAreaControl.JumpTo(select.StartPosition.Line, select.StartPosition.Column);
                var offset_first = select.SelectedText.IndexOf(text) + select.StartPosition.Column;
                var offset_end = offset_first + text.Length;
                this.ActiveTextAreaControl.SelectionManager.SetSelection(new DefaultSelection(document, new TextLocation(offset_first, select.StartPosition.Line),
                                new TextLocation(offset_end, select.StartPosition.Line)));
            }
            else
            {
                FindTextReportCounter = 0;
            }

            findFrm.TopMost = true;

            //}
        }

        void ActiveTextAreaControl_Paint(object sender, PaintEventArgs e)
        {
            if (Errors != null && Errors.Count > 0)
            {
                System.Drawing.Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                System.Drawing.Graphics formGraphics = this.CreateGraphics();
                Errors.ForEach(x =>
                {
                    formGraphics.DrawLine(myPen, 0, 0, 200, 200);
                });
                myPen.Dispose();
                formGraphics.Dispose();
            }
        }

        void EditorControl_TextChanged(object sender, EventArgs e)
        {
            DocumentEventArgs arg = e as DocumentEventArgs;
            if (arg != null && !string.IsNullOrWhiteSpace(arg.Text) && arg.Text.Length == 1)
            {
                Point location = this.ActiveTextAreaControl.Caret.ScreenPosition;
                if (InputChar != null)
                {
                    InputChar(arg.Text[0], arg.Offset, location);
                }
            }

            FindText = null;
            FindTextReportCounter = 0;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Errors != null && Errors.Count > 0)
            {
                System.Drawing.Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
                System.Drawing.Graphics formGraphics = this.CreateGraphics();
                Errors.ForEach(x =>
                {
                    formGraphics.DrawLine(myPen, 100, 100, 200, 200);
                });
                myPen.Dispose();
                formGraphics.Dispose();
            }
            base.OnPaint(e);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_SYSKEYUP = 0x105;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if (m.Msg == WM_CHAR)
            {

            }
            if (m.Msg == WM_KEYUP)
            {

            }
            if (m.Msg == WM_KEYUP)
            {

            }
            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
            }
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
        protected override bool ProcessKeyEventArgs(ref Message m)
        {
            return base.ProcessKeyEventArgs(ref m);
        }
        //protected override bool ProcessKeyMessage(ref Message m)
        //{
        //    const int WM_KEYDOWN = 0x100;
        //    const int WM_KEYUP = 0x101;
        //    const int WM_CHAR = 0x102;
        //    const int WM_SYSCHAR = 0x106;
        //    const int WM_SYSKEYDOWN = 0x104;
        //    const int WM_SYSKEYUP = 0x105;
        //    const int WM_IME_CHAR = 0x286;

        //    KeyEventArgs e = null;

        //    if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
        //    {
        //        e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
        //        if (InputChar != null)
        //        {
        //            Point location = this.ActiveTextAreaControl.Caret.ScreenPosition;
        //            //location.X = this.ActiveTextAreaControl.Document.OffsetToPosition(this.ActiveTextAreaControl.Caret.Offset + 1).X;

        //            InputChar(e, location);
        //        }
        //    }
        //    return base.ProcessKeyMessage(ref m);
        //}

        //protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        //{
        //    const int WM_KEYDOWN = 0x100;
        //    const int WM_KEYUP = 0x101;
        //    const int WM_CHAR = 0x102;
        //    const int WM_SYSCHAR = 0x106;
        //    const int WM_SYSKEYDOWN = 0x104;
        //    const int WM_SYSKEYUP = 0x105;
        //    const int WM_IME_CHAR = 0x286;

        //    KeyEventArgs e = null;

        //    if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
        //    {
        //        e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
        //        if (InputChar != null)
        //        {
        //            Point location = this.ActiveTextAreaControl.Caret.ScreenPosition;
        //            //location.X = this.ActiveTextAreaControl.Document.OffsetToPosition(this.ActiveTextAreaControl.Caret.Offset + 1).X;

        //            //KeyPreview(e, location);
        //        }
        //    }
        //    return base.ProcessCmdKey(ref m, keyData);
        //}

        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_KEYUP = 0x101;
            const int WM_CHAR = 0x102;
            const int WM_SYSCHAR = 0x106;
            const int WM_SYSKEYDOWN = 0x104;
            const int WM_SYSKEYUP = 0x105;
            const int WM_IME_CHAR = 0x286;

            KeyEventArgs e = null;

            if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)m.WParam))) | ModifierKeys);
                if (KeyPreview != null)
                {
                    Point location = this.ActiveTextAreaControl.Caret.ScreenPosition;
                    //location.X = this.ActiveTextAreaControl.Document.OffsetToPosition(this.ActiveTextAreaControl.Caret.Offset + 1).X;

                    KeyPreview(e, location);
                }
            }

            return base.ProcessKeyPreview(ref m);
        }

    }
}
