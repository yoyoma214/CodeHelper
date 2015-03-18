using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common.Extensions
{
    public static class StringBuilderExtension
    {
        public static void AppendFormatLine(this StringBuilder builder,string format, params object[] args)
        {
            builder.AppendFormat(format, args);
            builder.AppendLine();
        }      
    }
}
