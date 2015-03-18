using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Statements
{
    public class Push : TokenPair
    {
        public Expression Expression { get; set; }

        public State State { get; set; }


        internal PushInfo Parse(ModelInfo model)
        {
            var rslt = new PushInfo(this);
            rslt.Source = this.Expression.Parse();
            rslt.Target = State.Parse(model);
            return rslt;
        }
    }
}