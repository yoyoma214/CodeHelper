using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class PropertyRef : EFBaseNode
    {
        public string Name { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;            

            base.Parse(dom);
        }
    }
}
