using CodeHelper.Core.Parse.ParseResults.DataViews.Lists;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In
{
    public class In_List : TokenPair
    {
        public Value_List Value_list { get; set; }
        public Select_List Select_list { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            if (Value_list != null)
            {
                return Value_list.Parse(ctx);
            }
            if (Select_list != null)
            {
                return Select_list.Parse(ctx);
            }

            return null;
        }
    }

}