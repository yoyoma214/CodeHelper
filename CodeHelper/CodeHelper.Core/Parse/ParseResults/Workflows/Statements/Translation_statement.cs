/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
using System;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    /**
     *
     * @author Administrator
     */
    public class Translation_statement : TokenPair
    {
        public Expression Expression { get; set; }
        public String NodeId { get; set; }

        internal Translation_StatementInfo Parse()
        {
            var rslt = new Translation_StatementInfo(this);
            rslt.Expression = this.Expression.Parse();
            rslt.Target = this.NodeId;
            return rslt;
        }
    }
}