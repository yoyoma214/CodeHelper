using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.IO;

namespace CodeHelper.DataBaseHelper.GenerateUnit
{
    public class BaseXSLTGen :BaseGen
    {
        protected string XlsPath { get; set; }
        protected string SourceXmlPath { get; set; }
        
        public BaseXSLTGen(string xlsPath, string sourceXmlPath)
        {
            this.XlsPath = xlsPath;
            this.SourceXmlPath = sourceXmlPath;
        }
        public void Generate(StringBuilder builder)
        {
            builder.Append(this.Generate());
        }
        protected string Generate()
        {
            XslCompiledTransform xslt = new XslCompiledTransform(true);
            XsltSettings axslset = new XsltSettings();
            axslset.EnableScript = true;
            xslt.Load(this.XlsPath, axslset, new System.Xml.XmlUrlResolver());
            MemoryStream stream = new MemoryStream();
            xslt.Transform(this.SourceXmlPath, null, stream);
            
            byte[] buffer = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            int count = 0;
            while (count < stream.Length)
            {
                count += stream.Read(buffer, 0, buffer.Length);
            }
            stream.Flush();
            stream.Close();
            string s = UTF8Encoding.UTF8.GetString(buffer).Replace("&gt;", ">").Replace("&lt;", "<").Replace("&amp;", "&").Trim('\r', '\n', ' ');
            return s;            
        }
    }
}
