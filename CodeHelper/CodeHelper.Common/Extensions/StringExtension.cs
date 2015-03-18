using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common.Extensions
{
    public static class StringExtension
    {
        public static T JsonToObject<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}
