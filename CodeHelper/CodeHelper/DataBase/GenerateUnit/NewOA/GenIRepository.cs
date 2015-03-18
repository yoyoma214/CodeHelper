using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace CodeHelper.DataBaseHelper.GenerateUnit.NewOA
{
    class GenIRepository: BaseGen
    {
        ModelType Model = null;


        public GenIRepository(ModelType model)
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
using Company.ZCH49.OASystem.Domain.Repository;");
            builder.AppendLine(@"
namespace AAA
{
");

            builder.AppendLine(string.Format(
                "\tpublic interface I" + this.Model.Name 
                + "Repository: IRepository<{0}> ,IDisposable" ,this.Model.Name));
            builder.AppendLine("\t{");
            builder.AppendLine(string.Format("\t\tList<{0}> GetList( List<Guid> id_list );",GeneratorUtil.ClassName(this.Model.Name)));            
            builder.AppendLine("\t}");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
