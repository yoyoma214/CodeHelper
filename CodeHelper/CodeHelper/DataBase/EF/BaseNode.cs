using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF
{
    public class EFBaseNode
    {
        EFBaseNode parent = null;

        public List<EFBaseNode> Children { get; set; }

        public EFBaseNode Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
                parent.Children.Add(value);
            }
        }

        public XmlNode Dom { get; private set; }

        public EFBaseNode()
        {

            this.Children = new List<EFBaseNode>();
        }

        public virtual void Parse(XmlNode dom)
        {
            this.Dom = dom;

            //foreach (var child in this.Children)
            //{
            //    child.Parse(child.Dom);
            //}
        }
    }
}
