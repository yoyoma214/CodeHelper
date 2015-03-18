using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class MappingFragment : EFBaseNode
    {

        public string StoreEntitySet { get; set; }
        public Dictionary<string,ScalarProperty> ScalarPropertys { get; set; }

        public MappingFragment():base()
        {
            ScalarPropertys = new Dictionary<string, ScalarProperty>();
        }

        public override void Parse(XmlNode dom)
        {
            this.StoreEntitySet = dom.Attributes["StoreEntitySet"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "ScalarProperty")
                {
                    var mapping = new ScalarProperty();
                    mapping.Parse(n);
                    mapping.Parent = this;

                    this.ScalarPropertys.Add(mapping.Name, mapping);
                }

            }
            base.Parse(dom);
        }
    }
}
