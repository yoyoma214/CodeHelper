using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class AssociationSet : EFBaseNode
    {
        public string Name { get; set; }

        public string Association { get; set; }

        public Dictionary<string, End> Ends = new Dictionary<string, End>();

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.Association = dom.Attributes["Association"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "End")
                {
                    var end = new End();
                    end.Parse(n);
                    end.Parent = this;
                    this.Ends.Add(end.Role, end);
                }
            }

            base.Parse(dom);
        }

        public class End : EFBaseNode
        {
            public string Role { get; set; }

            public string EntitySetId { get; set; }

            public EntitySet EntitySet
            {
                get
                {
                    return DBGlobalService.EFConceptualModels.EntityContainer.EntitySets[EntitySetId];
                }
            }

            public override void Parse(XmlNode dom)
            {
                this.Role = dom.Attributes["Role"].Value;
                this.EntitySetId = dom.Attributes["EntitySet"].Value;


                base.Parse(dom);
            }
        }
    }
}
