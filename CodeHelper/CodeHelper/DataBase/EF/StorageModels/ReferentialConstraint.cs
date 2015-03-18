using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeHelper.DataBaseHelper.EF.StorageModels
{
    public class ReferentialConstraint : EFBaseNode
    {
        public Principal Principal { get; set; }
        public Dependent Dependent { get; set; }

        public override void Parse(System.Xml.XmlNode dom)
        {
            foreach (XmlNode n in dom.ChildNodes)
            {
                if (n.Name == "Principal")
                {
                    var principal = new Principal();
                    principal.Parse(n);
                    principal.Parent = this;
                    this.Principal = principal;
                }
                else if (n.Name == "Dependent")
                {
                    var dependent = new Dependent();
                    dependent.Parse(n);
                    dependent.Parent = this;
                    this.Dependent = dependent;
                }
            }
            base.Parse(dom);
        }
    }
}
