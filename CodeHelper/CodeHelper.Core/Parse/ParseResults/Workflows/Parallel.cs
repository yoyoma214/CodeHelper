using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Parallel : TokenPair
    {
        public string Name { get; set; }
        public Variable Variable { get; set; }
        public Init Init { get; set; }        
        public Action Action { get; set; }
        public Translation Translation { get; set; }
        public List<Execute_Line> Execute_Lines { get; set; }

        public Parallel()
        {
            this.Execute_Lines = new List<Execute_Line>();
        }

        internal ParallelInfo Parse()
        {
            var rslt = new ParallelInfo();
            rslt.Name = this.Name;
            if (this.Variable != null)
                rslt.Variable = this.Variable.Parse();
            if (this.Init != null)
                rslt.Init = this.Init.Parse();
            if (this.Action != null)
                rslt.Actions = this.Action.Parse();
            if (this.Translation != null)
                rslt.Translation = this.Translation.Parse();

            foreach (var line in this.Execute_Lines)
            {
                rslt.ExecuteLines.Add(line.Parse());
            }
            return rslt;
        }
    }
}
