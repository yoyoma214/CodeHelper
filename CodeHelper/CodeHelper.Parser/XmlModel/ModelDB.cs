using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;


namespace Parser.XmlModel
{
    public class ModelDB
    {
        public Dictionary<string, ElementInfo> Elements { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }
    }
}
