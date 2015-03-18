using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Grouping
{
    public class Group_Clause : TokenPair
    {
        public List<Field_Regular> Field_regulars { get; set; }
        public Having_Clause_Full Having_clause_full { get; set; }

        public Group_Clause()
        {
            this.Field_regulars = new List<Field_Regular>();
        }

        public GroupInfo Parse(SelectAtomContext ctx)
        {
            var result = new GroupInfo();

            foreach (var f in this.Field_regulars)
            {
                var temp = f.Parse(ctx);
                FieldRegularInfo fr = temp;
                if (fr == null)
                    System.Diagnostics.Debug.Assert(false, "分组字段名有问题");

                result.Fields.Add(fr.FullName);
            }

            if (Having_clause_full != null)
            {
                result.Having = new HavingInfo();
                Having_clause_full.Parse(result.Having);
                //result.Having = temp;
                //result = result.Join(temp);
            }
            return result;
        }
    }
}