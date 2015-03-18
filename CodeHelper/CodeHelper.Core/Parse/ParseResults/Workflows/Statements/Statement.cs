using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;

namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    public class Statement : TokenPair
    {
        public Expression_Statement Expression { get; set; }
        public Declare_Statement Declare_Statement { get; set; }
        public IfStatement IfStatement { get; set; }
        public SwitchStatement SwitchStatement { get; set; }
        public WhileStatement WhileStatement { get; set; }
        public DoWhileStatement DoWhileStatement { get; set; }
        public ForStatement ForStatement { get; set; }
        public ForEachStatement ForEachStatement { get; set; }
        public GotoStatement GotoStatement { get; set; }
        public BreakStatement BreakStatement { get; set; }
        public ContinueStatement ContinueStatement { get; set; }

        internal StatementInfo Parse(ClzInfo model)
        {
            StatementInfo rslt = null;
            if (this.Expression != null)
            {
                rslt = this.Expression.Parse();
          
            }
            if (this.Declare_Statement !=null )
            {
                rslt = this.Declare_Statement.Parse();
  
            }
            if (this.IfStatement != null)
            {
                rslt = this.IfStatement.Parse();
            }

            if (this.SwitchStatement != null)
                rslt = this.SwitchStatement.Parse();
            if (this.WhileStatement != null)
                rslt = this.WhileStatement.Parse();
            if (this.DoWhileStatement != null)
                rslt = this.DoWhileStatement.Parse();
            if (this.ForStatement != null)
                rslt = this.ForStatement.Parse();
            if (this.ForEachStatement != null)
                rslt = this.ForEachStatement.Parse();
            if (this.GotoStatement != null)
                rslt = this.GotoStatement.Parse();
            if (this.BreakStatement != null)
                rslt = this.BreakStatement.Parse();
            if (this.ContinueStatement != null)
                rslt = this.ContinueStatement.Parse();
            return rslt;
        }
    }
}