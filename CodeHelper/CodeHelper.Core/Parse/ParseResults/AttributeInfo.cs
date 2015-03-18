using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class AttributeInfo
    {
        public TokenPair TokenPair { get; set; }

        public string Name { get; set; }

        public List<string> Parameters { get; set; }

        public AttributeInfo()
        {
            this.Parameters = new List<string>();
        }
    }
}
