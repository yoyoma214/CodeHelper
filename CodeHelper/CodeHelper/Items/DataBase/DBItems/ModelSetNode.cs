using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class ModelSetNode:BaseNode
    {
        public ModelSetNode()
        {
            this.Text = this.Name = "模型";
            this.EnableDelete = false;
            //this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "133";
        }
        public override void Save()
        {
            base.Save();
        }
    }
}
