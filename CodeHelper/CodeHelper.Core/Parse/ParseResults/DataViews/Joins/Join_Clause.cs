using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Joins
{
    public class Join_Clause : TokenPair
    {
        public String Join_type { get; set; }
        public Table_Alias Table_alias { get; set; }
        public Join_On_Clause Join_on_clause { get; set; }

        public void Parse(TableJoinInfo ctx)
        {
            if (Table_alias == null)
                return ;

            //if (Table_alias != null && !string.IsNullOrWhiteSpace(Table_alias.Alias))
            if (Table_alias != null)
            {
                Table_alias.Parse(ctx);            
            }
            
            if ( !string.IsNullOrWhiteSpace(Join_type))
            {
                switch(Join_type.ToLower().Trim())
                {
                    case "leftouterjoin":
                    case "leftjoin":
                        ctx.JoinType = JoinType.Left;
                        break;
                    case "rightouterjoin":
                    case "rightjoin":
                        ctx.JoinType = JoinType.Right;
                        break;
                    case "innerjoin":
                        ctx.JoinType = JoinType.Inner;
                        break;
                    case "outerjoin":
                    case "outer":
                        ctx.JoinType = JoinType.Outer;
                        break;
                    default:
                        ctx.JoinType = JoinType.Unkown;
                        break;
                }
            }

            //rslt.ParentContext = ctx;

            if (Join_on_clause != null)
            {
                ctx.Condition = new OrConditionInfo();
                Join_on_clause.Parse(ctx.Condition);              
            }

            //rslt.ParentContext = ctx;
            //return rslt;
        }
    }
}
