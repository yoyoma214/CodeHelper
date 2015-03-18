using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common.Extensions
{
    public static class ObjectExtension
    {
        public static string ToJson( this object obj  )
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }
    }
}
