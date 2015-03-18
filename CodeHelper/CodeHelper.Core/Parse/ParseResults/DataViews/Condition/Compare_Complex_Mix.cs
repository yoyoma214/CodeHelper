using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Compare_Complex_Mix : TokenPair
    {
        public List<Compare_Complex> Compare_complexs { get; set; }
        public List<String> Relations { get; set; }

        public Compare_Complex_Mix()
        {
            Compare_complexs = new List<Compare_Complex>();
            Relations = new List<String>();

        }

        public override SqlContext Parse(SqlContext ctx)
        {
            if (Compare_complexs == null || Compare_complexs.Count == 0)
                return null;

            var rslt = new SqlContext();
            foreach (var cc in Compare_complexs)
            {
                var temp = cc.Parse(ctx);
                //rslt = rslt.Join(temp);
            }

            for (int index = 0; index < Relations.Count; index++)
            {
                var relation = Relations[index];
                RelationType relationType = RelationType.Unknown;
                switch (relation.ToLower().Trim())
                {
                    case "and":
                        relationType = RelationType.And;
                        break;
                    case "or":
                        relationType = RelationType.Or;
                        break;

                    default: break;
                }
                rslt.RelationTypes.Add(relationType);
            }
            return rslt;
        }
    }
}