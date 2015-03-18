using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Condition_Clause : TokenPair
    {
        //public List<Compare_Complex_Mix_Prior> Compare_complex_mix_priors { get; set; }
        public Compare_Complex_Mix_Or Compare_complex_mix_or { get; set; }
        //public List<String> Relations { get; set; }

        public Condition_Clause()
        {
            //Compare_complex_mix_priors = new List<Compare_Complex_Mix_Prior>();
            //Relations = new List<String>();
        }

        public void Parse(OrConditionInfo ctx)
        {

            if (Compare_complex_mix_or != null)
            {
                 Compare_complex_mix_or.Parse(ctx);
            }

            //if (Compare_complex_mix_prior != null )
            //{
            //    foreach (var compare in Compare_complex_mix_priors)
            //    {
            //        var compareCtx = compare.Parse(ctx);
            //        if (compareCtx != null)
            //        {                        
            //            //var temp = new ConditionComplexInfo();
            //            //temp.Conditions = compareCtx.Conditions;
            //            //temp.RelationTypes = compareCtx.RelationTypes;
            //            //rslt.Conditions.Add(temp);
            //            rslt = rslt.Join(compareCtx);
            //        }
            //        else
            //        {
            //            Debug.Assert(false, "条件解析结果为空");
            //        }
            //    }
            //}

            //if (Relations != null && Relations.Count > 0)
            //{
            //    for (int index = 0; index < Relations.Count; index++)
            //    {
            //        var relation = Relations[index];
            //        RelationType relationType = RelationType.Unknown;
            //        switch (relation.ToLower().Trim())
            //        {
            //            case "and":
            //                relationType = RelationType.And;
            //                break;
            //            case "or":
            //                relationType = RelationType.Or;
            //                break;

            //            default: break;
            //        }
            //        rslt.RelationTypes.Add(relationType);
            //    }
            //}
            
        }
    }
}