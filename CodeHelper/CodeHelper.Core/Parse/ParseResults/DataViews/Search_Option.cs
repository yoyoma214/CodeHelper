using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Options;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Search_Option : TokenPair
    {
        public Option_Expression Option_expression { get; set; }

        //public override SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return base.Parse(ctx);
        //}

        public List<SqlOption> Parse()
        {
            var rslt = new List<SqlOption>();

            if (Option_expression == null)
                return rslt;

            if (Option_expression.Option_list == null)
                return rslt;

            if (Option_expression.Option_list.Options == null)
                return rslt;

            foreach (var op in Option_expression.Option_list.Options)
            {
                rslt.Add(new SqlOption() { Name = op.Option_name.Text, Value = op.Option_value.text });
            }

            return rslt;
        }
        
    }
}