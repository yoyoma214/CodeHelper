using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Infrastructure.Model;
using System.Threading;
using CodeHelper.Core.Types;
using CodeHelper.Parser;
using Newtonsoft.Json;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
using CodeHelper.Core.Parse.ParseResults.DataModels;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parse.ParseResults;
using System.Collections.Concurrent;
using CodeHelper.Core.Util;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parse.ModuleRelations;
using CodeHelper.Core.Parse.ParseResults.DataViews;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using CodeHelper.Core.Parse.ParseResults.Workflows;

namespace CodeHelper.Domain.Model
{
    partial class ModelManager
    {
        public delegate void OnWiseCompleted(List<ParseErrorInfo> errors);
        public delegate void OnContinue();

        public struct ParseFlag
        {
            public IModel Model { get; set; }

            public bool IsEnd { get; set; }
        }

        public class WorkEngine
        {

            private object syncObj = new object();

            private ConcurrentDictionary<string, object> status = new ConcurrentDictionary<string, object>();

            BlockingCollection<IParseModule> waitingWiseModules = new BlockingCollection<IParseModule>();

            internal BlockingCollection<ParseErrorInfo> Errors
            {
                get;
                set;
            }

            internal bool IsWiseCompleted
            {
                get
                {
                    return (bool)status["IsWiseCompleted"];
                }
                private set
                {
                    status["IsWiseCompleted"] = value;
                }
            }

            private BlockingCollection<IModel> waitingParseModels = new BlockingCollection<IModel>();

            internal Dictionary<Guid, IParseModule> ParsedModules = new Dictionary<Guid, IParseModule>();

            internal Dictionary<string, List<IParseModule>> Namespace_Modules
                                                      = new Dictionary<string, List<IParseModule>>();

            internal Dictionary<string, ITypeInfo> Types = new Dictionary<string, ITypeInfo>();

            private Dictionary<string, List<ITypeInfo>> RepeatTypes = new Dictionary<string, List<ITypeInfo>>();

            private AutoResetEvent engineEvent = new AutoResetEvent(false);

            //private AutoResetEvent byWaitEvent = new AutoResetEvent(false);

            private AutoResetEvent parseEvent = new AutoResetEvent(false);

            private Thread workThread;

            public event OnWiseCompleted WiseCompleted;

            public event OnContinue Continue;

            public WorkEngine()
            {
                this.status["IsWiseCompleted"] = false;
                Errors = new BlockingCollection<ParseErrorInfo>();
                InitSystemTypes();
            }

            public void Start()
            {
                this.workThread = new Thread(this.DoWork);

                this.workThread.Start();

            }

            public void ActiveOneTime()
            {
                engineEvent.Set();
            }

            public void AddWaitingParseModel(IModel model)
            {
                if (this.waitingParseModels.Count(x => x.FileId == model.FileId) > 0)
                {
                    return;
                }

                this.waitingParseModels.Add(model);
            }

            private void DoWork()
            {
                IsWiseCompleted = true;

                while (true)
                {
                    if (!engineEvent.WaitOne(1000 * 10))
                    {
                        IsWiseCompleted = true;
                        continue;
                    }

                    IsWiseCompleted = false;

                    foreach (var model in this.waitingParseModels.ToArray())
                    {
                        Parse(model, -1, null);
                    }

                    if (parseEvent.WaitOne(1000 * 5))
                    {

                        Wise();

                        IsWiseCompleted = true;

                        if (this.WiseCompleted != null)
                            this.WiseCompleted(this.Errors.ToList());

                        while (this.Errors.Count > 0)
                        {
                            this.Errors.Take();
                        }
                    }
                    //byWaitEvent.Set();
                }
            }

            public void Stop()
            {
                this.workThread.Abort();
            }

            private void WiseModule(IParseModule module)
            {
                foreach (var type in module.Types)
                {
                    Wise_Type(type, module);
                }
            }

