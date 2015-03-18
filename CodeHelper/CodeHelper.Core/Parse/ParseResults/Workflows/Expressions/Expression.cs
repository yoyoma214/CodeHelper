using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Expression : TokenPair
    {
        public List<Assignment_Expression> Assignment_expressions { get; set; }

        internal ExpressionInfo Parse()
        {
            var state = new ExpressionInfo();
            foreach (var ex in this.Assignment_expressions)
            {
                state.AssignmentExpressions.Add(ex.Parse());
            }
            return state;
        }
    }
}