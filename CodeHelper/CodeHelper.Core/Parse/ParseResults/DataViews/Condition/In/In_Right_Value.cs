using CodeHelper.Core.Parse.ParseResults.DataViews.Lists;
using CodeHelper.Core.Parse.ParseResults.DataViews.Parameters;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In
{
    public class In_Right_Value : TokenPair
    {
        public Parameter Parameter { get; set; }
        public In_List List { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new ListFieldInfo();

            if (Parameter != null)
                return Parameter.Parse(ctx);
            
            if (List != null)
                return List.Parse(ctx);

            return rslt;
        }
    }
}