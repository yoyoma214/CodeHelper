using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class NavigationProperty : EFBaseNode
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string FromRole { get; set; }
        public string ToRole { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.Relationship = dom.Attributes["Relationship"].Value;
            this.FromRole = dom.Attributes["FromRole"].Value;
            this.ToRole = dom.Attributes["ToRole"].Value;

            base.Parse(dom);
        }
    }
}
