using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Expression : TokenPair
    {
        public List<Assignment_Expression> Assignment_expressions { get; set; }

        internal ExpressionStatementInfo Parse()
        {
            var state = new ExpressionStatementInfo(this);
            foreach (var ex in this.Assignment_expressions)
            {
                state.AssignmentExpressions.Add(ex.Parse());
            }
            return state;
        }
    }
}