using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Statements;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public class State : TokenPair
    {
        public List<Statement> Statements { get; set; }

        internal List<StatementInfo> Parse(ModelInfo model)
        {
            var rslt = new List<StatementInfo>();

            foreach (var state in this.Statements)
            {
                rslt.Add(state.Parse(model));
            }

            return rslt;
        }
    }
}