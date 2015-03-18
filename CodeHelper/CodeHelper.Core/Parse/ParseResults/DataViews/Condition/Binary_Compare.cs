using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Binary_Compare : TokenPair
    {
        public Table_Field Left_table_field { get; set; }
        public Binary_Operater Binary_operater { get; set; }
        public Table_Field Right_table_field { get; set; }
        public Predication Predication { get; set; }

        public BinaryConditionInfo Parse(SelectAtomContext ctx)
        {
            var condition = new BinaryConditionInfo();
            if (Left_table_field != null)
            {
                var temp = Left_table_field.Parse(ctx);
                condition.LeftValue = temp;  
            }

            if (Right_table_field != null)
            {
                condition.RightValue = Right_table_field.Parse(ctx);
            }

            if (Predication != null)
            {
                condition.RightValue = new PredicationFieldInfo();
                Predication.Parse(condition.RightValue as PredicationFieldInfo);
            }
            switch (Binary_operater.Operater.ToLower())
            {
                case "=":
                    condition.ConditionType = ConditionType.Equal;
                    break;
                case "<":
                    condition.ConditionType = ConditionType.Lt;
                    break;
                case ">":
                    condition.ConditionType = ConditionType.Gt;
                    break;
                case "!=":
                    condition.ConditionType = ConditionType.NotEqual;
                    break;
                case "<=":
                    condition.ConditionType = ConditionType.LtEqual;
                    break;
                case ">=":
                    condition.ConditionType = ConditionType.GtEqual;
                    break;
                case "in":
                    condition.ConditionType = ConditionType.In;
                    break;
                case "like":
                    var c = new LikeConditionInfo();
                    c.LeftValue = condition.LeftValue;
                    c.RightValue = condition.RightValue;
                    condition = c;
                    condition.ConditionType = ConditionType.Like;

                    break;
                case "between":
                    condition.ConditionType = ConditionType.Between;
                    break;
                case "exists":
                    condition.ConditionType = ConditionType.Exists;
                    break;             
          
                default:
                    condition.ConditionType = ConditionType.Unknown;
                    break;
            }

            return condition;
        }
    }
}