            void Parse(IModel model, int charIndex, System.Action callback)
            {
                var text = model.Content;

                ThreadPool.QueueUserWorkItem(o =>
                {
                    try
                    {
                        var parseInfo = new ParseInfo();
                        parseInfo.Content = text;
                        parseInfo.Index = charIndex;
                        parseInfo.Type = model.ParseType;
                        var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
                        string json = null;

                        lock (this.syncObj)
                        {
                            if (!ConnectProxy.Instance().Send(parseInfo_json))
                            {
                                model.SetParsed(false);
                                return;
                            }
                            json = ConnectProxy.Instance().Read();
                        }

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
                            }
                            else if (model.ParseType == CodeHelper.Core.Parser.ParseType.DataModel)
                            {
                                var program = JsonConvert.DeserializeObject<DbProgram>(json);
                                module = new DmModelDB();
                                ((DmModelDB)module).Program = program; 
                                module.Name = System.IO.Path.GetFileNameWithoutExtension(model.File);
                            }
                            else if (model.ParseType == Core.Parser.ParseType.DataView)
                            {
                                module = JsonConvert.DeserializeObject<DataViewDB>(json);
                            }
                            else if (model.ParseType == Core.Parser.ParseType.ViewModel)
                            {
                                module = JsonConvert.DeserializeObject<ViewModelDB>(json);
                                ViewModelDB.Current = module as ViewModelDB;
                            }
                            else if (model.ParseType == Core.Parser.ParseType.WorkFlow)
                            {
                                var program = JsonConvert.DeserializeObject<Program>(json);
                                module = new WorkflowDB();
                                ((WorkflowDB)module).Program = program;
                                WorkflowDB.Current = module as WorkflowDB;
                                module.Name = System.IO.Path.GetFileNameWithoutExtension(model.File);                                
                            }
                        }
                        catch (Exception e)
                        {
                            this.AddError(new Core.Error.ParseErrorInfo()
                            {
                                FileId = model.FileId,
                                File = model.File,
                                ErrorType = Core.Error.ErrorType.Error,
                                Message = "模块解析错误: " + e.Message
                            });
                        }
                        if (module == null)
                        {
                            //this.IsWiseCompleted = true;
                            model.SetParsed(false);
                            OnRemoveModule(model.FileId);
                            return;
                        }

                        module.Initialize();

                        module.FileId = model.FileId;

                        model.SetParsed(true);

                        module.Errors.ForEach(x => { x.File = model.File; x.FileId = model.FileId; });

                        //OnUpdateModule(model.FileId, module);

                        this.waitingWiseModules.Add(module);

                        if (module.Errors != null)
                        {
                            module.Errors.ForEach(x => AddError(x));
                        }

                    }
                    catch (Exception e)
                    {
                        this.AddError(new Core.Error.ParseErrorInfo()
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

                        this.waitingParseModels.Take();

                        if (this.waitingParseModels.Count == 0)
                        {
                            parseEvent.Set();
                        }
                        else
                        {
                        }
                    }
                });
            }

            void Wise()
            {
                try
                {
                    waitingWiseModules.ToList().ForEach(x => {
                        x.Wise();
                        x.Errors.ForEach(e =>this.AddError(e));
                        this.OnRemoveModule(x.FileId);
                        this.OnUpdateModule(x.FileId, x);
                    
                    });

                    var followIds = GlobalService.DepencyManager.GetFollows(waitingWiseModules.Select(x => x.FileId).ToList())
                        .Select(x => x.ModuleId).Distinct().ToList();

                    var module_wising = new List<IParseModule>();
                    module_wising.AddRange(this.waitingWiseModules);
                    module_wising.AddRange(ParsedModules.Values.Where(x => followIds.Contains(x.FileId)));

                    module_wising.ToList().ForEach(x =>
                    {
                        try
                        {
                            //OnUpdateModule(x.FileId, x);

                            WiseModule(x);
                        }
                        catch (Exception e)
                        {
                            this.AddError(new Core.Error.ParseErrorInfo()
                            {
                                FileId = x.FileId,
                                File = x.File,
                                ErrorType = Core.Error.ErrorType.Error,
                                Message = "模块语义错误: " + e.Message
                            });
                        }
                    });

                }
                catch (Exception e)
                {
                    this.AddError(new Core.Error.ParseErrorInfo()
                    {
                        File = null,
                        ErrorType = Core.Error.ErrorType.Error,
                        Message = "语义分析系统错误" + e.Message
                    });
                }

                //移除不重复的类型
                this.RepeatTypes.Keys.ToList().ForEach(key =>
                {
                    if (this.RepeatTypes[key].Count == 1)
                    {
                        this.RepeatTypes.Remove(key);
                    }
                }
                    );


                this.RepeatTypes.Keys.ToList().ForEach(key => this.RepeatTypes[key].ForEach(type =>
                {
                    var file = "";
                    if (type.FileId.HasValue)
                    {
                        file = GlobalService.ModelManager.GetModel(type.FileId.Value).File;
                    }
                    this.AddError(new ParseErrorInfo()
                    {
                        FileId = type.FileId,
                        File = file,
                        Line = type.Line,
                        CharPositionInLine = type.CharPositionInLine,
                        ErrorType = ErrorType.Error,
                        Message = string.Format("类型重复:{0}", type.FullName)
                    });
                }));

                while (this.waitingWiseModules.Count > 0)
                {
                    this.waitingWiseModules.Take();
                }
            }

