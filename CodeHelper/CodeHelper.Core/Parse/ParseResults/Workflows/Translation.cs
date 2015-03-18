/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse.ParseResults.Workflows.Statements;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{


    /**
     *
     * @author Administrator
     */
    public class Translation : TokenPair
    {
        public List<Translation_statement> Translation_statements { get; set; }

        public Translation()
        {
        }

        internal TranslationInfo Parse()
        {
            var rslt = new TranslationInfo();
            foreach (var s in this.Translation_statements)
            {
                rslt.Statments.Add(s.Parse());
            }
            return rslt;
        }
    }
}