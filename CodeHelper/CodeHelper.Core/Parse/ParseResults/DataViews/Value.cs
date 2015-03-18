using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Parameters;
using CodeHelper.Core.Parse.ParseResults.DataViews.Lists;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Value : TokenPair
    {
        public bool Is_bool { get; set; }
        public bool Is_int { get; set; }
        public bool Is_float { get; set; }
        public bool Is_char { get; set; }
        public bool Is_string { get; set; }
        public bool Is_parameter { get; set; }
        public bool Is_select_list { get; set; }
        public bool Is_option_string { get; set; }

        public string value { get; set; }
        public Parameter Parameter { get; set; }
        public Select_List select_list { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            var dbType = DbType.Unknown;
            if ( Is_bool ){
                dbType = DbType.Bool;
            }
            if (Is_int)
            {
                dbType = DbType.Int;
            }
            if (Is_float)
            {
                dbType = DbType.Float;
            }
            if (Is_char)
            {
                dbType = DbType.Char;
            }
            if (Is_string)
            {
                dbType = DbType.String;
            }
            if (Is_parameter)
            {
                dbType = DbType.Parameter;
            }
            if (Is_option_string)
            {
                dbType = DbType.OptionString;
            }

            var v = new ValueFieldInfo() { DbType = dbType, Value = this.value };

            if (Is_parameter)
            {
                v.FullName = v.Value = this.Parameter.Parameter_name.Text;
                return new ParameterFieldInfo() { Name = v.FullName };
            }

            if (Is_select_list)
            {
                var list = this.select_list.Parse(ctx);
                return list;
            }
            return v;
        }
    }
}