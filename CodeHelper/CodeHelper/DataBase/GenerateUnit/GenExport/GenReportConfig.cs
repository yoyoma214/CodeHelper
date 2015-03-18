using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.Common;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenExport
{
    class GenReportConfig : BaseGen
    {
        ModelType Model = null;

        public GenReportConfig(ModelType model)
        {
            this.Model = model;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            builder.AppendLine("<ReportConfig xmlns=\"http://tempuri.org/ReportConfig.xsd\">");
            builder.AppendLine("\t<Header>");
            //builder.AppendLine("\t\t<Background>White</Background>");
            builder.AppendLine("\t\t<ColomnBackground></ColomnBackground>");
            builder.AppendLine("\t\t<ColumnFontSize></ColumnFontSize>");
            builder.AppendLine("\t\t<ColumnFontStyle>Normal</ColumnFontStyle>");
            builder.AppendLine("\t\t<ColumnAlign>Center</ColumnAlign>");
            //builder.AppendLine("\t\t<ColumnHeight></ColumnHeight>");
            builder.AppendLine("\t\t<ColumnWidth></ColumnWidth>");
            //builder.AppendLine("\t\t<Visible>false</Visible>");
            builder.AppendLine("\t\t<IncludeColumns></IncludeColumns>");
            builder.AppendLine("\t\t<ExcludeColumns>id</ExcludeColumns>");
            builder.AppendLine("\t\t<ColumnHeaderBackground></ColumnHeaderBackground>");
            builder.AppendLine("\t\t<ColumnHeaderColor></ColumnHeaderColor>");
            builder.AppendLine("\t</Header>");

            var index = 0;
            foreach (FieldType field in this.Model.Fields)
            {
                
                builder.AppendLine("\t<Column>");
                builder.AppendFormat("\t\t<Name>{0}</Name>",field.Name);
                builder.AppendLine();
                builder.AppendFormat("\t\t<DisplayName>{0}</DisplayName>", field.Name);
                builder.AppendLine();
                if (index++ == 0)
                {
                    builder.AppendLine("\t\t<Align>Center</Align>");
                    builder.AppendLine("\t\t<FontStyle>Normal</FontStyle>");
                    builder.AppendLine("\t\t<Background>White</Background>");
                    builder.AppendLine("\t\t<Color>Black</Color>");
                    //builder.AppendLine("\t\t<Width></Width>");
                    builder.AppendLine("\t\t<FontSize></FontSize>");
                    builder.AppendLine("\t\t<HeaderColor></HeaderColor>");
                    builder.AppendLine("\t\t<HeaderBackground></HeaderBackground>");
                    builder.AppendLine("\t\t<HeaderFontStyle></HeaderFontStyle>");
                    builder.AppendLine("\t\t<HeaderAlign></HeaderAlign>");
                    builder.AppendLine("\t\t<HeaderFontWeight></HeaderFontWeight>");
                    builder.AppendLine("\t\t<HeaderFontSize></HeaderFontSize>");
                    builder.AppendLine("\t\t<HeaderHeight></HeaderHeight>");
                    builder.AppendLine("\t\t<HeaderWidth></HeaderWidth>");
                }
                builder.AppendLine("\t</Column>");                
            }

            builder.AppendLine("\t<Footer>");
            builder.AppendLine("\t\t<Visible>false</Visible>");
            builder.AppendLine("\t\t<Content>OA@Company.com</Content>");
            builder.AppendLine("\t</Footer>");
            builder.AppendLine("</ReportConfig>");

            base.Generate(builder);

        }
    }
}
