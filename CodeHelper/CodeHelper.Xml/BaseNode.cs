using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Xml.Core.Nodes;
using System.Xml;
using CodeHelper.Xml.Extension;

namespace CodeHelper.Xml
{
    public delegate void AnyProperyChanged(string property, object oldValue, object newVal);
    public delegate void ProperyChanged<T>(T oldValue, T newVal);

    public class DataNode : INode
    {
        public event AnyProperyChanged OnAnyProperyChanged;

        public void FireAnyProperyChanged(string property, object oldValue, object newVal)
        {
            if (this.OnAnyProperyChanged != null && (oldValue != newVal))
            {
                this.OnAnyProperyChanged(property, oldValue, newVal);
            }
        }

        public DataNode()
        {
        }

        public DataNode(XmlNode dom)
        {
            //this.Dom = dom.Attributes[;
            //this.OwnerDocument = dom.OwnerDocument;
            this.Dom = dom;
        }

        public DataNode(Document document)
        {
            //this.Dom = dom.Attributes[;
            this.Dom = document.Root.Dom;
            //this.OwnerDocument = document;
        }

        //public BaseNode(string file)
        //{
        //    var doc = new Document();
        //    doc.Load(file);
        //    this.Dom = doc.Root.Dom;
        //}
        //public BaseNode(string name,XmlDocument doc)
        //{
        //    var dom = doc.CreateElement(name);
        //    this.Dom = dom;
        //}

        public XmlNode Dom
        {
            get;
            internal set;
        }

        protected virtual void Parse()
        {

        }

        public void RemoveSelf()
        {
            this.Dom.ParentNode.RemoveChild(this.Dom);
        }

        public void RemoveChild(DataNode node)
        {
            this.Dom.RemoveChild(node.Dom);
        }

        public void RemoveAll()
        {
            this.Dom.RemoveAll();
        }

        public void RemoveChildren(List<DataNode> nodes)
        {
            nodes.ForEach(x => this.Dom.RemoveChild(x.Dom));
        }

        public List<DataNode> Children
        {
            get
            {
                var list = new List<DataNode>();
                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    list.Add(new DataNode(node));
                }

                return list;
            }
        }

        public void AddChild(DataNode node)
        {
            this.Dom.AppendChild(node.Dom);
        }

        public DataNode Clone()
        {
            return new DataNode(this.Dom.CloneNode(true));
        }

        public void AddChildren(List<DataNode> nodes)
        {
            nodes.ForEach(x => this.Dom.AppendChild(x.Dom));
        }

        public virtual string XML_TAG_NAME
        {
            get;
            set;
        }

        //public Document OwnerDocument
        //{
        //    get;
        //    set;
        //}

        public int Count
        {
            get
            {
                return this.Dom.ChildNodes.Count;
            }
        }

        public DataNode this[int index]
        {
            get
            {
                if (index > this.Dom.ChildNodes.Count - 1)
                    return null;

                return new DataNode(this.Dom.ChildNodes[index]);
            }
        }

        //public T CreateNode<T>() where T : DataNode, new()
        //{
        //    var t = OwnerDocument.CreateNode<T>();
        //    t.OwnerDocument = OwnerDocument;
        //    return t;
        //}


        public virtual string Id
        {  get; set; }
    }
}
