using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;
using CodeHelper.Core.Infrastructure.Command;
using System.Windows.Forms;

namespace CodeHelper.UI.DockPanels
{
    partial class ProjectPanel : DockContent
    {


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectPanel));
            this.SuspendLayout();
            // 
            // ProjectPanel
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectPanel";
            this.ResumeLayout(false);

        }
    }
}
