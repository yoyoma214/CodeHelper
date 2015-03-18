using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace CodeHelper.DataBaseHelper.Common
{
    static class Helper
    {
        public static string GetClassName(string name)
        {
            return name[0].ToString().ToUpper() + name.Substring(1);
        }

        public static string GetVarName(string name)
        {
            return name[0].ToString().ToLower() + name.Substring(1);
        }

        public static string GetViewMode(string name)
        {

            var viewModel = name.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
               name.Substring(3) : name;


            if (!viewModel.EndsWith("info", StringComparison.OrdinalIgnoreCase))
            {
                viewModel += "Info";
            }

            return viewModel;
        }

        public static string GetModuleName(string name)
        {
            var module = name;
            var ss = name.Split(new char[] { '_'}, StringSplitOptions.RemoveEmptyEntries);
            if ( ss.Length > 0 )
                module = ss[0];

            return module;
        }

        public static TableType FindTable(this ConnectionType conn, string name)
        {
            return conn.Tables.Where(x => x.Name == name).FirstOrDefault();
        }

        public static TableType FindView(this ConnectionType conn, string name)
        {
            return conn.Views.Where(x => x.Name == name).FirstOrDefault();
        }

        public static ColumnType FindColumn(this TableType table, string name)
        {
            return table.ColumnSet.Columns.Where(x => x.Name == name).FirstOrDefault();
        }

        public static List<TableType> SortAsc(this List<TableType> tables)
        {
            return tables.OrderBy(x => x.Name).ToList();
        }

        public static List<ColumnType> SortAsc(this List<ColumnType> columns)
        {
            return columns.OrderBy(x => x.Name).ToList();
        }

        public static TableType FindTable(this List<TableType> tables, string name)
        {
            return tables.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
