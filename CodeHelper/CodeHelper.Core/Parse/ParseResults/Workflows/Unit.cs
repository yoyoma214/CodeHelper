using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Unit : TokenPair
    {
        public Node Node { get; set; }
        public Parallel Parallel { get; set; }

        //internal Unit Parse()
        //{
        //    if(Node != null )

        //}

        internal UnitInfo Parse()
        {
            var rslt = new UnitInfo();
            if (Node != null)
                rslt.Node = this.Node.Parse();
            if (this.Parallel != null)
                rslt.Parallel = this.Parallel.Parse();
            return rslt;
        }
    }
}
