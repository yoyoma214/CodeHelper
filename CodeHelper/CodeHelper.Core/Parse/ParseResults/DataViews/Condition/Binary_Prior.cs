using System;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Binary_Prior : TokenPair
    {
        public Binary Binary { get; set; }

        public BinaryConditionInfo Parse(SelectAtomContext ctx)
        {
            if (Binary == null)
                return null;

            return Binary.Parse(ctx);
        }
    }
}