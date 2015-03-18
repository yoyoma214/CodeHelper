using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Unary_Expression_Two_Char : TokenPair
    {
        public String Operator { get; set; }
        public Unary_Expression unary_expression { get; set; }


        internal Unary_Expression_Two_CharInfo Parse()
        {
            var rslt = new Unary_Expression_Two_CharInfo(this);
            rslt.Unary_Expression = this.unary_expression.Parse();
            switch (this.Operator)
            {
                case "++":
                    rslt.Unary_Expression_Operator = Unary_Expression_OperatorInfo.AddSelf;
                    break;
                case "-":
                    rslt.Unary_Expression_Operator = Unary_Expression_OperatorInfo.SubstractSelf;
                    break;
            }
            return rslt;
        }
    }
}