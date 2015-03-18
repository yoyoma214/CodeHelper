/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{

    /**
     *
     * @author Administrator
     */
    public class ContinueStatement :TokenPair
    {
        public ContinueStatementInfo Parse()
        {
            var rslt = new ContinueStatementInfo(this);
            return rslt;
        }
    }

}