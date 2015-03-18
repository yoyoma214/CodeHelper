using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using Altova.Types;
using System.Windows.Forms;
using Generator.GenerateUnit;
using Generator.GenerateUnit.GenHandler;

namespace Generator.Items.DBItems
{
    class ListViewOperationNode:BaseNode
    {
        public ListViewOperationNode()
        {
            this.Text = "列表页操作项";
        }
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            menu.MenuItems.Add(new MenuItem("生成Handler",this.CreateHandler_Click));
            return menu;
        }

        void CreateHandler_Click(object sender, EventArgs args)
        {
            try
            {
                System.Xml.XmlTextWriter w = new System.Xml.XmlTextWriter("1.xml", UTF8Encoding.UTF8);
                w.WriteRaw("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                ModelNode model = (ModelNode)this.Reslove(typeof(ModelNode), null);
                w.WriteRaw(model.DataInfo.DomNode.OuterXml);
                w.Flush();
                w.Close();
               
                GenHandler gen = new GenHandler(@"Xsl/ListOperationHandler.xslt", "1.xml");
                StringBuilder builder = new StringBuilder();
                gen.Generate(builder);
                this.OnGenerate(this, builder);
            }
            catch (Exception ex)
            {
                MessageBox.Show("生成失败:" + ex.Message);
            }
        }

        ListViewOperationType dataInfo = new ListViewOperationType();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                while (this.dataInfo.HasOperationItem())
                    this.dataInfo.RemoveOperationItem();
                foreach (BaseNode node in this.Children)
                {
                    if (node is OperationItemNode)
                    {
                        this.dataInfo.AddOperationItem( (OperationItemType) node.DataInfo);
                    }
                }
                return this.dataInfo;
                //return base.DataInfo;
            }
            set
            {
                this.dataInfo = (ListViewOperationType) value;
                foreach (OperationItemType operationItem in this.dataInfo.MyOperationItems)
                {
                    OperationItemNode opNode = new OperationItemNode();
                    opNode.DataInfo = operationItem;
                    opNode.Parent = this;
                }
            }
        }
        protected override void OnEdit(object sender, EventArgs args)
        {
            //base.OnEdit(sender, args);
            EditListViewOperationFrm frm = new EditListViewOperationFrm();
            frm.UpdateItem((ListViewOperationType)this.DataInfo);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Children.Clear();

                foreach (OperationItemType op in this.dataInfo.MyOperationItems)
                {
                    OperationItemNode opNode = new OperationItemNode();
                    opNode.Name = op.Name.Value;
                    opNode.Parent = this;
                }
            }
        }
    }
}
