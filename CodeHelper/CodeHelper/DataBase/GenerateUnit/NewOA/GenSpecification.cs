using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace CodeHelper.DataBaseHelper.GenerateUnit.NewOA
{
    class GenSepcification: BaseGen
    {
        ModelType Model = null;


        public GenSepcification(ModelType model)
        {
            this.Model = model;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(
@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.ZCH49.OASystem.Domain.Specification;

namespace AAA
{
");

            builder.AppendLine(string.Format(
                "     public static class " + this.Model.Name
                + "Specification", this.Model.Name));
            builder.AppendLine("     {");
            //builder.AppendLine(string.Format("\t\tList<{0}> GetList( List<Guid> id_list )", GeneratorUtil.ClassName(this.Model.Name.Value)));
            builder.AppendLine();
            builder.Append(@"        public static ISpecification<{0}> GetList( List<Guid> id_list )
        {
".Replace("{0}", this.Model.Name));
            FieldType idField = null;
            foreach(var f in this.Model.Fields)
            {
                if ( f.Name == "Id")
                {
                    idField = f;
                }
            }
            //builder.AppendLine();
            if (idField.NullAble)
            {
                builder.AppendFormat("          return new DirectSpecification<{0}>(x => id_list.Contains(x.Id??default(Guid)));", this.Model.Name);
            }
            else
            {
                builder.AppendFormat("          return new DirectSpecification<{0}>(x => id_list.Contains(x.Id));", this.Model.Name);
            }
            builder.AppendLine();
            builder.AppendLine("        }");
            builder.AppendLine("   }");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
