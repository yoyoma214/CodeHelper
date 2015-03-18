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
using CodeHelper.Parser;
using System.Threading;
using CodeHelper.Core.EditorController;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parser;
using CodeHelper.Editors;
using CodeHelper.Domain.Model;

namespace CodeHelper.Domain.EditorController
{
    public class DataModelEditorController : BaseEditorController
    {
        public string Text { get; set; }

        protected delegate void ShowMenuDelegate(ContextMenu menu, Point location);

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
                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    var parseInfo = new ParseInfo();
                //    parseInfo.Content = text;
                //    parseInfo.Index = offset;
                //    parseInfo.Type = ParseType.DataModel;
                //    var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                //    var result_json = XmlModelParser.Instance().Parse(parseInfo_json);
                //    if (result_json.Errors != null && result_json.Errors.Count > 0)
                //    {
                //        GlobalService.PushParseError(this.model.File, result_json.Errors);
                //    }
                //    var menu = new ContextMenu();
                //    menu.MenuItems.Add(new MenuItem("as"));
                //    this.editorContainer.Editor.Invoke(new ShowMenuDelegate(ShowMenu), menu, location);
                //});                                                
            }

            //if (c == '}')
            //{
            //    var module = ModelManager.Instance().MakeSureParseModule(model.File);
            //    if (module != null)
            //    {
            //        this.editorContainer.Editor.Document.FoldingManager.UpdateFoldings(this.model.File, module);
            //    }

            //}

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
                //call to parse file                
                menu.MenuItems.Add(new MenuItem("as"));
                //var text = this.editorContainer.Text;
                //var json = DataModelParser.Instance().Parse(text);
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
        //public void Dot()
        //{
        //    throw new NotImplementedException();
        //}

        // {
        //    get
        //    {
        //        return this.editorContainer;
        //    }
        //    set
        //    {
        //        if (this.editorContainer != null)
        //            throw new Exception("不能重复赋值");

        //        this.editorContainer = value;
        //        this.editorContainer.Editor.TextChanged += textEditor_TextChanged;
        //    }
        //}


        protected override void OnBind()
        {
            //base.OnBind();

            this.editorContainer.Editor.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("DataModel");

            this.editorContainer.Editor.Document.FoldingManager.FoldingStrategy =
                new DM_ParserFoldingStrategy();

            //this.editorContainer.Editor.FindForm().HandleCreated
            //             += new EventHandler(DataModelEditorController_HandleCreated);

            //var module = ModelManager.Instance().MakeSureParseModule(model.File);

            //if (module != null)
            //{

            //    ThreadPool.QueueUserWorkItem(x =>
            //    {

            //        Action call = delegate()
            //        {
            //            this.editorContainer.Editor.Document.FoldingManager.UpdateFoldings(this.model.File, module);
            //        };
                    

            //        this.editorContainer.Editor.BeginInvoke(
            //            call
            //         );
            //    });
            //}
        }

        void DataModelEditorController_HandleCreated(object sender, EventArgs e)
        {
            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module != null)
            {
                this.editorContainer.Editor.Document.FoldingManager.UpdateFoldings(this.model.File, module);
            }
        }
    }
}
