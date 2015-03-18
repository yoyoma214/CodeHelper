/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using CodeHelper.Core.Parse.ParseResults;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    /**
     *
     * @author Administrator
     */
    public class IfStatement : TokenPair
    {
        public Expression Condition { get; set; }
        public State TrueState { get; set; }
        public IfStatement ElseIf { get; set; }
        public State ElseState { get; set; }

        internal IfStatementInfo Parse()
        {
            var rslt = new IfStatementInfo(this);
            rslt.Condition = Condition.Parse();            
            rslt.TrueState = this.TrueState.Parse(null);
            if (this.ElseIf != null)
                rslt.ElseIf = this.ElseIf.Parse();
            if (this.ElseState != null)
                rslt.ElseState = this.ElseState.Parse(null);

            return rslt;
        }
    }
}