
using System;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public class Attribute : TokenPair
    {
        public String Name { get; set; }
        public String Value { get; set; }

        internal AttributeInfo Parse()
        {
            var rslt = new AttributeInfo(this);
            rslt.Name = this.Name;
            rslt.Value = this.Value;
            return rslt;
        }

    }
}
