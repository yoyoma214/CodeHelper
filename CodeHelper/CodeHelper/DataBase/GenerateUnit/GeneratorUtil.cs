using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.GenerateUnit
{
    class GeneratorUtil
    {        
        /// <summary>
        /// 顶层区域的tab数量
        /// </summary>
        public static int BaseTabNumber = 2;
        public static string TabString(int num)
        {
            string r = "";
            for (int i = 0; i < num + BaseTabNumber; i++)
            {
                r += "\t";
            }
            return r;
        }
        public static string TabStringNewLine(int num)
        {
            string r = "\n";
            for (int i = 0; i < num + BaseTabNumber; i++)
            {
                r += "\t";
            }
            return r;
        }

        public static string VariableName(string s)
        {
            if ( string.IsNullOrWhiteSpace(s))
                return "";

            if ( s.Length == 1)
                return s.ToLower();

            return s.ToLower()[0] + s.Substring(1);
        }

        public static string ClassName(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";

            if (s.Length == 1)
                return s.ToUpper();

            return s.ToUpper()[0] + s.Substring(1);
        }
    }
}
