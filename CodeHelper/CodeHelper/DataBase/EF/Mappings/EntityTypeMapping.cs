using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class EntityTypeMapping : EFBaseNode
    {
        public string TypeName { get; set; }

        public Dictionary<string,MappingFragment> MappingFragments { get; set; }

        public EntityTypeMapping():base()
        {
            this.MappingFragments = new Dictionary<string, MappingFragment>();
        }

        public override void Parse(XmlNode dom)
        {
            this.TypeName = dom.Attributes["TypeName"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "MappingFragment")
                {
                    var mapping = new MappingFragment();
                    mapping.Parse(n);
                    mapping.Parent = this;

                    this.MappingFragments.Add(mapping.StoreEntitySet, mapping);
                }

            }
            base.Parse(dom);
        }
    }
}
