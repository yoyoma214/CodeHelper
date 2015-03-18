/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using System;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    /**
     *
     * @author Administrator
     */
    public class ForEachStatement : TokenPair
    {
        public Generic_Type Generic_Type { get; set; }
        public String Var { get; set; }
        public Expression InExpression { get; set; }
        public State State { get; set; }

        public ForEachStatementInfo Parse()
        {
            var rslt = new ForEachStatementInfo(this);
            rslt.InExpression = this.InExpression.Parse();
            rslt.Var = this.Var;
            rslt.GenericType = Generic_Type.Parse();
            rslt.Statements = this.State.Parse(null);
            return rslt;
        }
    }
}