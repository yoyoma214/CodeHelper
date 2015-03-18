using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Infrastructure.Model;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Drawing;
using System.IO;
using System.Threading;
using CodeHelper.Core.Error;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.EditorController
{
    public class BaseEditorController : IEditorController
    {
        //public void Dot()
        //{
        //    throw new NotImplementedException();
        //}
        public BaseEditorController()
        {
            GlobalService.Idle += new EventHandler(GlobalService_Idle);
        }
        DateTime updateTime = DateTime.Now;

        void GlobalService_Idle(object sender, EventArgs e)
        {
            var module = GlobalService.ModelManager.GetParseModule(model.FileId);
            if (module != null)
            {
                if (model.ParseType == Parser.ParseType.XmlModel ||
                    model.ParseType == Parser.ParseType.DataModel)
                {
                    this.editorContainer.Editor.Document.FoldingManager.UpdateFoldings(this.model.File, module);

                    this.editorContainer.Editor.Document.FoldingManager.NotifyFoldingsChanged(new EventArgs());
                }
            }
        }

        protected delegate void ShowMenuDelegate(ContextMenu menu, Point location);

        protected IEditor editorContainer = null;

        protected IModel model = null;

        public void Bind(IEditor editorContainer, IModel model)
        {
            this.editorContainer = editorContainer;
            this.model = model;
            //this.editorContainer.Editor.Document.HighlightingStrategy =
            //    HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            OnBind();

            editorContainer.Editor.TextChanged += new EventHandler(Editor_TextChanged);
            editorContainer.Editor.InputChar += new Editors.OnInputChar(Editor_InputChar);
            editorContainer.Editor.KeyPreview += new Editors.OnKeyPreview(Editor_KeyPreview);

            GlobalService.ModelManager.ParseError += new OnParseError(ModelManager_ParseError);
        }

        protected virtual void OnBind()
        {
            this.editorContainer.Editor.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            
            //this.editorContainer.Editor.Document.FoldingManager.FoldingStrategy = 
            //this.editorContainer.Editor.Document.HighlightingStrategy =
            //  HighlightingStrategyFactory.CreateHighlightingStrategyForFile("HighLights\\CSharp-Mode.xshd");
        }

        void ModelManager_ParseError(string file, List<ParseErrorInfo> errors)
        {
            errors.ForEach(x =>
            {
                if (x.File == this.model.File)
                {
                    this.editorContainer.NotifyError(x);
                }
            });
        }

        void Editor_KeyPreview(KeyEventArgs e, Point location)
        {
            OnKeyPreview(e, location);
        }
        protected virtual void OnKeyPreview(KeyEventArgs e, Point location)
        {
        }

        protected virtual void OnInputChar(char c, int offset, Point location)
        {

        }

        void Editor_InputChar(char c, int offset, Point location)
        {
            this.model.Content = this.editorContainer.Text;

            OnInputChar(c, offset, location);

            location.X += (int)this.editorContainer.Editor.Font.Size;
        }
   

        void Editor_TextChanged(object sender, EventArgs e)
        {
            var args = ((ICSharpCode.TextEditor.Document.DocumentEventArgs)(e));
            this.model.Content = this.editorContainer.Text;
            model.Modifed = true;
        }

        public virtual void Comments()
        {
            throw new NotImplementedException();
        }

        public virtual void NoComments()
        {
            throw new NotImplementedException();
        }

        public virtual void Undo()
        {
            throw new NotImplementedException();
        }

        public virtual void Redo()
        {
            throw new NotImplementedException();
        }

        public virtual void Cut()
        {
            throw new NotImplementedException();
        }

        public virtual void Paste()
        {
            throw new NotImplementedException();
        }

        public virtual void OpenFile()
        {
            throw new NotImplementedException();
        }

        public virtual void NewFile()
        {
            throw new NotImplementedException();
        }

        public virtual void CloseFile()
        {
            throw new NotImplementedException();
        }

        public virtual void SaveFile()
        {
            //throw new NotImplementedException();
            //this.model.Modifed
            //this.editorContainer.Text

            this.model.Save();

            //StreamWriter w = null;
            //if (File.Exists(this.model.File))
            //{
            //    File.Delete(this.model.File);
            //}

            //w = File.CreateText(this.model.File);
            //w.Write(this.editorContainer.Text);
            //w.Flush();
            //w.Close();

            //this.model.Modifed = false;           
        }

        public virtual void Search(string s)
        {
            throw new NotImplementedException();
        }

        public virtual void Replace(string s, string r)
        {
            throw new NotImplementedException();
        }

        public virtual ContextMenu PopMenuOnKey(Keys key)
        {
            var menu = new ContextMenu();

            //if (key == Keys.A)
            //{

            //}

            return menu;
        }


        public virtual void RePosition(int line, int charPositionInLine, RePositionType type, string message)
        {
            this.editorContainer.Editor.ActiveTextAreaControl.JumpTo(line, charPositionInLine);
        }


        public bool Parse(out ParseErrorInfo errors)
        {
            throw new NotImplementedException();
        }
    }
}
