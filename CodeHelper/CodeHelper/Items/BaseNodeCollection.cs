using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CodeHelper.Items
{
    public class BaseNodeCollection : IList<BaseNode>, ICollection, IEnumerable
    {
        BaseNode owner = null;
        public BaseNodeCollection(BaseNode owner)
        {
            this.owner = owner;
        }

        List<BaseNode> nodes = new List<BaseNode>();


        #region IList<BaseNode> 成员

        public int IndexOf(BaseNode item)
        {
            return nodes.IndexOf(item);
        }

        public void Insert(int index, BaseNode item)
        {
            this.nodes.Insert(index, item);
            this.owner.TreeNode.Nodes.Insert(index, item.TreeNode);
        }

        public void RemoveAt(int index)
        {
            this.nodes.RemoveAt(index);
            this.owner.TreeNode.Nodes.RemoveAt(index);
        }

        public BaseNode this[int index]
        {
            get
            {
                return this.nodes[index];
            }
            set
            {
                this.nodes[index] = value;
                this.owner.TreeNode.Nodes[index] = value.TreeNode;
            }
        }

        #endregion

        #region ICollection<BaseNode> 成员

        public void Add(BaseNode item)
        {
            this.nodes.Add(item);
            item.Parent = this.owner;
            this.owner.TreeNode.Nodes.Add(item.TreeNode);
        }

        public void Clear()
        {
            this.nodes.Clear();
            this.owner.TreeNode.Nodes.Clear();
        }

        public bool Contains(BaseNode item)
        {
            return this.nodes.Contains(item);
        }

        public void CopyTo(BaseNode[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.nodes.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(BaseNode item)
        {
            this.owner.TreeNode.Nodes.Remove(item.TreeNode);
            return this.nodes.Remove(item);
        }

        #endregion

        #region IEnumerable<BaseNode> 成员

        public IEnumerator<BaseNode> GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }

        #endregion

        #region IEnumerable 成员

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.nodes.GetEnumerator();
        }

        #endregion

        #region ICollection 成员

        public void CopyTo(Array array, int index)
        {
            if (array is BaseNode[])
            {
                this.nodes.CopyTo(array as BaseNode[], index);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool IsSynchronized
        {
            get { throw new Exception("不支持同步操作"); }
        }

        private object _SyncRoot = new object();
        public object SyncRoot
        {
            get { return _SyncRoot; }
        }

        #endregion
    }
}
