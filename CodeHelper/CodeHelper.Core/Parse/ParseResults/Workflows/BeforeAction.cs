/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    /**
     *
     * @author Administrator
     */
    public class BeforeAction : TokenPair
    {
        public State State { get; set; }

        internal ActionInfo Parse()
        {
            var rslt = new BeforeActionInfo();
            rslt.Statements = this.State.Parse(null);
            return rslt;
        }
    }
}