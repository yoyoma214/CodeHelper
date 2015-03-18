using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex_Mix_Prior : TokenPair
    {
        public List<Compare_Complex_Prior> Compare_complex_priors { get; set; }
        public List<string> Relations { get; set; }

        //public ConditionComplexInfo Parse(SqlContext ctx)
        //{
        //    if (Compare_complex_priors == null)
        //        return null;
        //    var condition = new ConditionComplexInfo();
        //    if (SqlContext.Condition_Stack.Count == 0)
        //    {
        //        SqlContext.Context_Stack.Peek().Condition = condition;
        //    }
        //    else
        //    {
        //        SqlContext.Condition_Stack.Peek().Conditions.Add(condition);
        //    }

        //    SqlContext.Condition_Stack.Push(condition);
            
        //    var rslt = new SqlContext();

        //    foreach (var ccp in Compare_complex_priors)
        //    {
        //        var temp = ccp.Parse(ctx);
        //        if (temp != null)
        //        {
        //            //rslt.Condition.Conditions.Add(temp.Condition);
        //            //rslt.Parameters.AddRange(temp.Parameters);
        //        }
        //    }

        //    var condition_array = SqlContext.Condition_Stack.ToArray();
        //    var parent_condition = condition_array.Length > 1 ? condition_array[condition_array.Length-2]
        //        : null;


        //    foreach (var r in Relations)
        //    {
        //        RelationType rt = RelationType.Unknown;

        //        if (r.Equals("and", StringComparison.OrdinalIgnoreCase))
        //        {
        //            rt = RelationType.And;
        //            rslt.Condition.RelationTypes.Add(RelationType.And);
        //        }
        //        else if (r.Equals("or", StringComparison.OrdinalIgnoreCase))
        //        {
        //            rt = RelationType.Or;
        //            rslt.Condition.RelationTypes.Add(RelationType.Or);
        //        }


        //        condition.RelationTypes.Add(rt);


        //    }

            
            

        //    //var temp = Compare_complex_mix.Parse(ctx);

        //    //rslt.Conditions.Add(new ConditionComplexInfo());
        //    //rslt.Conditions[0].Conditions.AddRange(temp.Conditions);
        //    //rslt.Conditions[0].RelationTypes.AddRange(temp.RelationTypes);
        //    SqlContext.Condition_Stack.Pop();
        //    return condition;
        //}
    }
}