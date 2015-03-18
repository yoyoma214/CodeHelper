using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core;

namespace CodeHelper
{
    public static class Configer
    {
        public static DatabaseType WFDBType
        {
            get
            {
                var s = System.Configuration.ConfigurationManager.AppSettings["WFDBType"];
                var obj = Enum.Parse(typeof(DatabaseType), s, true);
                if (obj == null)
                    return DatabaseType.SqlServer;

                return (DatabaseType)obj;
            }
        }

        public static string WFConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["WFConnectionString"];
            }
        }
    }
}
