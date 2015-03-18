using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen;
using CodeHelper.Core.Parse.ParseResults.DataViews.Expression;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Table_Field : TokenPair
    {
        public Table_Field_Atom Table_field_atom { get; set; }
        public Binary_Expression Binary_expression { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            if (Table_field_atom != null)
                return Table_field_atom.Parse(ctx);

            if (Binary_expression != null)
            {
                return Binary_expression.Parse(ctx);
            }
            return null;
        }

    }

}