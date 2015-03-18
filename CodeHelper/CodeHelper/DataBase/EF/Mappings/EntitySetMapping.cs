using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class EntitySetMapping : EFBaseNode
    {
        public string Name { get; set; }

        public Dictionary<string, EntityTypeMapping> EntityTypeMappings { get; set; }

        public EntitySetMapping()
        {
            EntityTypeMappings = new Dictionary<string, EntityTypeMapping>();
        }

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EntityTypeMapping")
                {
                    var mapping = new EntityTypeMapping();
                    mapping.Parse(n);
                    mapping.Parent = this;

                    this.EntityTypeMappings.Add(mapping.TypeName, mapping);
                }
               
            }
            base.Parse(dom);
        }
    }
}
