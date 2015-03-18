using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class ScalarProperty :EFBaseNode
    {
        public string Name { get; set; }
        public string ColumnName { get; set; }

        public override void Parse(XmlNode dom)
        {
            this.Name = dom.Attributes["Name"].Value;
            this.ColumnName = dom.Attributes["ColumnName"].Value;

            base.Parse(dom);
        }
    }
}
