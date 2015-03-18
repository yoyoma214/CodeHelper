namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.Exists
{
    public class Existed_Compare_Prior : TokenPair
    {
        public Existed_Compare Existed_compare { get; set; }

        public ExistsConditionInfo Parse(SelectAtomContext ctx)
        {
            return Existed_compare.Parse(ctx);
        }
    }
}