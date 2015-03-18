using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace CodeHelper.Domain
{
    public static class Configer
    {
        //private static string _WFConnectionString = System.Configuration.ConfigurationManager.AppSettings["WFConnectionString"];
        public static string WFConnectionString
        {
            get
            {
                var assembly = Assembly.GetAssembly(typeof(Configer));
                var configuration = ConfigurationManager.OpenExeConfiguration(assembly.CodeBase.Substring(8));
                var _WFConnectionString = configuration.AppSettings.Settings["WFConnectionString"].Value;
                return _WFConnectionString;
            }
        }
    }
}
