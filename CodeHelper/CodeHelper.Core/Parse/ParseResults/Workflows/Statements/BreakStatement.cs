/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    /**
     *
     * @author Administrator
     */
    public class BreakStatement : TokenPair
    {
        public BreakStatementInfo Parse()
        {
            var rslt = new BreakStatementInfo(this);
            return rslt;
        }
    }
}