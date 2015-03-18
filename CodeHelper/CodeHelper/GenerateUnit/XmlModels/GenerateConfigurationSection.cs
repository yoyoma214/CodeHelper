using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
using System.IO;
//using Antlr4.StringTemplate;

namespace CodeHelper.GenerateUnit.XmlModels
{
    class GenerateConfigurationSection: BaseGen
    {
        XmModelDB db = null;

        public GenerateConfigurationSection(XmModelDB db)
        {
            this.db = db;
        }
        //public class MyStringTemplateErrorListener : IStringTemplateErrorListener
        //{
        //    public void Error(string msg, Exception e)
        //    {
        //        //throw new NotImplementedException();
        //    }

        //    public void Warning(string msg)
        //    {
        //        //throw new NotImplementedException();
        //    }
        //}
        public override void Generate(StringBuilder builder)
        {

            if (db == null || db.Elements == null || db.Elements.Count == 0)
                return;

            
            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Xml.Core.Nodes;
using System.Xml;");
            var builderUtil = new GeneratorUtil(builder, 0);
            builderUtil.AppendLine();
            foreach (var el in db.Elements)
            {
                Build(el, builderUtil);
                builderUtil.AppendLine();
            }
        }

        private string GetVariableName(string f)
        {
            return f[0].ToString().ToLower() + f.Substring(1);
        }

        private void Build(ElementInfo elment, GeneratorUtil builderUtil)
        {
            builderUtil.AppendFormatLine("[ConfigurationProperty(\"{0}\")]", elment.Name);
            foreach (var f in elment.Fields)
            {                
                if (f.IsGenricList)
                {
                    builderUtil.AppendFormatLine("[ConfigurationCollection(typeof({0}ConfigCollection), AddItemName = \"{1}\")]",f.GenericArgument, f.Name);                    
                    
                }
            }
            builderUtil.AppendFormat("public class {0} : ConfigurationSection", elment.Name);
            builderUtil.AppendLine("{");

            builderUtil.Entry();
            builderUtil.AppendLine( "#region properties");
            foreach (var attr in elment.XmlAttributes)
            {
                builderUtil.AppendFormatLine("[ConfigurationProperty(\"{0}\")]",attr.Name);
                builderUtil.AppendLine("public " + attr.Type + attr.Name );
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("get");
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("return this[\"" + attr.Name + "\"].ToT<" + attr.Type + ">();");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
                builderUtil.Leave();                               

                builderUtil.Entry();
                builderUtil.AppendLine("set");
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("this[\"" + attr.Name + "\"] = value;");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
            }
            builderUtil.AppendLine("#endregion properties");
            builderUtil.Leave();
            //System.Xml.XmlNode n;n.ChildNodes[0].Name
            builderUtil.Entry();
            builderUtil.AppendLine("#region fields");
            
            foreach (var field in elment.Fields)
            {
               
                if (field.IsGenricList)
                {
                    builderUtil.AppendLine("public " + field.GenericArgument + "ConfigCollection" + field.Name);
                    builderUtil.AppendLine("{");
                    builderUtil.Entry();
                    builderUtil.Append("get{");
                    builderUtil.AppendFormatLine("return ({0}ConfigCollection)base[{1}];", field.GenericArgument, field.Name);
                    builderUtil.Append("}");
                    builderUtil.Leave();
                }
                else
                {
                    builderUtil.AppendFormatLine("foreach(var node in this.Dom.ChildNodes)");
                    builderUtil.AppendLine("{");
                    builderUtil.Entry();
                    builderUtil.AppendFormatLine("if(node.Name == \"{0}\")", field.Name);
                    builderUtil.AppendLine("{");
                    builderUtil.Entry();
                    builderUtil.AppendFormatLine("return new {0}(node);", field.Name);
                    builderUtil.Leave();
                    builderUtil.AppendLine("}");
                    builderUtil.AppendLine("}");
                    
                }
                builderUtil.Leave();
                builderUtil.AppendLine("}");
                builderUtil.AppendLine("");
                builderUtil.AppendLine("}");
            }

            builderUtil.AppendLine("#endregion fields");
            builderUtil.Leave();

            builderUtil.Entry();
            builderUtil.AppendLine(string.Format("public {0}()" ,elment.Name));
            builderUtil.AppendLine("{");
            builderUtil.AppendLine("}");
            builderUtil.AppendLine(string.Format("public {0}(XmlNode dom):base(dom)" ,elment.Name));
            builderUtil.AppendLine("{");
            builderUtil.AppendLine("}");
            builderUtil.Leave();
            
            builderUtil.AppendLine("}");            
        }

        private void Build(FieldInfo field, GeneratorUtil builderUtil)
        {

        }

        private void Build(FieldGroupInfo fieldGroup, GeneratorUtil builderUtil)
        {

        }

        private void Build(XmlAttributeInfo field, GeneratorUtil builderUtil)
        {

        }

        private void Build(AttributeGroupInfo field, GeneratorUtil builderUtil)
        {

        }

    }
}