using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex_Mix_And : TokenPair
    {
        public List<Compare_Complex_Prior> Compare_complex_priors { get; set; }

        public Compare_Complex_Mix_And()
        {
            this.Compare_complex_priors = new List<Compare_Complex_Prior>();
        }

        public void Parse(AndConditionInfo ctx)
        {
            if ( Compare_complex_priors == null ||
                Compare_complex_priors.Count == 0 )
                return;

            //AndConditionInfo result = new AndConditionInfo();
            foreach (var c in Compare_complex_priors)
            {
                var condition = new CompareComplexConditionInfo();
                ctx.CompareComplexConditionInfos.Add(condition);
                c.Parse(condition);
            }
            
        }
    }
}
