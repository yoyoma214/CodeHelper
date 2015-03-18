using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Table_Field_Alias : TokenPair
    {
        public String Alias { get; set; }
        public Table_Field Table_field { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            FieldInfo rslt = null;

            if (Table_field != null)
            {
                rslt = Table_field.Parse(ctx);
                //if (rslt != null)
                //{
                //    rslt.ReturnFields.AddRange(rslt.ReturnFields);
                //}
            }

            //if (Alias == null)
            //    return null;

            if (Alias != null && string.IsNullOrWhiteSpace(Alias))
            {
                ctx.Errors.Add(new Error.ParseErrorInfo()
                {
                    ErrorType = Error.ErrorType.Error,
                    Line = this.Table_field.BeginToken.Line,
                    CharPositionInLine = this.Table_field.BeginToken.CharPositionInLine,
                    Message = "字段别名必须为非空字符串"
                });

                return null;
            }

            if (rslt != null && !string.IsNullOrWhiteSpace(Alias))
            {
                rslt.Alias = Alias;
            }

            return rslt;
        }
    }

}