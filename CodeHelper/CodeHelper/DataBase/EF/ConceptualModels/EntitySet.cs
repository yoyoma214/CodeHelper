using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.ConceptualModels
{
    public class EntitySet : EFBaseNode
    {
        public string Name { get; set; }
        public string EntityType { get; set; }
        //public string StoreType { get; set; }
        //public string Schema { get; set; }

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.EntityType = dom.Attributes["EntityType"].Value;
            //this.StoreType = dom.Attributes["store:Type"].Value;
            //this.Schema = dom.Attributes["Schema"].Value;
            base.Parse(dom);
        }
    }
}
