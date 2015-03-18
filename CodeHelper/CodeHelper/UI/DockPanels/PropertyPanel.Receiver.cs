using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;

namespace CodeHelper.UI.DockPanels
{
    partial class PropertyPanel : IReceiverHolder
    {
        public PropertyPanel()
            : base()
        {
            InitializeComponent();

            this.receiver.OnPropertySelected += new ReceiverBase.PropertySelectedHandler(receiver_OnPropertySelected);
        }

        void receiver_OnPropertySelected(object obj)
        {
            this.propertyGrid1.SelectedObject = obj;
        }

        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        //private void InitializeComponent()
        //{
        //    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyPanel));
        //    this.SuspendLayout();
        //    // 
        //    // PropertyPanel
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        //    this.Name = "PropertyPanel";
        //    this.ResumeLayout(false);

        //}
    }
}
