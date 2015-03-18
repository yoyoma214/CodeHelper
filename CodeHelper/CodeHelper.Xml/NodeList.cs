using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace CodeHelper.Xml
{
    public class NodeList<T> : DataNode, IEnumerable<T> where T : DataNode,new()
    {
        public NodeList()
        {
            //var a = new List<int>();
            
        }

        public NodeList(XmlNode dom)
        {
            //this.Dom = dom.Attributes[;
            this.Dom = dom;
        }

        public void AddChild(T child)
        {
            base.AddChild(child);
            //this.Dom.AppendChild(child.Dom);
        }

        public void RemoveChild(T child)
        {
            this.Dom.RemoveChild(child.Dom);
        }


        public override string XML_TAG_NAME
        {
            get;
            set;
        }
    
        public IEnumerator<T>  GetEnumerator()
        {
            var list = new List<T>();
            foreach (XmlNode node in this.Dom.ChildNodes)
            {
                var t = new T();
                t.Dom = node;
                list.Add(t);
            }
            return list.GetEnumerator();
        }        

        public T this[int index]
        {
            get {

                if (index > this.Dom.ChildNodes.Count - 1)
                    return null;

                var t = new T();
                t.Dom = this.Dom.ChildNodes[index];
                return t;
            }
           
        }
         
        IEnumerator IEnumerable.GetEnumerator()
        {
            var list = new List<T>();
            foreach (XmlNode node in this.Dom.ChildNodes)
            {
                var t = new T();
                t.Dom = node;
                list.Add(t);
            }
            return list.GetEnumerator();
        }

    }
}
