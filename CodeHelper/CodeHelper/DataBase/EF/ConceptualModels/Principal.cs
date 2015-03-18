using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class Principal : EFBaseNode
    {
        public PropertyRef PropertyRef { get; set; }

        public string Role { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Role = dom.Attributes["Role"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                var propertyRef = new PropertyRef();
                propertyRef.Parse(n);
                this.PropertyRef = propertyRef;
            }

            base.Parse(dom);
        }
    }
}
