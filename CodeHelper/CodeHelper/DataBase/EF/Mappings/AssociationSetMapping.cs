using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class AssociationSetMapping : EFBaseNode
    {
        public string Name { get; set; }

        public string TypeName { get; set; }

        public string StoreEntitySet { get; set; }

        public Dictionary<string, EndProperty> EndPropertys { get; set; }

        public Condition Condition { get; set; }

        public AssociationSetMapping()
        {
            this.EndPropertys = new Dictionary<string, EndProperty>();
        }

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.TypeName = dom.Attributes["TypeName"].Value;
            this.StoreEntitySet = dom.Attributes["StoreEntitySet"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "EndProperty")
                {
                    var end = new EndProperty();
                    end.Parse(n);
                    end.Parent = this;
                    this.EndPropertys.Add(end.Name, end);
                }
                else if (n.Name == "Condition")
                {
                    var condition = new Condition();
                    condition.Parse(dom);
                    condition.Parent = this;
                    this.Condition = condition;
                }
            }
            base.Parse(dom);
        }
    }
}
