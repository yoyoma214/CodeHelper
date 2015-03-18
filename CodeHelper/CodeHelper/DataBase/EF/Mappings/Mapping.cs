using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class Mapping : EFBaseNode
    {
        public string Space { get; set; }
        public string XmlNs { get; set; }
        public EntityContainerMapping EntityContainerMapping { get; set; }

        public override void Parse(XmlNode dom)
        {
            this.Space = dom.Attributes["Space"].Value;
            this.XmlNs = dom.Attributes["xmlns"].Value;
            
            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EntityContainerMapping")
                {
                    var mapping = new EntityContainerMapping();
                    mapping.Parse(n);
                    mapping.Parent = this;
                    EntityContainerMapping = mapping;
                }
            }
            base.Parse(dom);
        }
    }
}
