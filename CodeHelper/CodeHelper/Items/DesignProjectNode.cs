using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items
{
    class DesignProjectNode :BaseNode
    {
        public DesignProjectNode():base()
        {
            this.Text = "设计库";
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "067";
        }
    }
}
