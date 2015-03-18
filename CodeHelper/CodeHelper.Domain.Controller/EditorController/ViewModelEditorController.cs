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
using CodeHelper.Domain.Model;

namespace CodeHelper.Domain.EditorController
{
    public class ViewModelEditorController : BaseEditorController
    {
        public string Text { get; set; }

        protected override void OnInputChar(char c, int offset, System.Drawing.Point location)
        {
            if( c == '.' || c ==';' || c == '}')
            {
                //call to parse file     
                location.X += (int)this.editorContainer.Editor.Font.Size;
                location.Y += (int)this.editorContainer.Editor.Font.Height;
                var text = this.editorContainer.Text;
                //var index = this.editorContainer.Editor.Document
                
                this.model.Parse(offset);

                this.model.Parsed += new OnParsed((o,a) => { });

                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    var parseInfo = new ParseInfo();
                //    parseInfo.Content = text;
                //    parseInfo.Index = offset;
                //    parseInfo.Type = ParseType.XmlModel;
                //    var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                //    var result_json = DataModelParser.Instance().Parse(parseInfo_json);
                //    var menu = new ContextMenu();
                //    menu.MenuItems.Add(new MenuItem("as"));
                //    this.editorContainer.Editor.Invoke(new ShowMenuDelegate(ShowMenu), menu, location);
                //});                                       
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
                //call to parse file                
                //menu.MenuItems.Add(new MenuItem("as"));
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

    }
}
