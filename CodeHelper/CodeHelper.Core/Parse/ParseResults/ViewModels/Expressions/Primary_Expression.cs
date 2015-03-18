using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Primary_Expression : TokenPair
    {
        public String Id { get; set; }
        public Constant Constant { get; set; }
        public Expression Expression { get; set; }

        public bool IsId { get; set; }
        public bool IsConstant { get; set; }
        public bool IsExpression { get; set; }


        internal Primary_ExpressionInfo Parse()
        {
            var rslt = new Primary_ExpressionInfo(this);
            rslt.IsConstant = this.IsConstant;
            rslt.IsExpression = this.IsExpression;
            rslt.IsId = this.IsId;

            if (this.IsConstant)
            {
                rslt.Constant = this.Constant.Parse();
            }
            if (this.IsId)
            {
                rslt.Id = Id;
            }
            if (this.IsExpression)
            {
                rslt.Expression = this.Expression.Parse();
            }
            return rslt;
        }
    }
}