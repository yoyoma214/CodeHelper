using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In
{
    public class In_Expression : TokenPair
    {
        public Table_Field Table_field { get; set; }
        public In_Keyword In_keyword { get; set; }
        public In_Right_Value In_right_value { get; set; }

        public InCondtionInfo Parse(SelectAtomContext ctx)
        {
            var temp = Table_field.Parse(ctx);

            var condition = new InCondtionInfo();
            condition.LeftValue = temp;
            if (In_keyword.keyworkd == "in")
            {
                condition.ConditionType = ConditionType.In;
            }
            else if (In_keyword.keyworkd == "not in")
            {
                condition.ConditionType = ConditionType.NotIn;
            }
            else
            {
                System.Diagnostics.Debug.Assert(false, "没有这种in条件");
            }

            //if (temp != null)
            //{
            //    rslt.Condition.Conditions.Add(new ConditionComplexInfo());
            //    rslt.Condition.Conditions[0].Condition = condition;
            //}

            var listField = this.In_right_value.Parse(ctx);
            condition.RightValue = listField;
            return condition;
        }
   }
}
