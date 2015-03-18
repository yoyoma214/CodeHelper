using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Table_Field_Atom : TokenPair
    {
        public Value Value { get; set; }
        public All_Field All_field { get; set; }
        public Table_All_Field Table_all_field { get; set; }
        public Field_Regular Field_regular { get; set; }
        public Case_Clause_Field Case_clause_field { get; set; }
        public Function_Field Function_field { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            if (Value != null)
            {
                return Value.Parse(ctx);
            }

            if (All_field != null)
            {
                return All_field.Parse(ctx);

            }

            if (Table_all_field != null)
            {
                return Table_all_field.Parse(ctx);

            }

            if (Field_regular != null)
            {
                return Field_regular.Parse(ctx);

            }

            if (Case_clause_field != null)
            {
                return Case_clause_field.Parse(ctx);

            }

            if (Function_field != null)
            {
                return Function_field.Parse(ctx);

            }

            return null;
        }
    }
}
