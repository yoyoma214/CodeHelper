using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Expression
{
    public class Unary_Operator :TokenPair
    {
        public String Operator{ get; set; }

        public Table_Field_Atom Table_field_atom { get; set; }

        public UnaryOperatorInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new UnaryOperatorInfo();
            if (Operator.Equals("~"))
                rslt.IsNegate = true;
            if ( Table_field_atom != null )
                rslt.FieldInfo = Table_field_atom.Parse(ctx);

            return rslt;
        }
    }
}
