using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class Property : EFBaseNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public string StoreGeneratedPattern { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.Type = dom.Attributes["Type"].Value;

            if (dom.Attributes["Nullable"] != null)
            {
                if (!string.IsNullOrWhiteSpace(dom.Attributes["Nullable"].Value))
                {
                    this.Nullable = bool.Parse(dom.Attributes["Nullable"].Value);
                }
            }

            if (dom.Attributes["annotation:StoreGeneratedPattern"] != null)
            {
                if (!string.IsNullOrWhiteSpace(dom.Attributes["annotation:StoreGeneratedPattern"].Value))
                {
                    this.StoreGeneratedPattern = dom.Attributes["annotation:StoreGeneratedPattern"].Value;
                }
            }

            base.Parse(dom);
        }
    }
}
