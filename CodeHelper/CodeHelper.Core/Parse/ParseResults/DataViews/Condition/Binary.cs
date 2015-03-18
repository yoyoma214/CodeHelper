namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Binary : TokenPair
    {
        public Binary_Compare_Prior Binary_compare_prior { get; set; }

        public BinaryConditionInfo Parse(SelectAtomContext ctx)
        {
            if (Binary_compare_prior == null)
                return null;
            
            return Binary_compare_prior.Parse(ctx);
        }
    }
}