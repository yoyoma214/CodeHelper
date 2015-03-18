using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.StorageModels
{
    public class EntityType : EFBaseNode
    {
        public string Name { get; set; }

        public Key Key { get; set; }

        public Dictionary<string, Property> Propertys = new Dictionary<string, Property>();

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;

            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "Key")
                {
                    var key = new Key();
                    key.Parse(n);
                    key.Parent = this;
                    this.Key = key;
                }

                if (n.Name == "Property")
                {
                    var property = new Property();
                    property.Parse(n);
                    property.Parent = this;
                    this.Propertys.Add(property.Name, property);
                }
            }
        }
    }
}
