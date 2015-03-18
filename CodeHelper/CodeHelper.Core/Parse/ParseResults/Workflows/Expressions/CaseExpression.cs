/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using CodeHelper.Core.Parse.ParseResults.Workflows;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{

    /**
     *
     * @author Administrator
     */
    public class CaseExpression : TokenPair
    {
        public Boolean IsDefault { get; set; }
        public Constant Constant { get; set; }
        public State State { get; set; }
        public Boolean HasBreak { get; set; }

        internal CaseExpressionInfo Parse()
        {
            var rslt = new CaseExpressionInfo();
            rslt.IsDefault = this.IsDefault;
            if (this.Constant != null )
                rslt.Constant = this.Constant.Parse();
            rslt.Statements = this.State.Parse(null);
            return rslt;
        }
    }
}