using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Constant : TokenPair
    {
        public String Value { get; set; }
        public bool Is_hex { get; set; }
        public bool Is_octal { get; set; }
        public bool Is_decimal { get; set; }
        public bool Is_char { get; set; }
        public bool Is_string { get; set; }
        public bool Is_float { get; set; }
        public bool Is_bool { get; set; }
        public bool Is_int { get; set; }

        internal ConstantInfo Parse()
        {
            var rslt = new ConstantInfo(this);
            rslt.Is_Char = this.Is_char;
            rslt.Is_Decimal = this.Is_decimal;
            rslt.Is_Float = this.Is_float;
            rslt.Is_Hex = this.Is_hex;
            rslt.Is_Octal = this.Is_octal;
            rslt.Is_String = this.Is_string;
            rslt.Is_Bool = this.Is_bool;
            rslt.Is_Int = this.Is_int;

            rslt.Value = Value;
            return rslt;
        }
    }
}