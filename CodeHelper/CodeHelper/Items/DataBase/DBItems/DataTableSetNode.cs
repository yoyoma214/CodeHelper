using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    class DataTableSetNode:BaseNode
    {
        public DataTableSetNode()
        {
            this.Text = this.Name = "数据表";
            this.EnableDelete = false;
        }
        public override void Save()
        {
            base.Save();
        }
    }
}
