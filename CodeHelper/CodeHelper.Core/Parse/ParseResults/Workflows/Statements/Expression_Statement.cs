using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;

namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    public class Expression_Statement:TokenPair
    {
        public Expression Expression { get; set; }

        public ExpressionStatementInfo Parse()
        {
            var rslt = new ExpressionStatementInfo(this);
            rslt.Expression = this.Expression.Parse();
            return rslt;
        }
    }
}
