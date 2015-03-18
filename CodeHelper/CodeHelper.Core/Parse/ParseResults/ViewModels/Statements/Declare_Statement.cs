using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Statements
{
    public class Declare_Statement : TokenPair
    {
        public Declare Declare { get; set; }

        internal VariableInfo Parse()
        {
            return this.Declare.Parse();
        }
    }
}