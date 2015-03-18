using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Error;
using Core.Parser;

namespace Domain.Model.XmlModel.ParseResult
{
    public class ModelDB : IParseModule
    {
        public Dictionary<string, ElementInfo> Elements { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }
    }
}
