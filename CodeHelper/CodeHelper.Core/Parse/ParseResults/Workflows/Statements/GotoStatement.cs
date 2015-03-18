/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements{
/**
 *
 * @author Administrator
 */
    public class GotoStatement : TokenPair
    {
        public String Target { get; set; }

        public GotoStatementInfo Parse()
        {
            var rslt = new GotoStatementInfo(this);
            rslt.Target = this.Target;
            return rslt;
        }
    }
}
