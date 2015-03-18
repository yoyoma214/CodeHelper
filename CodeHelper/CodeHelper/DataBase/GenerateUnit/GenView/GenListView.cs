using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.IO;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    public class GenListView :BaseXSLTGen
    {
        public GenListView(string xlsPath, string sourceXmlPath)
            : base(xlsPath, sourceXmlPath)
        {
        }
        //public override void Generate(StringBuilder builder)
        //{
        //    builder.Append(this.Generate());
        //    base.Generate(builder);
        //}
    }
}
