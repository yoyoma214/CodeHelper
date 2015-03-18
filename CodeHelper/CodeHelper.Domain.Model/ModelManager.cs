using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Domain.Model.XmlModels;
using CodeHelper.Domain.Model.DataModels;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Core.Parser;
using System.Threading;
using CodeHelper.Parser;
using CodeHelper.Core.Parse.ParseResults.XmlModels;
using Newtonsoft.Json;
using CodeHelper.Core.Parse.ParseResults.DataModels;
using CodeHelper.Core.Error;
using CodeHelper.Core.Services;
using System.IO;
using CodeHelper.Core.Types;
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Infrastructure.Command;
using CodeHelper.Core.Command;
using CodeHelper.Commands;
using Project;

namespace CodeHelper.Domain.Model
{
    public partial class ModelManager : IModelManager
    {
        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        AutoResetEvent ResetEvent = new AutoResetEvent(false);

        WorkEngine workEngine = new WorkEngine();

        //bool engineWaiting = false;
        //object objSync = new object();

        DateTime autoParseTime;

        //Semaphore semaphore = new Semaphore(0, 1000);

        const int AUTO_PARSE_INTERVAL = 2;

        public event OnParseError ParseError;

        public List<ParseErrorInfo> Errors
        {
            get;
            set;
        }

        /// <summary>
        /// 1 : true 0 :false
        /// </summary>
        private long WiseCompeleted = 0;

        /// <summary>
        /// 1 : true 0 :false
        /// </summary>
        private long EnableAutoParse = 0;

        private Dictionary<Guid, IModel> Models = new Dictionary<Guid, IModel>();

        private Dictionary<Guid, IParseModule> ParseModules = new Dictionary<Guid, IParseModule>();

        private Dictionary<string, List<IParseModule>> Namespace_Modules
                                                  = new Dictionary<string, List<IParseModule>>();

        //private Dictionary<string, ITypeInfo> Types = new Dictionary<string, ITypeInfo>();

        private ModelManager()
        {
            autoParseTime = DateTime.Now;
            EnableAutoParse = 1;

            //var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
            //cmdHost_common.AddCommand(new ExitProcessCommand(this.Receiver));

            this.Errors = new List<ParseErrorInfo>();
            
            GlobalService.Idle += new EventHandler(GlobalService_Idle);

            this.receiver.OnExitProcess += new ReceiverBase.ExitProcessHandler(receiver_OnExitProcess);
            workEngine.WiseCompleted += new OnWiseCompleted(workEngine_WiseCompleted);
            workEngine.Continue += new OnContinue(workEngine_Continue);
            workEngine.Start();
        }

        bool receiver_OnExitProcess()
        {
            this.workEngine.Stop();

            return false;
        }

        void workEngine_Continue()
        {
            //this.engineWaiting = false; 
        }

        void workEngine_WiseCompleted(List<ParseErrorInfo> errors)
        {
            //engineWaiting = true;

            if (this.ParseError != null && errors != null)
            {
                var copy = new ParseErrorInfo[errors.Count];
                errors.CopyTo(copy);
                this.ParseError(null, copy.ToList());
            }

            //mClearError = true;
            //this.Errors.Clear();


            this.Errors = errors;
            this.ResetEvent.Set();
        }

        public IModel MakeSureModel(string file)
        {

            foreach (var m in Models.Values)
            {
                if (m.File == file)
                {
                    return m;
                }
            }

            var extension = Path.GetExtension(file);

            IModel model = null;

            if (extension == Dict.Extenstions.XmlModel_Extension)
            {
                model = new Domain.Model.XmlModels.XmlModel();
            }
            if (extension == Dict.Extenstions.DataModel_Extension)
            {
                model = new Domain.Model.DataModels.DataModel();
            }
            if (extension == Dict.Extenstions.DataView_Extension)
            {
                model = new Domain.Model.DataViews.DataView();
            }
            if (extension == Dict.Extenstions.ViewModel_Extension)
            {
                model = new Domain.Model.ViewModels.ViewModel();
            }
            if (extension == Dict.Extenstions.WorkFlow_Extension)
            {
                model = new Domain.Model.WorkFlows.WorkFlow();
            }
            model.FileId = Guid.NewGuid();

            model.File = file;

            model.Open();

            //model.NameSpace = nameSpace;

            this.Regist(model);

            return model;
        }

        private bool mClearError = false;

        void GlobalService_Idle(object sender, EventArgs e)
        {
               if (DateTime.Now.Subtract(autoParseTime).TotalSeconds > AUTO_PARSE_INTERVAL
                && Interlocked.Read(ref EnableAutoParse ) == 1
                )
            {
                if (this.workEngine.IsWiseCompleted)
                {
                    var waitingForParseModels = this.Models.Values.Where(x =>
                        
                        !x.IsParsed && x.Content.Count(c => c == '\n') > 2)//至少有3行
                        
                        .ToList();
                    
                    waitingForParseModels.ForEach(x =>
                            this.workEngine.AddWaitingParseModel(x)
                     );

                    if (waitingForParseModels.Count > 0)
                    {
                        this.workEngine.ActiveOneTime();
                    }
                }

            }
               /*
               if (this.workEngine.IsWiseCompleted)
               {
                   if (this.ParseError != null && Errors != null && mClearError)
                   {
                       var copy = new ParseErrorInfo[Errors.Count];
                       Errors.CopyTo(copy);
                       this.ParseError(null, copy.ToList());
                   }

                   //mClearError = true;
                   //this.Errors.Clear();
               }
               */

            //if (Interlocked.Read(ref WiseCompeleted) == 1 && Interlocked.Read( ref this.needParse ) == 1)
            //{
            //    Interlocked.Decrement(ref this.WiseCompeleted);
            //    Interlocked.Decrement(ref this.needParse);

            //    if (this.ParseError != null)
            //    {
            //        var copy = new ParseErrorInfo[Errors.Count];
            //        Errors.CopyTo(copy);
            //        this.ParseError(null, copy.ToList());
            //    }
                
            //    Errors.Clear();
                
            //    System.Console.WriteLine(DateTime.Now.ToString());
            //}

        }

