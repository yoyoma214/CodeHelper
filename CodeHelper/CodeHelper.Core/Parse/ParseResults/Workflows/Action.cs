/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{

    /**
     *
     * @author Administrator
     */
    public class Action : TokenPair
    {
        public BeforeAction Before { get; set; }
        public AfterAction After { get; set; }


        internal System.Collections.Generic.List<ActionInfo> Parse()
        {
            var rslt = new List<ActionInfo>();
            if (this.After != null)
                rslt.Add(this.After.Parse());
            if (this.Before != null)
                rslt.Add(this.Before.Parse());

            return rslt;
        }
    }
}