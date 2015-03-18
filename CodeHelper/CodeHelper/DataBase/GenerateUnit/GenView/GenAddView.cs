using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.IO;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenAddView : BaseXSLTGen
    {
        public GenAddView(string xlsPath, string sourceXmlPath):base(xlsPath,sourceXmlPath)
        { }

        //public override void Generate(StringBuilder builder)
        //{
        //    builder.Append(this.Generate());
        //    base.Generate(builder);
        //}
    }
}
