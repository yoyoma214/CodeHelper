using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex_Mix_Or : TokenPair
    {
        public List<Compare_Complex_Mix_And> Compare_complex_mix_ands { get; set; }

        public Compare_Complex_Mix_Or()
        {
            this.Compare_complex_mix_ands = new List<Compare_Complex_Mix_And>();
        }

        public void Parse(OrConditionInfo ctx)
        {
            //OrConditionInfo result = new OrConditionInfo();

            foreach (var and in Compare_complex_mix_ands)
            {
                var andCond = new AndConditionInfo();
                ctx.Conditions.Add(andCond);
                and.Parse(andCond);
            }

            //return result;
        }
    }
}
