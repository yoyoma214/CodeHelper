using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Unary_Expression_One_Char : TokenPair
    {
        public String Operator { get; set; }
        public Cast_Expression Cast_expression { get; set; }


        internal Unary_Expression_One_CharInfo Parse()
        {
            var rslt = new Unary_Expression_One_CharInfo(this);
            rslt.Cast_Expression = this.Cast_expression.Parse();
            switch (this.Operator)
            {
                case "~":
                    rslt.Unary_Operator = Unary_OperatorInfo.BitReverse;
                    break;
                case "!":
                    rslt.Unary_Operator = Unary_OperatorInfo.BoolReverse;
                    break;
                case "-":
                    rslt.Unary_Operator = Unary_OperatorInfo.Negative;
                    break;
                case "+":
                    rslt.Unary_Operator = Unary_OperatorInfo.Positive;
                    break;
            }
            return rslt;
        }
    }
}