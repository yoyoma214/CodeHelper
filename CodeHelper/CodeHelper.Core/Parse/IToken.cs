using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse
{
    public interface IToken
    {
        int Line { get; set; }
        int CharPositionInLine { get; set; }
        int Length { get; set; }
    }
}