            void AddTypes(string name_space, IParseModule module)
            {
                foreach (var type in module.Types)
                {
                    AddTypes_Implements(name_space, type);
                }
            }

            bool CheckIsRepeatType_WhenAdd(ITypeInfo type)
            {
                List<ITypeInfo> repeatTypes = null;

                //当更新文档后
                if (RepeatTypes.ContainsKey(type.FullName))
                {

                    repeatTypes = this.RepeatTypes[type.FullName];
                    if (repeatTypes.FirstOrDefault(x => x.FileId == type.FileId) == null)
                    {
                        repeatTypes.Add(type);
                    }
                    return true;
                }

                //首次编译
                if (Types.ContainsKey(type.FullName))
                {
                    if (this.RepeatTypes.ContainsKey(type.FullName))
                    {
                        repeatTypes = this.RepeatTypes[type.FullName];
                    }
                    else
                    {
                        repeatTypes = new List<ITypeInfo>();
                        this.RepeatTypes.Add(type.FullName, repeatTypes);
                    }

                    if (type.FileId != Types[type.FullName].FileId)
                    {
                        repeatTypes.Add(Types[type.FullName]);
                        repeatTypes.Add(type);
                    }
                    return true;
                }



                return false;
            }


            private void CheckIsRepeatType_WhenRemove(ITypeInfo type)
            {

            }

            void RemoveRepeatType(Guid fileId)
            {
                this.RepeatTypes.Values.ToList().ForEach(x =>
                {

                    x.ToList().ForEach(y =>
                    {
                        if (y.FileId == fileId)
                        {
                            x.Remove(y);
                        }
                    });
                });

                //List<ITypeInfo> repeatTypes = null;                

                //if (this.RepeatTypes.ContainsKey(type.FullName))
                //{
                //    repeatTypes = this.RepeatTypes[type.FullName];

                //    var repeatType = repeatTypes.FirstOrDefault(x => x.FileId == type.FileId);
                //    if (repeatType != null)
                //    {
                //        repeatTypes.Remove(repeatType);
                //    }
                //}

            }

            void AddTypes_Implements(string prefix, ITypeInfo type)
            {
                if (!string.IsNullOrWhiteSpace(prefix))
                    type.FullName = prefix + "." + type.Name;
                else
                {
                    type.FullName = type.Name;
                }

                if (CheckIsRepeatType_WhenAdd(type))
                { };

                if (Types.Count(x => x.Key == type.FullName) == 0)
                {
                    Types.Add(type.FullName, type);
                }

                foreach (var t in type.TypeInfos)
                {
                    AddTypes_Implements(type.FullName, t);
                }
            }


            void RemoveTypes(string name_space, IParseModule module)
            {
                RemoveRepeatType(module.FileId);

                foreach (var type in module.Types)
                {
                    RemoveTypes_Implements(name_space, type, module);
                }
            }

            void RemoveTypes_Implements(string prefix, ITypeInfo type, IParseModule module)
            {
                //判断是否有重复类型定义
                if (!Types.ContainsKey(type.FullName))
                {
                    return;
                }

                if (Types[type.FullName].FileId == module.FileId)
                {

                    Types.Remove(type.FullName);

                    //如果含有重复定义，则用重复定义类
                    if (this.RepeatTypes.ContainsKey(type.FullName))
                    {
                        var anotherType = this.RepeatTypes[type.FullName].FirstOrDefault(x => x.FileId != type.FileId);
                        if (anotherType != null)
                        {
                            Types.Add(anotherType.FullName, anotherType);
                        }
                        else
                        {
                        }
                    }

                    foreach (var t in type.TypeInfos)
                    {
                        RemoveTypes_Implements(type.FullName, t, module);
                    }
                }
            }

            void FillTypeInfo(Guid fileId, ITypeInfo type)
            {
                type.FileId = fileId;

                foreach (var childType in type.TypeInfos)
                {
                    FillTypeInfo(fileId, childType);
                }
            }

