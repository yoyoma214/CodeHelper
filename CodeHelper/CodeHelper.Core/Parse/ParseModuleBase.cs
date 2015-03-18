using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Error;
using CodeHelper.Core.Types;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parse
{
    public abstract class ParseModuleBase : TokenPair, IParseModule
    {
        public ParseModuleBase()
        {
            Types = new List<ITypeInfo>();
            Errors = new List<ParseErrorInfo>();
            UsingNameSpaces = new List<string>();
        }

        public string Name { get; set; }

        public virtual ParseType ParseType
        {
            get;
            set;
        }

        public List<ParseErrorInfo> Errors
        {
            get;
            set;
        }

        public string NameSpace
        {
            get;
            set;
        }

        public List<string> UsingNameSpaces
        {
            get;
            set;
        }

        string mFile = null;

        public string File
        {
            get
            {
                if (GlobalService.ModelManager != null)
                {
                    var model = GlobalService.ModelManager.GetModel(this.FileId);
                    if (model == null)
                        return null;

                    return model.File;
                }
                else
                    return mFile;
            }
            set
            {
                mFile = value;
            }

        }

        public Guid FileId
        {
            get;
            set;
        }


        public List<ITypeInfo> Types
        {
            get;
            set;
        }

        public abstract void Initialize();

        public virtual void Wise()
        {
            foreach (var t in this.Types)
            {
                t.Wise();
            }            
        }

        public List<IParseModule> DependenceModules
        {
            get;
            set;
        }

        public InputCharInfo InputChar
        {
            get;
            set;
        }
    }
}
