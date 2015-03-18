using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Error
{
    public class ParseErrorInfo
    {
        public string File { get; set; }
        public Guid? FileId { get; set; }
        public ErrorType ErrorType { get; set; }
        public int Line { get; set; }
        public int CharPositionInLine { get; set; }
        public String Message { get; set; }

        public ParseErrorInfo()
        {

        }
    }
}