            void OnUpdateModule(Guid fileId, IParseModule module)
            { 
                //模块内重复类型验证
                module.Types.ForEach(x => {
                    if (module.Types.Where(y => x != y && y.Name.Equals(x.Name)).Count() > 0)
                    {
                        this.AddError(new ParseErrorInfo()
                        {
                            CharPositionInLine = x.TokenPair.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            File = module.File,
                            FileId = module.FileId,
                            Line = x.TokenPair.BeginToken.Line,
                            Message = string.Format("类型{0}在文件内重复", x.Name)
                        });
                    }
                });

                module.Types.ForEach(x => FillTypeInfo(fileId, x));
               
                if (!ParsedModules.ContainsKey(fileId))
                {
                    ParsedModules.Add(fileId, module);
                }
                else
                {
                    ParsedModules[fileId] = module;
                }

                var name_space = GetNameSpace(module.NameSpace);

                List<IParseModule> ms = null;

                AddTypes(module.NameSpace, module);
                
                if (!Namespace_Modules.ContainsKey(name_space))
                {
                    ms = new List<IParseModule>();
                    ms.Add(module);
                    Namespace_Modules.Add(name_space, ms);
                    
                }
                else
                {
                    ms = Namespace_Modules[name_space];
                    if (ms.Where(x => x.FileId == module.FileId).Count() == 0)
                    {
                        ms.Add(module);
                        //AddTypes(module.NameSpace, module);
                    }
                    else
                    {
                        var old = ms.Find(x => x.FileId == module.FileId);
                        ms.Remove(old);
                        //RemoveTypes(old.NameSpace, old);
                        ms.Add(module);
                        //AddTypes(module.NameSpace, module);
                    }
                }
            }

            internal void OnRemoveModule(Guid fileId)
            {
                if (ParsedModules.ContainsKey(fileId))
                {
                    var m = ParsedModules[fileId];

                    RemoveTypes(m.NameSpace, m);

                    ParsedModules.Remove(fileId);
                }

                var key = Namespace_Modules.Keys.Where(x =>
                    Namespace_Modules[x].Count(y => y.FileId == fileId) > 0).FirstOrDefault();

                if (key == null)
                    return;

                var ms = Namespace_Modules[key];

                var module = ms.Find(x => x.FileId == fileId);

                ms.Remove(module);

                if (ms.Count == 0)
                    Namespace_Modules.Remove(key);                

            }

            void model_InvokeParse(IModel model, int charIndex)
            {
                Parse(model, charIndex, null);
            }

            private string GetNameSpace(string s)
            {
                return string.IsNullOrWhiteSpace(s) ? "" : s.Trim();
            }

            private void InitSystemTypes()
            {
                var t = new TypeInfoBase();
                var t_net = typeof(int);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("int", t);
                this.Types.Add("Int32", t);
                this.Types.Add("System.Int32", t);

                t = new TypeInfoBase();
                t_net = typeof(float);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("float", t);
                this.Types.Add("Float", t);
                this.Types.Add("System.Float", t);

                t = new TypeInfoBase();
                t_net = typeof(Double);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("double", t);
                this.Types.Add("Double", t);
                this.Types.Add("System.Double", t);

                t = new TypeInfoBase();
                t_net = typeof(Decimal);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("decimal", t);
                this.Types.Add("Decimal", t);
                this.Types.Add("System.Decimal", t);

                t = new TypeInfoBase();
                t_net = typeof(DateTime);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("DateTime", t);
                this.Types.Add("System.DateTime", t);

                t = new TypeInfoBase();
                t_net = typeof(char);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("char", t);
                this.Types.Add("Char", t);
                this.Types.Add("System.Char", t);

                t = new TypeInfoBase();
                t_net = typeof(string);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("string", t);
                this.Types.Add("String", t);
                this.Types.Add("System.String", t);

                t = new TypeInfoBase();
                t_net = typeof(bool);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("bool", t);
                this.Types.Add("Boolean", t);
                this.Types.Add("System.Boolean", t);

                t = new TypeInfoBase();
                t_net = typeof(Guid);
                t.FullName = t_net.FullName;
                t.IsPrimitive = t_net.IsPrimitive;

                this.Types.Add("guid", t);
                this.Types.Add("Guid", t);
                this.Types.Add("System.Guid", t);

            }

