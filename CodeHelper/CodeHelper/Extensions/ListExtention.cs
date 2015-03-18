using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.DbSchema;
using Project;
using CodeHelper.Xml;
using Parser.XmlModel;
using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.DataBaseHelper.Extensions
{
    public static class ListExtention
    {
        public static List<ColumnSchema> OrderByName(this List<ColumnSchema> columns)
        {
            var list = columns.OrderBy(x => x.Name).ToList();
            return list;
        }

        public static List<FieldType> OrderByName(this NodeList<FieldType> fields)
        {
            var list = fields.OrderBy(x => x.Name).ToList();
            return list;
        }

        public static List<CodeHelper.Core.Parse.ParseResults.DataViews.FieldInfo> OrderByName(this List<CodeHelper.Core.Parse.ParseResults.DataViews.FieldInfo> fields)
        {
            var list = fields.OrderBy(x => x.VariableName).ToList();
            return list;
        }

        public static List<ParameterFieldInfo> OrderByName(this ParameterList parameters)
        {
            var list = parameters.OrderBy(x => x.Name).ToList();
            return list;
        }

        public static List<string> OrderByName(this List<string> ss)
        {
            var list = ss.OrderBy(x => x).ToList();
            return list;
        }

        public static List<CodeHelper.Core.Parse.ParseResults.DataViews.DataViewDB.OrderPair> OrderByName(this List<CodeHelper.Core.Parse.ParseResults.DataViews.DataViewDB.OrderPair> ss)
        {
            var list = ss.OrderBy(x => x.FieldName).ToList();
            return list;
        }
    }
}
