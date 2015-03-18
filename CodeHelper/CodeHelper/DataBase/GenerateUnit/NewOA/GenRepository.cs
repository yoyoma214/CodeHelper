using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace CodeHelper.DataBaseHelper.GenerateUnit.NewOA
{
    class GenRepository: BaseGen
    {
        ModelType Model = null;


        public GenRepository(ModelType model)
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
using Company.ZCH49.OASystem.Data;
using Company.ZCH49.OASystem.Data.Repository;

namespace AAA
{
");

            var entityName = GeneratorUtil.ClassName(this.Model.Name);

            builder.AppendLine(string.Format(
                "\tpublic class " + this.Model.Name
                + "Repository: Repository<{0}>, I{0}Repository", this.Model.Name));
            builder.AppendLine("\t{");
            builder.AppendLine(string.Format(
               "\t\tpublic {0}Repository(IQueryableUnitOfWork unitOfWork)" , this.Model.Name));
            builder.AppendLine(string.Format("\t\t\t:base(unitOfWork)"));
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t}");
            builder.AppendLine();

            builder.AppendLine(string.Format("\t\tpublic List<{0}> GetList( List<Guid> id_list )", entityName));
            builder.AppendLine("\t\t{");
            builder.AppendLine(string.Format("\t\t\treturn this.GetAll({0}Specification.GetList(id_list)).ToList();", entityName));
            builder.AppendLine("\t\t}");
            builder.AppendLine();

            builder.AppendLine("\t\tpublic void Dispose()");
            builder.AppendLine("\t\t{");
            builder.AppendLine("\t\t\t//throw new NotImplementedException();");
            builder.AppendLine("\t\t}");

            builder.AppendLine("\t}");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