            public List<ITypeInfo> ParseType(string type, IParseModule ctx, out string error)
            {
                error = null;

                if (string.IsNullOrWhiteSpace(type))
                {
                    return null;
                }

                // 泛型处理，目前仅支持List<T>
                bool isGenericType = false;

                if (type.Count(c => c == '<') > 1)
                {
                    error = "目前泛型定义仅支持List<T>，且一重泛型";
                    return null;
                }
                if (type.IndexOf("<") > 0)
                {
                    if (!type.StartsWith("List<"))
                    {
                        error = "目前泛型定义仅支持List<T>，且一重泛型";
                        return null;
                    }
                    else
                    {
                        isGenericType = true;
                    }
                }

                //获得GenericParameter

                var genericParameter = type.Replace("List<", "").Replace(">", "");

                var parameterTypes = ParseGenericType(genericParameter, ctx, out error);

                if (!isGenericType)
                {
                    return parameterTypes;
                }

                var rslt = new List<ITypeInfo>(4);
                parameterTypes.ForEach(x => rslt.Add(new TypeInfoBase()
                {
                    CharPositionInLine = x.CharPositionInLine,
                    FullName = string.Format("List<{0}>", x.FullName),
                    GenericParameterType = x,
                    IsGenericType = true,
                    IsGenericTypeDefinition = true,
                    Line =
                        x.Line,
                    IsPrimitive = x.IsPrimitive,
                    Length = x.Length,
                    Name = type
                }));

                return rslt;
            }

            public List<ITypeInfo> ParseGenericType(string type, IParseModule ctx, out string error)
            {
                error = null;

                if (string.IsNullOrWhiteSpace(type))
                {
                    return null;
                }


                #region 基础类型

                #endregion

                var rslt = new List<ITypeInfo>(4);

                if (string.IsNullOrWhiteSpace(type) || ctx == null)
                {
                    return rslt;
                }

                var list = new List<string>();
                list.Add(type);

                if (!string.IsNullOrWhiteSpace(ctx.NameSpace))
                {
                    list.Add(ctx.NameSpace + "." + type);
                }

                if (ctx.UsingNameSpaces != null || ctx.UsingNameSpaces.Count == 0)
                {
                    ctx.UsingNameSpaces.ForEach(x => list.Add(x + "." + type));
                }

                list.ForEach(x =>
                {
                    if (Types.ContainsKey(x))
                    {
                        rslt.Add(Types[x]);
                    }
                }
                        );

                return rslt;
            }

            private void AddError(ParseErrorInfo error)
            {
                this.Errors.Add(error);
            }

            private void Wise_Type(ITypeInfo type, IParseModule module)
            {
                string error;
                foreach (var p in type.PropertyInfos)
                {
                    var types = ParseType(p.Type, module, out error);
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        AddError(new ParseErrorInfo()
                        {
                            FileId = module.FileId,
                            File = module.File,
                            CharPositionInLine = p.TokenPair.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = p.TokenPair.BeginToken.Line,
                            Message = error
                        });
                    }
                    if (types == null || types.Count == 0)
                    {
                        AddError(new ParseErrorInfo()
                        {
                            FileId = module.FileId,
                            File = module.File,
                            CharPositionInLine = p.TokenPair.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = p.TokenPair.BeginToken.Line,
                            Message = string.Format("当前上下文无此类型{0}", p.Type)
                        });
                    }
                    else if (types.Count > 1)
                    {
                        AddError(new ParseErrorInfo()
                        {
                            FileId = module.FileId,
                            File = module.File,
                            CharPositionInLine = p.TokenPair.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = p.TokenPair.BeginToken.Line,
                            Message = string.Format("当前上下文有多个此类型{0}:{1}"
                            , p.Type
                            , String.Join(",", types.Select(x => x.FullName).ToArray()))

                        });
                    }
                    else
                    {
                        p.TypeInfo = types[0];

                    }

                    if (types == null)
                        return;

                    types.ForEach(x =>
                    {
                        if (x.FileId.HasValue)//说明不是.NET类型
                        {

                            var dependence_Fellow = GlobalService.DepencyManager.GetRelation(module.FileId);

                            if (dependence_Fellow == null)
                            {
                                dependence_Fellow = new ModuleRelationBase();

                                dependence_Fellow.ModuleId = module.FileId;

                                GlobalService.DepencyManager.AddRelation(dependence_Fellow);

                            }

                            IModuleRelation dependence = GlobalService.DepencyManager.GetRelation(x.FileId.Value);

                            if (dependence == null)
                            {
                                dependence = new ModuleRelationBase()
                                {
                                    ModuleId = x.FileId.Value
                                };

                                GlobalService.DepencyManager.AddRelation(dependence);
                            }

                            if (!dependence.Follows.Contains(dependence_Fellow.ModuleId.Value))
                            {
                                if (dependence.ModuleId != dependence_Fellow.ModuleId)
                                {
                                    dependence.Follows.Add(dependence_Fellow);
                                }
                            }
                        }
                    });
                }
            }

            internal IParseModule GetParseModule(Guid fileId)
            {
                if (this.ParsedModules.ContainsKey(fileId))
                    return this.ParsedModules[fileId];

                return null;
            }
        }

    }
}
