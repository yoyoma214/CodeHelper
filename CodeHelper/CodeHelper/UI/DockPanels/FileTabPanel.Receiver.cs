using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;

namespace CodeHelper.UI.DockPanels
{
    public partial class FileTabPanel : IReceiverHolder
    {
        ReceiverBase receiver = new ReceiverBase();

        public DateTime? CloseTime { get; set; }

        public string FileName { get; set; }

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        public FileTabPanel():base()
        {
        }

        protected override string GetPersistString()
        {
            return (GetType().ToString() + "," + this.FileName + "," + this.Text);
        }

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileTabPanel));
        //    this.SuspendLayout();
        //    // 
        //    // FileTabPanel
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.Name = "FileTabPanel";
        //    this.ResumeLayout(false);

        //}
    }
}
