namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In
{
    public class In_Expression_Prior : TokenPair
    {
        public In_Expression In_expression { get; set; }

        public InCondtionInfo Parse(SelectAtomContext ctx)
        {
            return In_expression.Parse(ctx);
        }
    }
}