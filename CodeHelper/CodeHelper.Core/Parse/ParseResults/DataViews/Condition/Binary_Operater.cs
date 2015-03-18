using System;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Binary_Operater : TokenPair
    {
        public String Operater { get; set; }

        public ConditionType Parse(SelectAtomContext ctx)
        {
            switch (Operater.ToLower())
            {
                case ">":
                    return ConditionType.Gt;
                case ">=":
                    return ConditionType.GtEqual;
                case "<":
                    return ConditionType.Lt;
                case "<=":
                    return ConditionType.LtEqual;
                case "=":
                    return ConditionType.Equal;
                case "!=":
                    return ConditionType.NotEqual;
                case "between":
                    return ConditionType.Between;
                case "exists":
                    return ConditionType.Exists;
                case "in":
                    return ConditionType.In;
                case "notin":
                    return ConditionType.NotIn;
                case "notexists":
                    return ConditionType.NotExists;
                case "like":
                    return ConditionType.Like;
                default:
                    return ConditionType.Unknown;

            }            
        }
    }
}