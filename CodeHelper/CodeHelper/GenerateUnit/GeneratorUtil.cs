using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.GenerateUnit
{
    class GeneratorUtil
    {
        /// <summary>
        /// 顶层区域的tab数量
        /// </summary>
        //public int BaseTabNumber = 0;

        private int Tabs = 0;

        //public static string TabString(int num)
        //{
        //    string r = "";
        //    for (int i = 0; i < num + BaseTabNumber; i++)
        //    {
        //        r += "\t";
        //    }
        //    return r;
        //}
        //public static string TabStringNewLine(int num)
        //{
        //    string r = "\n";
        //    for (int i = 0; i < num + BaseTabNumber; i++)
        //    {
        //        r += "\t";
        //    }
        //    return r;
        //}

        private StringBuilder Builder = null;

        public GeneratorUtil(StringBuilder builder, int baseTabNumber)
        {
            Builder = builder;
            Tabs = baseTabNumber;
        }

        public void Entry()
        {
            Tabs++;
        }

        public void Leave()
        {
            Tabs--;
        }

        public void AppendFormat(string format, params object[] args)
        {
            Builder.AppendFormat(new String('\t', Tabs) + format, args);
        }

        public void AppendFormatLine(string format, params object[] args)
        {
            Builder.AppendFormat(new String('\t', Tabs) + format, args);
            Builder.AppendLine();
        }

        public void AppendLine()
        {
            Builder.AppendLine();
        }

        public void AppendLine(string value)
        {
            Builder.AppendLine(new String('\t', Tabs) + value);
        }

        public void Append(string value)
        {
            Builder.Append(new String('\t', Tabs) + value);
        }
    }
}
