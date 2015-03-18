using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Core.Error;
using System.Threading;
//using Parser;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parser;
using System.IO;

namespace CodeHelper.Domain.Model
{
    public abstract class BaseModel : IModel
    {
        //public delegate void OnChanged();

        //public event OnChanged Changed;

        //public void OnChange();

        public string File
        {
            get;
            set;
        }

        bool modifed;
        public bool Modifed
        {
            get
            {
                return modifed;                
            }
            set
            {
                modifed = value;

                if (value)
                {
                    this.IsParsed = false;

                    if (Changed != null)
                    {
                        Changed(this);
                    }
                }
                else
                {
                    if (Saved != null)
                    {
                        Saved(this);
                    }
                }
            }
        }

        public event OnChanged Changed;

        public void Parse(int charIndex)
        {
            var errors = new List<ParseErrorInfo>();
            var text = this.Content;
            if (!this.Opened)
            {
                text = System.IO.File.ReadAllText(this.File);
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                errors.Add(new ParseErrorInfo()
                { 
                    FileId = this.FileId,
                    ErrorType= ErrorType.Info,
                    Line = 0,
                    Message = "没有数据",
                    CharPositionInLine = 0
                });                
            }

            if (this.InvokeParse != null)
            {
                this.InvokeParse(this, charIndex);
            }

            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    var parseInfo = new ParseInfo();
            //    parseInfo.Content = text;
            //    parseInfo.Index = charIndex;
            //    parseInfo.Type = this.ParseType;
            //    var parseInfo_json = Newtonsoft.Json.JsonConvert.SerializeObject(parseInfo);
            //    var result_json = XmlModelParser.Instance().Parse(parseInfo_json);
            //    if (result_json.Errors != null && result_json.Errors.Count > 0)
            //    {
            //        GlobalService.PushParseError(this.File, result_json.Errors);
            //    }
                
            //    this.NeedParse(this,charIndex);

            //    //if (this.Parsed != null)
            //    //{
            //    //    this.Parsed(this);
            //    //}
            //});
        }

        public bool Opened
        {
            get;
            set;
        }
        
        public string Content
        {
            get;
            set;
        }

        public virtual ParseType ParseType
        {
            get;set;
        }

        public event OnParsed Parsed;

        public event OnInvokeParse InvokeParse;

        public event OnChangeName ChangeName;

        public event OnRemoved Removed;

        public void SetParsed(bool success)
        {
            this.IsParsed = success;

            if (this.Parsed != null)
            {
                this.Parsed(this, success);                
            }
        }

        public void Open()
        {
            if (this.Opened)
            {
                throw new Exception("已经打开");
            }

            this.Content = System.IO.File.ReadAllText(this.File);

            this.Opened = true;
        }

        public bool IsParsed
        {
            get;
            set;
        }

        public Guid FileId
        {
            get;
            set;
        }

        public event OnSaved Saved;


        public void Save()
        {
            StreamWriter w = null;

            if (System.IO.File.Exists(this.File))
            {
                System.IO.File.Delete(this.File);
            }

            w = System.IO.File.CreateText(this.File);
            w.Write(this.Content);
            w.Flush();
            w.Close();

            this.Modifed = false;
        }


        public string NameSpace
        {
            get;
            set;
        }
    }
}
