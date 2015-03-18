using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class AtomTokenPair:TokenPair
    {
        public String Name { get; set; }
        public String Value { get; set; }
        public bool Is_Id { get; set; }
        public bool Is_String { get; set; }
        public bool Is_Int { get; set; }
        public bool Is_Float { get; set; }
        public bool Is_Double { get; set; }
        public bool Is_Decimal { get; set; }

        public AtomTokenPair()
        {
        }

        public AtomTokenPair(String name)
        {
            this.Name = name;
        }

        public AtomTokenPair(String name, String value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
