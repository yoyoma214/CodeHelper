using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Parse.ParseResults.DataModels;

namespace CodeHelper.Parser
{
    public class DataModelParser : IParser
    {
        private DataModelParser()
        {

        }

        private static DataModelParser _Instance = new DataModelParser();

        public static DataModelParser Instance()
        {
            return _Instance;
        }

        //public DmModelDB Parse(ParseInfo parseInfo)
        //{
        //    ConnectProxy.Instance().Send(parseInfo.Content);
        //    var json = ConnectProxy.Instance().Read();
        //    if (json == null)
        //        return null;

        //    var db = Newtonsoft.Json.JsonConvert.DeserializeObject<DmModelDB>(json);
        //    return db;
        //}

        //public string Parse2Json(ParseInfo parseInfo)
        //{
        //    ConnectProxy.Instance().Send(parseInfo.Content);
        //    var json = ConnectProxy.Instance().Read();
        //    return json;
        //}
    }
}
