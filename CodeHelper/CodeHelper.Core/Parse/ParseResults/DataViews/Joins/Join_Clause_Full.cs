using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Joins
{
    public class Join_Clause_Full : TokenPair
    {
        public List<Join_Clause> Join_clause_list { get; set; }

        public List<TableJoinInfo> Parse(SelectAtomContext ctx)
        {
            if (Join_clause_list == null || Join_clause_list.Count == 0)
                return null;

            var rslt = new List<TableJoinInfo>();

            foreach (var join in this.Join_clause_list)
            {
                var temp = new TableJoinInfo();
                rslt.Add(temp);
                join.Parse(temp);
                
                //rslt = rslt.Join(temp);
            }

            //rslt.ParentContext = ctx;
            return rslt;
        }
    }
}