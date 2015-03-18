using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.DbSchema;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenEF
{
    class GenEFMap:BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenEFMap(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(

@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace AAA
{
");

            builder.AppendLine("public class " + this.Model.Name
                + string.Format("Map:EntityTypeConfiguration<{0}>", this.Model.Name) + "{");

            builder.AppendLine(string.Format("public {0}Map()", this.Model.Name) + "{");

            ColumnSchema keyColumn = null;
            foreach (var f in this.ColumnSetNode.Columns)
            {
                if (f.IsPK)
                {
                    keyColumn = f;
                    break;//一般只有一个pk，其他情况暂不处理
                }
            }
            if (keyColumn != null)
            {
                builder.AppendLine(" // Primary Key");
                builder.AppendLine(string.Format(" HasKey(t => t.{0});", keyColumn.Name));
            }
            builder.AppendLine();

            builder.AppendLine(" // Table & Column Mappings");

            builder.AppendLine(string.Format(" ToTable(\"{0}\");", this.ColumnSetNode.Name));
            builder.AppendLine();
            //// Properties
            //Property(t => t.MailId)
            //    .IsRequired();

            //Property(t => t.Name)
            //    .IsRequired().HasMaxLength(500);

            //Property(t => t.Size)
            //    .IsRequired();

            //// Table & Column Mappings
            //ToTable("Mail_Attachment");
            //Property(t => t.Id).HasColumnName("Id");
            //Property(t => t.MailId).HasColumnName("MailId");
            //Property(t => t.Name).HasColumnName("Name");
            //Property(t => t.Size).HasColumnName("Size");

            foreach (FieldType field in this.Model.Fields.OrderByName())
            {
                builder.Append(string.Format(" Property(t => t.{0})", field.Name));

                foreach (var exp in field.Expands)
                {
                    if (exp.Key.ToString().ToLower() == "isident" && exp.Val.ToString().ToLower() == "true")
                    {
                        builder.Append(".HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)");
                        break;
                    }

                }

                if (!field.NullAble)
                {
                    builder.Append(string.Format(".IsRequired()"));
                }

                var columnSechma = this.GetColumn(field.Name);
                if (columnSechma.Size > 0)
                {
                    builder.Append(string.Format(".HasMaxLength({0})", columnSechma.Size));
                }
                if (columnSechma.DataType.Equals("decimal", StringComparison.OrdinalIgnoreCase))
                {
                    //modelBuilder.Entity<Product>().Property(product => product.Price).HasPrecision(18, 12); 
                    builder.Append(string.Format(".HasPrecision({0}, {1})", columnSechma.Precision, columnSechma.Scale));
                }
                builder.AppendLine(";");
            }
            builder.AppendLine();
            foreach (FieldType field in this.Model.Fields.OrderByName())
            {
                var columnSechma = this.GetColumn(field.Name);
                builder.Append(string.Format(" Property(t => t.{0}).HasColumnName(\"{1}\")", field.Name, columnSechma.Name));

                builder.AppendLine(";");
            }
            
            builder.AppendLine();

            builder.AppendLine(" //Relationships");
            var conn = CodeHelper.Core.DbConfig.ConnectionManager.Get(DBGlobalService.ConnectionString);
            var relations = conn.FindRelations(this.Model.Name,null);
            foreach (var r in relations)
            {
                builder.AppendFormat(" this.HasRequired(t => t.{0})", CodeHelper.Common.GenHelper.GetClassName(r.NavigateProperty));
                builder.AppendLine();
                var f_r = conn.FindRelations(r.ForeignTable,r.MainTable);
                if (f_r == null || f_r.Count == 0)
                {
                    //builder.AppendFormat(" \t.WithOptional()");
                    //builder.AppendLine();
                    builder.AppendFormat(" \t.WithMany().HasForeignKey(x => x.{0});", r.MainFK);
                }
                else
                {
                    builder.AppendFormat(" \t.WithRequiredDependent(t => t.{0});",f_r[0].NavigateProperty);
                }
                builder.AppendLine();
                builder.AppendLine();
            }
            builder.AppendLine(" }");
            builder.AppendLine(" }");
            builder.Append("}");
            base.Generate(builder);
        }

        private ColumnSchema GetColumn(string filedName)
        {            
            foreach (var f in this.ColumnSetNode.Columns)
            {
                if (f.Name == filedName)
                    return f;
            }

            return null;
        }
    }
}
