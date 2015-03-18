using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class EndProperty:EFBaseNode
    {
        public string Name { get; set; }

        public ScalarProperty ScalarProperty { get; set; }

        public EndProperty()
            : base()
        {
        }

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
           
            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "ScalarProperty")
                {
                    var property = new ScalarProperty();
                    property.Parse(n);
                    property.Parent = this;
                    this.ScalarProperty = property;
                }    
            }
            base.Parse(dom);
        }

    }
}
