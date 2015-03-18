using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using CodeHelper.Items.DataModel;
//using CodeHelper.Items.ViewModel;
//using CodeHelper.Items.WorkFlow;
//using CodeHelper.Items.DataView;
using CodeHelper.Items.XmlModel;

namespace CodeHelper.Items
{
    public static class NodeFactory
    {
        //static T CreateNode<T>(DatabaseType dbType) where T : BaseNode
        //{
        //    if (dbType == DatabaseType.SqlServer)
        //    {
        //        if (typeof(T).Equals(typeof(FieldNode)))
        //        {
        //            BaseNode node = new SqlFieldNode();
        //            return (T)node;
        //        }
        //        if (typeof(T).Equals(typeof(ColumnNode)))
        //        {
        //            BaseNode node = new SqlColumnNode();
        //            return (T)node;
        //        }
        //    }
        //    if (dbType == DatabaseType.Postgres)
        //    {
        //        if (typeof(T).Equals(typeof(FieldNode)))
        //        {
        //            BaseNode node = new PostgresFieldNode();
        //            return (T)node;
        //        }
        //        if (typeof(T).Equals(typeof(ColumnNode)))
        //        {
        //            BaseNode node = new PostgresColumnNode();
        //            return (T)node;
        //        }
        //    }
        //    return default(T);
        //}

        //public static T CreateNode<T>() where T : BaseNode
        //{
        //    if (GlobalService.DbType == DatabaseType.UnKnown)
        //    {
        //        System.Windows.Forms.MessageBox.Show("请确保选择一个链接节点");
        //        return null;
        //    }
        //    return CreateNode<T>(GlobalService.DbType);
        //}

        public static BaseNode Create(Dict.NodeType nodeType , string name = null, string text = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
            }

            BaseNode node = null;
            if (nodeType == Dict.NodeType.Unknown)
                throw new Exception("必须有节点类型");

            if (nodeType == Dict.NodeType.Project)
                node = new DesignProjectNode();
            if (nodeType == Dict.NodeType.XmlModelSet)
                node = new XmlModelSetNode();
            if (nodeType == Dict.NodeType.XmlModel)
                node = new XmlModelNode();
            if (nodeType == Dict.NodeType.DataModelSet)
                node= new DataModelSetNode();
            if (nodeType == Dict.NodeType.DataModel)
                node = new DataModelNode();
            //if (nodeType == Dict.NodeType.DataViewSet)
            //    node = new DataViewSetNode();
            //if (nodeType == Dict.NodeType.DataView)
            //    node = new DataViewNode();
            //if (nodeType == Dict.NodeType.ViewModel)
            //    node = new ViewModelNode();
            //if (nodeType == Dict.NodeType.ViewModelSet)
            //    node = new ViewModelSetNode();
            //if (nodeType == Dict.NodeType.WorkFlow)
            //    node = new WorkFlowNode();
            //if (nodeType == Dict.NodeType.WorkFlowSet)
            //    node = new WorkFlowSetNode();

            if (node != null)
            {
                if (name != null) node.Name = name;
                if (text != null) node.Text = text;
            }

            return node;
        }
    }
}
