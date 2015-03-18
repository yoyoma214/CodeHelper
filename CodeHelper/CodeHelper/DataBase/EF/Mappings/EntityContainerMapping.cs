using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class EntityContainerMapping :EFBaseNode
    {
        public string StorageEntityContainer { get; set; }
        public string CdmEntityContainer { get; set; }

        public Dictionary<string, EntitySetMapping> EntitySetMappings { get; set; }
        public Dictionary<string, AssociationSetMapping> AssociationSetMappings { get; set; }

        public EntityContainerMapping()
        {
            this.EntitySetMappings = new Dictionary<string, EntitySetMapping>();
            this.AssociationSetMappings = new Dictionary<string, AssociationSetMapping>();
        }

        public override void Parse(XmlNode dom)
        {
            this.StorageEntityContainer = dom.Attributes["StorageEntityContainer"].Value;
            this.CdmEntityContainer = dom.Attributes["CdmEntityContainer"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EntitySetMapping")
                {
                    var mapping = new EntitySetMapping();
                    mapping.Parse(n);
                    mapping.Parent = this;

                    this.EntitySetMappings.Add(mapping.Name, mapping);
                }
                else if (n.Name == "AssociationSetMapping")
                {
                    var mapping = new AssociationSetMapping();
                    mapping.Parse(n);
                    mapping.Parent = this;

                    this.AssociationSetMappings.Add(mapping.Name, mapping);
                }
            }
            base.Parse(dom);
        }
    }
}
