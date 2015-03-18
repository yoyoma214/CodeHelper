using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class From_Clause : TokenPair
    {
        public Select_Alias Select_alias { get; set; }

        public List<Table_Alias> Table_alias_list { get; set; }

        public From_Clause()
        {
            this.Table_alias_list = new List<Table_Alias>();
        }

        public List<TableJoinInfo> Parse(SelectAtomContext ctx)
        {
            var rslt = new List<TableJoinInfo>();

            if (Table_alias_list != null)
            {

                foreach (var t in Table_alias_list)
                {
                    var joinTable = new TableJoinInfo();
                    t.Parse(joinTable);
                    joinTable.JoinType = JoinType.Outer;

                    rslt.Add(joinTable);
                }
                rslt[0].JoinType = JoinType.First;
                //return rslt;
            }
            if (Select_alias != null)
            {
                 
                var selectCtx = Select_alias.Parse(ctx);
                //selectCtx.TableJoinInfos[0].JoinType = JoinType.First;
                //rslt.Add(selectCtx.TableJoinInfos[0]);

            }
            return rslt;
        }
    }
}