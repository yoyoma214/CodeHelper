using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Items.SqlServer;
using CodeHelper.DataBaseHelper.Items.Postgres;
using CodeHelper.Core;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items
{
    public static class NodeFactory
    {
        static T CreateNode<T>(DatabaseType dbType) where T : BaseNode
        {
            if (dbType == DatabaseType.SqlServer)
            {
                if (typeof(T).Equals(typeof(FieldNode)))
                {
                    BaseNode node = new SqlFieldNode();
                    return (T)node;
                }
                if (typeof(T).Equals(typeof(ColumnNode)))
                {
                    BaseNode node = new SqlColumnNode();
                    return (T)node;
                }
            }
            if (dbType == DatabaseType.Postgres)
            {
                if (typeof(T).Equals(typeof(FieldNode)))
                {
                    BaseNode node = new PostgresFieldNode();
                    return (T)node;
                }
                if (typeof(T).Equals(typeof(ColumnNode)))
                {
                    BaseNode node = new PostgresColumnNode();
                    return (T)node;
                }
            }
            return default(T);
        }

        public static T CreateNode<T>() where T : BaseNode
        {
            if (DBGlobalService.DbType == DatabaseType.UnKnown)
            {
                System.Windows.Forms.MessageBox.Show("请确保选择一个链接节点");
                return null;
            }
            return CreateNode<T>(DBGlobalService.DbType);
        }

    }
}
