using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Postfix_Part : TokenPair
    {
        public Postfix_Part_Index Postfix_part_index { get; set; }
        public Postfix_Part_Decrease Postfix_part_decrease { get; set; }
        public Postfix_Part_Empty_Function Postfix_part_empty_function { get; set; }
        public Postfix_Part_Function Postfix_part_function { get; set; }
        public Postfix_Part_Increase Postfix_part_increase { get; set; }
        public Postfix_Part_Long_Name Postfix_part_long_name { get; set; }


        internal Postfix_PartInfo Parse()
        {
            var rslt = new Postfix_PartInfo(this);
            if (this.Postfix_part_decrease != null)
            {
                rslt.Postfix_Part_Decrease = new Postfix_Part_DecreaseInfo(this);
                rslt.Postfix_Part_Decrease.TokenPair = this;
            }
            if (this.Postfix_part_empty_function != null)
            {
                rslt.Postfix_Part_Empty_Function = new Postfix_Part_Empty_FunctionInfo() {};
                rslt.Postfix_Part_Empty_Function.TokenPair = this;
            }
            if (this.Postfix_part_function != null)
            {
                rslt.Postfix_Part_Function = this.Postfix_part_function.Parse();
                rslt.Postfix_Part_Function.TokenPair = this;
            }
            if (this.Postfix_part_increase != null)
            {
                rslt.Postfix_Part_Increase = new Postfix_Part_IncreaseInfo(this);
                rslt.Postfix_Part_Increase.TokenPair = this;
            }
            if (this.Postfix_part_index != null)
            {
                rslt.Postfix_Part_Index = this.Postfix_part_index.Parse();
                rslt.Postfix_Part_Index.TokenPair = this;
            }
            if (this.Postfix_part_long_name != null)
            {
                rslt.Postfix_Part_Long_Name = new Postfix_Part_Long_NameInfo(this) { Text = this.Postfix_part_long_name.Text };
                rslt.Postfix_Part_Long_Name.TokenPair = this;
            }
            return rslt;
        }
    }
}