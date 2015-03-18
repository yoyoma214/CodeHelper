using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public class Option : TokenPair
    {
        public String Name { get; set; }
        public String Value { get; set; }

        internal OptionInfo Parse()
        {
            return new OptionInfo(this) { Name = Name, Value = Value==null?null:Value.Replace("\"","") };
        }
    }
}