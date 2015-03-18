using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF.StorageModels
{
    public class Property : EFBaseNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public int? MaxLength { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.Type = dom.Attributes["Type"].Value;
            this.Nullable = bool.Parse(dom.Attributes["Nullable"].Value);

            if (dom.Attributes["MaxLength"] != null)
            {
                if (!string.IsNullOrWhiteSpace(dom.Attributes["MaxLength"].Value))
                {
                    this.MaxLength = int.Parse(dom.Attributes["MaxLength"].Value);
                }
            }

            base.Parse(dom);
        }
    }
}
