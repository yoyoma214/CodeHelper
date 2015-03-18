using System;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition.Exists;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex : TokenPair
    {
        public Binary_Prior Bianary_prior { get; set; }
        public In_Expression_Prior In_expression_prior { get; set; }
        public Between_Prior Between_prior { get; set; }
        public Existed_Compare_Prior Existed_compare_prior { get; set; }

        public ConditionInfo Parse(SelectAtomContext ctx)
        {
            if (Bianary_prior != null)
                return Bianary_prior.Parse(ctx);

            if (In_expression_prior != null)
                return In_expression_prior.Parse(ctx);

            if (Between_prior != null)
                return Between_prior.Parse(ctx);

            if (Existed_compare_prior != null)
                return Existed_compare_prior.Parse(ctx);

            return null;
        }
    }
}