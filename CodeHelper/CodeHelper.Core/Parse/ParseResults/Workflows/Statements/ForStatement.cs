/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows.Statements;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using CodeHelper.Core.Parse.ParseResults.Workflows;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{

    /**
     *
     * @author Administrator
     */
    public class ForStatement : TokenPair
    {
        public Declare_Statement Declare_statement { get; set; }
        public Logical_Or_Expression Logical_or_expression { get; set; }
        public Expression Expression { get; set; }
        public State State { get; set; }

        public ForStatementInfo Parse()
        {
            var rslt = new ForStatementInfo(this);
            rslt.Declare_statement = this.Declare_statement.Parse();
            rslt.Logical_or_expression = this.Logical_or_expression.Parse();
            rslt.Expression = this.Expression.Parse();
            rslt.Statements = this.State.Parse(null);
            return rslt;
        }
    }
}