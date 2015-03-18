using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
//using Antlr4.StringTemplate;
using System.IO;
using NVelocity.App;
using NVelocity.Runtime;
using NVelocity;

namespace CodeHelper.GenerateUnit.XmlModels
{
    class GenDomOperClass : BaseGen
    {
        XmModelDB db = null;

        public GenDomOperClass(XmModelDB db)
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

            VelocityEngine vltEngine = new VelocityEngine();
            vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, @"file");
            builder.Clear();
            // 模板存放目录

            vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, @"..\CodeHelper\GenerateUnit\XmlModels");

            vltEngine.Init();

            // 定义一个模板上下文

            VelocityContext vltContext = new VelocityContext();



            // 传入模板所需要的参数

            //vltContext.Put("Title", "NVelocity 文件模板例子 ");

            vltContext.Put("model", db);
            var dict = new Dictionary<string,bool>();
            dict.Add("test",true);
            vltContext.Put("dict", dict);



            // 获取我们刚才所定义的模板，上面已设置模板目录，此处用相对路径即可

            var vltTemplate = vltEngine.GetTemplate("GenDomOperClass.gen.cs");



            // 定义一个字符串输出流

            StringWriter vltWriter = new StringWriter();



            // 根据模板的上下文，将模板生成的内容写进刚才定义的字符串输出流中

            vltTemplate.Merge(vltContext, vltWriter);



            // 输出字符串流中的数据

            var rr = vltWriter.GetStringBuilder().ToString();
            builder.Append(rr);

            base.Generate(builder);
            return;
//            //var g = new Antlr4.StringTemplate.TemplateGroup();
//            //g = Antlr4.StringTemplate.TemplateGroup.DefaultGroup;

//            ////g.LoadGroupFile(@"..\CodeHelper\GenerateUnit\XmlModels", "GenDomOperClass");
//            ////g.LoadGroupFile(@"", @"..\CodeHelper\GenerateUnit\XmlModels\GenDomOperClass");
//            ////g.LoadGroupFile(@"D:\workspace\CodeHelper\CodeHelper\GenerateUnit\XmlModels\", @"GenDomOperClass.stg");
//            //g.LoadGroupFile("", @"/D:\workspace\CodeHelper\CodeHelper\GenerateUnit\XmlModels\GenDomOperClass.stg");
//            //Uri uri = new Uri(@"D:\workspace\CodeHelper\CodeHelper\GenerateUnit\XmlModels\GenDomOperClass.stg");
//            var g = new TemplateGroupString(File.ReadAllText(@"D:\workspace\CodeHelper\CodeHelper\GenerateUnit\XmlModels\GenDomOperClass.stg"));
//            //var g = StringTemplateGroup.LoadGroup(@"..\CodeHelper\GenerateUnit\XmlModels\GenDomOperClass");
//            //g.ErrorListener = new MyStringTemplateErrorListener();
//            //g..RefreshInterval = new TimeSpan(1000);
//            builder.Clear();

//            var f = db.Elements.ElementAt(0).Fields[0];

//            //var gen = g.GetInstanceOf("gen");
//            //gen.SetAttribute("model", db);

//            var gen = g.GetInstanceOf("gen");
//            gen.Add("model", db);
//            var duck = new Duck();
//            gen.Add("duck", duck);
//            //gen.Add("usings", db.UsingNameSpaces);

//            var r2 = gen.Render();
//            builder.Append(r2);

//            base.Generate(builder);
//            return;
//            builder.AppendLine(@"using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using CodeHelper.Xml.Core.Nodes;
//using System.Xml;");
//            var builderUtil = new GeneratorUtil(builder, 0);
//            builderUtil.AppendLine();
//            foreach (var el in db.Elements)
//            {
//                Build(el, builderUtil);
//                builderUtil.AppendLine();
//            }
        }

        private string GetVariableName(string f)
        {
            return f[0].ToString().ToLower() + f.Substring(1);
        }

        private void Build(ElementInfo elment, GeneratorUtil builderUtil)
        {
            builderUtil.AppendFormat("public class {0} : BaseNode", elment.Name);
            builderUtil.AppendLine("{");

            builderUtil.Entry();
            builderUtil.AppendLine( "#region 属性");
            foreach (var attr in elment.XmlAttributes)
            {
                builderUtil.AppendLine("public " + attr.Type + attr.Name );
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("get");
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("return this.Dom.Attributes[\"" + attr.Name + "\"].ToT<" + attr.Type + ">();");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
                builderUtil.Leave();                               

                builderUtil.Entry();
                builderUtil.AppendLine("set");
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendLine("this.Dom.Attributes[\"" + attr.Name + "\"] = value;");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
                builderUtil.Leave();
                builderUtil.AppendLine("}");
            }
            builderUtil.AppendLine("#endregion 属性");
            builderUtil.Leave();
            //System.Xml.XmlNode n;n.ChildNodes[0].Name
            builderUtil.Entry();
            builderUtil.AppendLine("#region 字段");
            
            foreach (var field in elment.Fields)
            {
                builderUtil.AppendLine("public " + field.Type + " " + field.Name);
                builderUtil.AppendLine("{");
                builderUtil.Entry();
                builderUtil.AppendFormatLine("get");
                builderUtil.Entry();
                builderUtil.AppendLine("{");
                if (field.Type.StartsWith("List<"))
                {

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
            
            builderUtil.AppendLine("#endregion 字段");
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
