/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults.Workflows;
using CodeHelper.Core.Parse.ParseResults;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    /**
     *
     * @author Administrator
     */
    public class Init : TokenPair
    {
        public State State { get; set; }

        internal InitInfo Parse()
        {
            var rslt = new InitInfo();
            if (this.State != null)
            {
                rslt.Statements.AddRange(State.Parse(null));
            }
            return rslt;
        }
    }
}