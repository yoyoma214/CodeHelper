using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Argument_Expression_List : TokenPair
    {
        public List<Assignment_Expression> Assignment_expressions { get; set; }

        internal List<AssignmentExpressionInfo> Parse()
        {
            var rslt = new List<AssignmentExpressionInfo>();
            foreach (var expr in this.Assignment_expressions)
            {
                rslt.Add(expr.Parse());
            }
            return rslt;
        }
    }
}
