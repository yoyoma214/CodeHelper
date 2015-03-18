using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.Workflows.Statements;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class State : TokenPair
    {
        public List<Statement> Statements { get; set; }

        internal List<StatementInfo> Parse(ClzInfo model)
        {
            var rslt = new List<StatementInfo>();
            
            for(var i = 0 ; i < this.Statements.Count ; i ++)
            {
                var s = this.Statements[i].Parse(model);
                rslt.Add(s);

                if (i > 0)
                    s.Region.Prev = rslt[i - 1].Region;
            }

            return rslt;
        }
    }
}