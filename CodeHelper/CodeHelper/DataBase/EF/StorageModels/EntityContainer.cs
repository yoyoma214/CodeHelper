using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.StorageModels
{
    public class EntityContainer : EFBaseNode
    {
        public string Name { get; set; }

        public Dictionary<string, EntitySet> EntitySets = new Dictionary<string, EntitySet>();

        public Dictionary<string, AssociationSet> AssociationSets = new Dictionary<string, AssociationSet>();

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EntitySet")
                {
                    var entitySet = new EntitySet();                    
                    entitySet.Parse(n);
                    entitySet.Parent = this;

                    EntitySets.Add(entitySet.Name, entitySet);
                }
                if (n.Name == "AssociationSet")
                {
                    var associationSet = new AssociationSet();
                    associationSet.Parse(n);
                    associationSet.Parent = this;

                    AssociationSets.Add(associationSet.Name, associationSet);                    
                }
            }

            base.Parse(dom);

        }

    }
}
