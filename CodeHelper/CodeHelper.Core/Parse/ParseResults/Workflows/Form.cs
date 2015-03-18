/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    /**
     *
     * @author Administrator
     */
    public class Form : TokenPair
    {
        public String Id { get; set; }
        public String DataId { get; set; }

        internal FormInfo Parse()
        {
            var rslt = new FormInfo();
            rslt.Id = this.Id;
            rslt.DataId = this.DataId;
            return rslt;
        }
    }
}