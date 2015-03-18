using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Parser;
using CodeHelper.Core.Parser;
using Newtonsoft.Json;
using CodeHelper.Core.Parse.ParseResults.DataViews;
using System.Collections.Concurrent;
using CodeHelper.Core.Error;
using System.Windows.Forms;

namespace CodeHelper.DataBaseHelper.Sql
{
    class SqlParser
    {
        internal BlockingCollection<ParseErrorInfo> Errors
        {
            get;
            set;
        }        

        private SqlParser()
        {
            this.Errors = new BlockingCollection<ParseErrorInfo>();
        }

        private static SqlParser _instance = new SqlParser();

        public static SqlParser Instance()
        {
            return _instance;
        }

        public void Parse(string sql, int dotIndex,out DataViewDB dvDB, out List<ParseErrorInfo> errors, out ContextMenu contextMenu)
        {
            errors = new List<ParseErrorInfo>();
            contextMenu = new ContextMenu();
            dvDB = null;

            try
            {
                var parseInfo = new ParseInfo();
                parseInfo.Type = ParseType.DataView;
                parseInfo.Index = dotIndex;
                parseInfo.Content = sql;
                var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                string json = null;

                if (!ConnectProxy.Instance().Send(parseInfo_json))
                {
                    return;
                }
                json = ConnectProxy.Instance().Read();
                //if (string.IsNullOrWhiteSpace(json))//repeat call if retrive empty text
                //{
                //    if (!ConnectProxy.Instance().Send(parseInfo_json))
                //    {
                //        return;
                //    }
                //    json = ConnectProxy.Instance().Read();
                //}
                try
                {
                    var dvModel = JsonConvert.DeserializeObject<DataViewDB>(json);
                    dvDB = dvModel;
                    errors = dvModel.Errors;
                    dvModel.Parse();

                    foreach (var error in errors)
                    {
                        this.Errors.Add(error);
                    }
                    //
                }
                catch (Exception e)
                {
                    this.Errors.Add(new CodeHelper.Core.Error.ParseErrorInfo()
                    {
                        FileId = Guid.Empty,
                        File = "",
                        ErrorType = CodeHelper.Core.Error.ErrorType.Error,
                        Message = "模块解析错误: " + e.Message
                    });
                    Console.Out.WriteLine(e.StackTrace);
                }
            }
            catch
            {
            }
        }
    }
}