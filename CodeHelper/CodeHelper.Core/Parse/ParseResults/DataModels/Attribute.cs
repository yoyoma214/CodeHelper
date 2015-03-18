using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class Attribute : TokenPair
    {
        public string Name { get; set; }

        public List<String> Parameters { get; set; }

        public AttributeInfo Parse()
        {
            var attr = new AttributeInfo();
            attr.TokenPair = this;
            attr.Name = this.Name;
            attr.Parameters = new List<string>();
            foreach (var para in Parameters)
            {
                attr.Parameters.Add(para.Replace("\"",""));
            }
            return attr;
        }
    }
}
