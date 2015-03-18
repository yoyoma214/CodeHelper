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
    public class Node : TokenPair
    {
        public String Name { get; set; }
        public Variable Variable { get; set; }
        public Init Init { get; set; }
        public Form Form { get; set; }
        public Action Action { get; set; }
        public Translation Translation { get; set; }
        public Ref_Workflow Ref_Workflow { get; set; }

        internal NodeInfo Parse()
        {
            var rslt = new NodeInfo();
            rslt.Name = this.Name;
            if (this.Ref_Workflow != null)
                rslt.RefWorkflow = this.Ref_Workflow.Parse();
            if (Action != null)
                rslt.Actions = this.Action.Parse();
            if (this.Variable != null)
                rslt.Variable = this.Variable.Parse();
            if (this.Init != null)
                rslt.Init = this.Init.Parse();
            if (this.Form != null)
                rslt.Form = this.Form.Parse();
            if (this.Translation != null)
                rslt.Translation = this.Translation.Parse();
            return rslt;
        }
    }

}