/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using CodeHelper.Core.Parse.ParseResults.Workflows;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{

    /**
     *
     * @author Administrator
     */
    public class WhileStatement : TokenPair
    {
        public Expression Condition { get; set; }
        public State State { get; set; } 

        public WhileStatementInfo Parse()
        {
            var rslt = new WhileStatementInfo(this);
            rslt.Condition = this.Condition.Parse();
            rslt.Statements = State.Parse(null);
            return rslt;
        }
    }
}