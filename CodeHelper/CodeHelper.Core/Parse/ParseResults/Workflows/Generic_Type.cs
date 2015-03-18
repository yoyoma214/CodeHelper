using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Generic_Type :TokenPair
    {
        public String Long_name { get; set; }
        public Generic_Type Header { get; set; }
        public List<Generic_Type> Parameters { get; set; }

        public GenericTypeInfo Parse()
        {
            var rslt = new GenericTypeInfo();
            if (!string.IsNullOrWhiteSpace(this.Long_name))
                rslt.Long_Name = this.Long_name;
            else
            {
                rslt.Header = this.Header.Parse();
                foreach (var p in this.Parameters)
                    rslt.Parameters.Add(p.Parse());
            }
            return rslt;
        }
    }
}
