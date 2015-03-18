using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class Token:IToken
    {

        public int Line
        {
            get;
            set;
        }

        public int CharPositionInLine
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }

        public string Text { get; set; }
        
    }

    public class TokenPair
    {
        public Token BeginToken { get; set; }
        public Token EndToken { get; set; }
        public TokenPair Parent { get; set; }
        public List<TokenPair> Children { get; set; }

        public TokenPair()
        {
            this.Children = new List<TokenPair>();
        }

        //public virtual SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return null;
        //}
    }
}
