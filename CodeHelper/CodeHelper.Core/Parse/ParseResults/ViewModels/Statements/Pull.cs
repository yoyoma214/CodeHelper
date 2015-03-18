using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Statements
{
    public class Pull : TokenPair
    {
        public String Lvalue { get; set; }
        public Expression Expression { get; set; }


        internal PullInfo Parse()
        {
            var rslt = new PullInfo(this);
            rslt.Source = this.Expression.Parse();
            rslt.Target = new VariableInfo(this) { Name = this.Lvalue };
            return rslt;
        }
    }
}