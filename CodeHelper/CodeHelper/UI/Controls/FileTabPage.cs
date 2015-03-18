using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.Core.Services;

namespace CodeHelper.UI.Controls
{
    class FileTabPage : TabPage
    {
        public Guid FileId { get; set; }

        public FileTabPage(Guid fileId):base()
        {
            this.FileId = fileId;
        }

        //public BaseTabPage(Guid fileId)
        //{
        //    this.Name = fileId.ToString();
        //    var model = GlobalService.ModelManager.GetModel(fileId);
        //    if (model == null)
        //    {
        //    }
        //}



        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }        
    }
}
