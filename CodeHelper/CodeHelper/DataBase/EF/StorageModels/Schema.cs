using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.StorageModels
{
    public class Schema :EFBaseNode
    {
        public string Namespace { get; set; }

        public string Alias { get; set; }

        public EntityContainer EntityContainer { get; set; }

        public Dictionary<string, EntityType> EntityTypes = new Dictionary<string, EntityType>();

        public Dictionary<string, Association> Associations = new Dictionary<string, Association>();

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Namespace = dom.Attributes["Namespace"].Value;
            this.Alias = dom.Attributes["Alias"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EntityContainer")
                {
                    var  entityContainer= new EntityContainer();
                    entityContainer.Parse(n);
                    entityContainer.Parent = this;

                    EntityContainer = entityContainer;
                }
                if (n.Name == "EntityType")
                {
                    var entityType = new EntityType();
                    entityType.Parse(n);
                    entityType.Parent = this;

                    EntityTypes.Add(entityType.Name, entityType);
                }

                if (n.Name == "Association")
                {
                    var association = new Association();
                    association.Parse(n);
                    association.Parent = this;

                    Associations.Add(association.Name, association);
                }
            }

            base.Parse(dom);

            DBGlobalService.EFStorageModels = this;
        }
    }
}
