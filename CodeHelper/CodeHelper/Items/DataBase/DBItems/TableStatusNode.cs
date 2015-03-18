using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.UI;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public class TableStatusNode : BaseNode
    {
        protected TableStatusType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<TableStatusType>();

        public string Settings
        {
            get;
            set;
        }

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                return this.dataInfo;
            }
            set
            {
                this.dataInfo = (TableStatusType)value;
            }
        }

        public TableStatusNode()
        {
            this.Text = this.Name = "表状态设置";
            this.EnableDelete = false;
            this.EnableRename = false;
            this.EnableRefresh = false;
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "231";
        }

        protected override void OnEdit(object sender, EventArgs args)
        {
            var frm = new TableStatusSettingFrm(this.dataInfo);
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
