

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.Exists
{
    public class Existed_Compare : TokenPair
    {
        public bool Is_existed { get; set; }
        public bool Is_not_existed { get; set; }
        public Select Select { get; set; }

        public ExistsConditionInfo Parse(SelectAtomContext ctx)
        {
            var condtion = new ExistsConditionInfo();

            if (Is_existed)
            {
                condtion.ConditionType = ConditionType.Exists;
            }
            else if (Is_not_existed)
            {
                condtion.ConditionType = ConditionType.NotExists;
            }

            condtion.SubContext = new SelectContext();
            Select.Parse(condtion.SubContext);

            //var rslt = new SqlContext();
            //rslt.Condition.Conditions.Add(new ConditionComplexInfo() { Condition = condtion });

            return condtion;
        }
    }
}