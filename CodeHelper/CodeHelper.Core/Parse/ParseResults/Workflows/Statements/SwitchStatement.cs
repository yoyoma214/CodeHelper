/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    /**
     *
     * @author Administrator
     */
    public class SwitchStatement : TokenPair
    {
        public Expression Key { get; set; }
        public List<CaseExpression> CaseExpressions { get; set; }

        public SwitchStatementInfo Parse()
        {
            var rslt = new SwitchStatementInfo(this);
            rslt.Key = Key.Parse();
            foreach (var c in this.CaseExpressions)
                rslt.CaseExpressions.Add(c.Parse());

            return rslt;
        }
    }
}