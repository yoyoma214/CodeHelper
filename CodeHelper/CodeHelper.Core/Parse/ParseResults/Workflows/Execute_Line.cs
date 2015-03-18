using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Execute_Line : TokenPair
    {
        public string Name { get; set; }

        public List<Unit> Units { get; set; }

        public Execute_Line()
        {
            this.Units = new List<Unit>();
        }

        internal ExecuteLineInfo Parse()
        {
            var rslt = new ExecuteLineInfo();
            rslt.Name = this.Name;
            foreach (var unit in this.Units)
            {
                rslt.Units.Add(unit.Parse());
            }
            return rslt;
        }
    }
}
