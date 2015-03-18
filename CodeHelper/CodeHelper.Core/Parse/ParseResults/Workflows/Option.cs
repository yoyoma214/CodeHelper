using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Option : TokenPair
    {
        public String Name { get; set; }
        public String Value { get; set; }

        internal OptionInfo Parse()
        {
            return new OptionInfo(this) { Name = Name, Value = Value };
        }
    }
}