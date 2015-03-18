using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
//using Parser.XmlModel;

namespace CodeHelper.Parser
{
    public class XmlModelParser 
    {
        private XmlModelParser()
        {
        }

        private static XmlModelParser _Instance = new XmlModelParser();

        public static XmlModelParser Instance()
        {
            return _Instance;
        }

        //public IParseModule Parse(string s)
        //{
        //    ConnectProxy.Instance().Send(s);
        //    var json = ConnectProxy.Instance().Read();
        //    if (json == null)
        //        return null;

        //    var db = Newtonsoft.Json.JsonConvert.DeserializeObject<XmModelDB>(json);
        //    return db;
        //}
    }
}
