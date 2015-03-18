using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Infrastructure.Model;
using Newtonsoft.Json;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
using CodeHelper.Core.Parse.ParseResults.DataModels;
using CodeHelper.Core.Parse.ParseResults.DataViews;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using CodeHelper.Core.Error;
//using Core.Parser;

namespace CodeHelper.Parser
{
    public class ParserManager
    {
        private static ParserManager instance;
        //private Dictionary<ParseType,
        private ParserManager() {
            Errors = new List<ParseErrorInfo>();
        }
        public List<ParseErrorInfo> Errors { get; set; }

        public static ParserManager Instance()
        {
            if (instance == null)
                instance = new ParserManager();

            return instance;
        }

        public void Parse(IModel model, InputCharInfo inputChar, System.Action callback)
        {
            var text = model.Content;

            try
            {
                var parseInfo = new ParseInfo();
                parseInfo.Content = text;
                parseInfo.Index = 0;
                parseInfo.Type = model.ParseType;
                var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                string json = null;


                if (!ConnectProxy.Instance().Send(parseInfo_json))
                {
                    model.SetParsed(false);
                    return;
                }
                json = ConnectProxy.Instance().Read();


                if (json == null)
                {
                    model.SetParsed(false);
                    return;
                }
                IParseModule module = null;
                try
                {
                    if (model.ParseType == CodeHelper.Core.Parser.ParseType.XmlModel)
                    {
                        module = JsonConvert.DeserializeObject<XmModelDB>(json);
                        //XmModelDB.Current.InputChar = inputChar;
                    }
                    else if (model.ParseType == CodeHelper.Core.Parser.ParseType.DataModel)
                    {
                        module = JsonConvert.DeserializeObject<DmModelDB>(json);
                        //DmModelDB.Current.InputChar = inputChar;
                    }
                    else if (model.ParseType == Core.Parser.ParseType.DataView)
                    {
                        module = JsonConvert.DeserializeObject<DataViewDB>(json);
                        //DataViewDB.Current.InputChar = inputChar;
                    }
                    else if (model.ParseType == Core.Parser.ParseType.ViewModel)
                    {
                        module = JsonConvert.DeserializeObject<ViewModelDB>(json);
                        ViewModelDB.Current = module as ViewModelDB;
                        ViewModelDB.Current.InputChar = inputChar;
                    }
                    else if (model.ParseType == Core.Parser.ParseType.WorkFlow)
                    {
                        var program = JsonConvert.DeserializeObject<Program>(json);
                        module = new WorkflowDB();
                        ((WorkflowDB)module).Program = program;
                        WorkflowDB.Current = module as WorkflowDB;
                        WorkflowDB.Current.InputChar = inputChar;
                        module.Name = System.IO.Path.GetFileNameWithoutExtension(model.File);

                    }
                }
                catch (Exception e)
                {
                    this.Errors.Add(new Core.Error.ParseErrorInfo()
                    {
                        FileId = model.FileId,
                        File = model.File,
                        ErrorType = Core.Error.ErrorType.Error,
                        Message = "模块解析错误: " + e.Message
                    });
                }
                if (module == null)
                {
                    model.SetParsed(false);

                    return;
                }

                module.File = model.File;
                module.FileId = model.FileId;

                module.Initialize();

                module.Wise();

                module.FileId = model.FileId;

                model.SetParsed(true);

                module.Errors.ForEach(x => { x.File = model.File; x.FileId = model.FileId; });

                if (module.Errors != null)
                {
                    module.Errors.ForEach(x => Errors.Add(x));
                }

            }
            catch (Exception e)
            {
                this.Errors.Add(new Core.Error.ParseErrorInfo()
                {
                    FileId = model.FileId,
                    File = model.File,
                    ErrorType = Core.Error.ErrorType.Error,
                    Message = "模块解析错误: " + e.Message
                });
                Console.Out.WriteLine(e.StackTrace);
            }
            finally
            {

                if (callback != null)
                {
                    callback();
                }
            }
        }
    }
}
