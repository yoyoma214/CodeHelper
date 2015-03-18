using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Ref_Workflow : TokenPair
    {
        public string Target { get; set; }

        internal RefWorkflowInfo Parse()
        {
            var rslt = new RefWorkflowInfo();
            
            rslt.Target = this.Target == null ? null : this.Target.Trim().Replace("\"","");
            rslt.TokenPair = this;
            return rslt;
        }
    }
}
