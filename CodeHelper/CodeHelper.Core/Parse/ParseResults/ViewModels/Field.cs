using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Statements;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public class Field : TokenPair
    {
        public Declare Declare { get; set; }
        public List<Option> Options { get; set; }

        internal FieldInfo Parse()
        {
            var rslt = new FieldInfo(this);
            var variable =  this.Declare.Parse();
            rslt.Name = variable.Name;
            rslt.Type_name = variable.Type_name;
            rslt.Default_value = variable.Value;
            foreach (var option in this.Options)
            {
                rslt.Options.Add(option.Parse());
            }
            return rslt;
        }
    }
}