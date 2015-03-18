/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
using CodeHelper.Core.Parse.ParseResults;
using System.Collections.Generic;
using CodeHelper.Core.Error;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    /**
     *
     * @author cqy
     */
    public class Program : TokenPair
    {
        public string NameSpace { get; set; }
        public Variable Variable { get; set; }
        public Init Init { get; set; }
        public List<Unit> Units { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }

        public void Parse(WorkflowDB db)
        {
            db.NameSpace = this.NameSpace;
            db.Variable = this.Variable.Parse();
            if (this.Init != null)
            {
                db.Init = this.Init.Parse();
            }
            //todo 
            foreach (var n in Units)
                db.Units.Add(n.Parse());
            db.Errors.AddRange(Errors);
        }
    }
}