using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
//using Generator.Config;

namespace Generator.Items.DBItems
{
    class CustomModelSetNode:BaseNode
    {
        public CustomModelSetNode()
            : base()
        {
            this.TreeNode.Name = this.TreeNode.Text = "模型";
        }
        //public ModelPkgNode(TreeNode treeNode)
        //    : base(treeNode)
        //{
        //}
        public override ContextMenu GetPopMenu()
        {
            ContextMenu menu = base.GetPopMenu();
            menu.MenuItems.Add("新增模型", this.NewModel_Click);
            return menu;
        }
        void NewModel_Click(object sender, EventArgs args)
        {
            ModelNode child = new ModelNode();
            child.Text = child.Name = Guid.NewGuid().ToString();
            child.ModelType = ModelNode.SourceType.FromCustom;
            this.Children.Add(child);
        }
        public override void Save()
        {                     
            //foreach (ModelNode node in this.Children)
            //{
            //    GlobalService.CurrentProject.CustomModelSet.AddModel(
            //        (Project.ModelType)node.DataInfo);
            //}
            base.Save();
        }
        private CustomModelSetType dataInfo = new CustomModelSetType();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                while (this.dataInfo.HasModel())
                    this.dataInfo.RemoveModel();

                foreach (ModelNode node in this.Children)
                {
                    this.dataInfo.AddModel((ModelType)node.DataInfo);
                }
                return this.dataInfo;
            }
            set
            {
                this.dataInfo = (CustomModelSetType)value;
                this.Children.Clear();
                foreach (ModelType modelType in this.dataInfo.MyModels)
                {
                    ModelNode modelNode = new ModelNode();
                    modelNode.DataInfo = modelType;
                    modelNode.Parent = this;
                }
            }
        }
    }
}