        private static ModelManager instance = new ModelManager();

        public static ModelManager Instance()
        {
            return instance;
        }

        public IParseModule MakeSureParseModule(string file)
        {

            var model = this.MakeSureModel(file);

            if (this.workEngine.ParsedModules.ContainsKey(model.FileId))
                return this.workEngine.ParsedModules[model.FileId];

            this.workEngine.AddWaitingParseModel(model);

            this.workEngine.ActiveOneTime();

            ResetEvent.WaitOne(10000);

            if (this.workEngine.ParsedModules.ContainsKey(model.FileId))
                return this.workEngine.ParsedModules[model.FileId];

            return null;

            //var model = this.MakeSureModel(file);

            //if (this.ParseModules.ContainsKey(model.FileId))
            //    return this.ParseModules[model.FileId];

            //if (string.IsNullOrWhiteSpace(model.Content))
            //{
            //    model.Open();
            //}

            //this.workEngine.WaitWiseCompleted();

            //this.workEngine.waitingParseModels.Add(model);

            ////this.Parse(model, -1, () =>
            ////{
            ////    ResetEvent.Set();
            ////});

            ////this.workEngine.waitingParseModels

            //ResetEvent.WaitOne(10000);

            //if (this.ParseModules.ContainsKey(model.FileId))
            //    return this.ParseModules[model.FileId];
            //else
            //    return null;
        }

        public void Regist(IModel model)
        {
            //if (model is XmlModel)
            //{
            //    this.XmlModels.Add(model.File, model as XmlModel);
            //}
            this.Models.Add(model.FileId, model);

            OnRegist(model);

        }

        private void OnRegist(IModel model)
        {
            model.ChangeName += new OnChangeName(model_ChangeName);
            model.InvokeParse +=new OnInvokeParse(model_InvokeParse);
            model.Removed += new OnRemoved(model_Removed);
        }

        private void OnRemove(IModel model)
        {
            model.ChangeName -= new OnChangeName(model_ChangeName);
            model.InvokeParse -= new OnInvokeParse(model_InvokeParse);
            model.Removed -= new OnRemoved(model_Removed);
        }
       
        private string GetNameSpace(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? "" : s.Trim();
        }

        void model_InvokeParse(IModel model, int charIndex)
        {
            //throw new NotImplementedException();
        }

        void model_Removed(IModel model)
        {
            throw new NotImplementedException();
        }

        void model_ChangeName(IModel model, string oldName, string newName)
        {
            throw new NotImplementedException();
        }

        //private Dictionary<string, ITypeInfo> SystemTypes = new Dictionary<string, ITypeInfo>();

        public IModel GetModel(Guid file)
        {
            if (this.Models.ContainsKey(file))
                return this.Models[file];

            return null;
        }

        public void Remove(IModel model)
        {
            this.workEngine.OnRemoveModule(model.FileId);
            this.Models.Remove(model.FileId);
            this.Models.Add(model.FileId, model);
            this.OnRemove(model);
        }

        public void Remove(Guid fileId)
        {
            if (this.Models.ContainsKey(fileId))
            {
                var model = this.Models[fileId];
                this.Remove(model);
            }
        }

        //public OnInvokeParse model_InvokeParse { get; set; }

        public List<ITypeInfo> ParseType(string type, IParseModule ctx, out string error)
        {
            return this.workEngine.ParseType(type, ctx, out error);            
        }

        public void RegistDb(ConnectionType conn)
        {
            #region remove all exsited types

            var deletingTypes = new List<string>();

            foreach (var key in this.workEngine.Types.Keys)
            {
                if (key.StartsWith("db."+ conn.Name + "."))
                {
                    deletingTypes.Add(key);
                }
            }
            
            foreach (var key in deletingTypes)
            {
                this.workEngine.Types.Remove(key);
            }
            #endregion

            //var tables = conn.Tables;
            //for(var i = 0 ; i < tables.
            foreach(TableType table in conn.Tables)
            {
                var type = new TypeInfoBase();
                type.Name = table.Name;
                type.FullName = "db." + conn.Name + "." + type.Name;

                string error = null;

                foreach (var field in table.ColumnSet.Columns)
                {
                    var property = new PropertyInfoBase();
                    if ( !string.IsNullOrWhiteSpace(field.Description))
                    {
                        var attr = new AttributeInfo();
                        attr.Name = "Comments";
                        attr.Parameters.Add(field.Description);

                        property.Attributes.Add(attr);
                    }

                    property.Name = field.Name;
                    property.Nullabe = field.AllowDBNull;
                    property.Type = field.SystemType;
                    var types =  this.ParseType(field.SystemType, null, out error);
                    if (types != null && types.Count == 1)
                        property.TypeInfo = types[0];

                    type.PropertyInfos.Add(property);

                }
                this.workEngine.Types.Add(type.FullName, type);
            }
            
        }

        public IParseModule GetParseModule(Guid fileId)
        {
            return this.workEngine.GetParseModule(fileId);
        }
    }
}
