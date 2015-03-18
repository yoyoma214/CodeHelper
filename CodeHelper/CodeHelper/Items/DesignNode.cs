using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items
{
    class DesignNode : BaseNode
    {
        public DesignNode()
            : base()
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "083";
            this.Text = "设计库";
        }
    }
}
