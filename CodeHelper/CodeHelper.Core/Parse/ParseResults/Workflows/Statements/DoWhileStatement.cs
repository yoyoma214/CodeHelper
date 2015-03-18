/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{

    /**
     *
     * @author Administrator
     */
    public class DoWhileStatement : TokenPair
    {
        public State State { get; set; }
        public Expression Condition { get; set; }

        public DoWhileStatementInfo Parse()
        {
            var rslt = new DoWhileStatementInfo(this);
            rslt.Condition = this.Condition.Parse();
            rslt.Statements = this.State.Parse(null);
            return rslt;
        }
    }
}