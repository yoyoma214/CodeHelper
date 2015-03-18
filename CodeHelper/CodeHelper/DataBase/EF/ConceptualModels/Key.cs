using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class Key : EFBaseNode
    {
        //public string PropertyRefId { get; set; }

        public PropertyRef PropertyRef { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            //this.PropertyRefId = this.Dom.Attributes["PropertyRefId"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "PropertyRef")
                {
                    var propertyRef = new PropertyRef();
                    propertyRef.Parent = this;
                    propertyRef.Parse(n);
                    this.PropertyRef = propertyRef;
                    break;
                }
            }

            base.Parse(dom);
        }
    }
}
