using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
using System.Collections.Concurrent;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using System.Windows.Forms;
using Newtonsoft.Json;
//using Parser.XmlModel;

namespace CodeHelper.Parser
{
    public class ViewModelParser 
    {
        private ViewModelParser()
        { 
            this.Errors = new BlockingCollection<ParseErrorInfo>();
        }

        private static ViewModelParser _Instance = new ViewModelParser();

        public static ViewModelParser Instance()
        {
            return _Instance;
        }

       internal BlockingCollection<ParseErrorInfo> Errors
        {
            get;
            set;
        }        


        public void Parse(string sql, int dotIndex,out ViewModelDB vmDB, out List<ParseErrorInfo> errors, out ContextMenu contextMenu)
        {
            errors = new List<ParseErrorInfo>();
            contextMenu = new ContextMenu();
            vmDB = null;

            try
            {
                var parseInfo = new ParseInfo();
                parseInfo.Type = ParseType.ViewModel;
                parseInfo.Index = dotIndex;
                parseInfo.Content = sql;
                var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                string json = null;

                if (!ConnectProxy.Instance().Send(parseInfo_json))
                {
                    return;
                }
                json = ConnectProxy.Instance().Read();
                if (string.IsNullOrWhiteSpace(json))//repeat call if retrive empty text
                {
                    if (!ConnectProxy.Instance().Send(parseInfo_json))
                    {
                        return;
                    }
                    json = ConnectProxy.Instance().Read();
                }
                try
                {
                    var dvModel = JsonConvert.DeserializeObject<ViewModelDB>(json);
                    vmDB = dvModel;
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