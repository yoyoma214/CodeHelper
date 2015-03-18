namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Binary_Compare_Prior : TokenPair
    {
        public Binary_Compare Binary_compare { get; set; }
        public Condition_Option Condition_option { get; set; }
        public Search_Option Search_option { get; set; }

        public BinaryConditionInfo Parse(SelectAtomContext ctx)
        {
            BinaryConditionInfo rslt = null ;

            if (Binary_compare != null)
            {
                rslt = Binary_compare.Parse(ctx);
            }

            //SqlContext.Condition_Stack.Peek().Conditions.Add(
            //    new ConditionComplexInfo {  Condition = rslt});

            //var condition = rslt.Condition.Conditions[0].Condition;

            if (Condition_option != null)
            {

                if (string.Compare(Condition_option.Option, "?", true) == 0)
                {
                    rslt.Required = false;
                }
                else if (string.Compare(Condition_option.Option, "#", true) == 0)
                {
                    rslt.Required = true;
                }

                //if ( rslt.LeftValue.IsParameter )
                //{
                //    rslt.
                //}
                //foreach (var p in rslt.LeftValue.IsParameter)
                //{
                //    p.NullAble = !condition.Required;
                //}

            }
            if (this.Search_option != null)
            {
                if (Search_option == null || Search_option.Option_expression == null ||
                Search_option.Option_expression.Option_list == null ||
                Search_option.Option_expression.Option_list.Options == null)
                    return rslt;

                foreach (var option in Search_option.Option_expression.Option_list.Options)
                {
                    rslt.Options.Add(
                        new SqlOption() { Name = option.Option_name.Text.Replace("'", ""), Value = option.Option_value.text.Replace("'", "") });
                }

            }



            return rslt;
        }
   }
}