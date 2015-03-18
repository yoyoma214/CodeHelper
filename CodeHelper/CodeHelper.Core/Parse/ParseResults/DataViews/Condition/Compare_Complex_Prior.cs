using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex_Prior : TokenPair
    {
        public Compare_Complex_Mix_Or Compare_complex_mix_or { get; set; }
        public Compare_Complex Compare_complex { get; set; }
        public Search_Option Search_option { get; set; }

        public void Parse(CompareComplexConditionInfo ctx)
        {
            if (Compare_complex_mix_or == null &&
                    Compare_complex == null)
                return;

            CompareComplexConditionInfo result = new CompareComplexConditionInfo();
            if (Compare_complex_mix_or != null)
            {
                var orCondition = new OrConditionInfo();
                ctx.OrConditionInfo = orCondition;
                Compare_complex_mix_or.Parse(orCondition);   
             
                //rslt.Parameters.AddRange(temp.Parameters);

                //rslt.Join(temp);
            }
            if (Compare_complex != null)
            {
                //var condition = new ConditionInfo();
                ctx.AtomConditionInfo = Compare_complex.Parse(null); 
                                
                //rslt.Join(temp);
            }

            if (Search_option != null)
            {
                ctx.Options = this.Search_option.Parse();
                foreach (var op in ctx.Options)
                {
                    op.Name = op.Name.StartsWith("'") ? op.Name.Substring(1, op.Name.Length - 2) : op.Name.Trim();
                    op.Value = op.Value.StartsWith("'")? op.Value.Substring(1,op.Value.Length-2):op.Value.Trim();
                }
            }
            //return result;
        }
    }
}
