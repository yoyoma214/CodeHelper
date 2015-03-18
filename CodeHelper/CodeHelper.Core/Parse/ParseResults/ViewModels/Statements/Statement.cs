using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Statements
{
    public class Statement : TokenPair
    {
        public Expression Expression { get; set; }
        public Declare_Statement Declare_Statement { get; set; }
        public Push Push { get; set; }
        public Pull Pull { get; set; }

        internal StatementInfo Parse(ModelInfo model)
        {
            StatementInfo rslt = null;
            if (this.Expression != null)
            {
                rslt = this.Expression.Parse();
                if (model != null)
                {
                    model.StatementInfos.Add(rslt);
                }
            }
            if (this.Declare_Statement !=null )
            {
                //rslt = this.Declare_Statement.Parse();
                if (model != null)
                {
                    model.Variables.Add(this.Declare_Statement.Parse());
                }
                else
                {
                    ViewModelDB.Current.Errors.Add(new Error.ParseErrorInfo()
                    {
                        FileId = ViewModelDB.Current.FileId,
                        File = ViewModelDB.Current.File,
                        CharPositionInLine = this.BeginToken.CharPositionInLine,
                        Line = this.BeginToken.Line,
                        ErrorType = Error.ErrorType.Error,
                        Message = "不能在这里声明变量"
                    });
                }
            }
            if (this.Push != null)
            {
                if (model != null)
                {
                    model.PushInfos.Add(this.Push.Parse(null));
                }
                else
                {
                    ViewModelDB.Current.Errors.Add(new Error.ParseErrorInfo()
                    {
                        FileId = ViewModelDB.Current.FileId,
                        File = ViewModelDB.Current.File,
                        CharPositionInLine = this.BeginToken.CharPositionInLine,
                        Line = this.BeginToken.Line,
                        ErrorType = Error.ErrorType.Error,
                        Message = "不能在这里声明推语句"
                    });
                }
            }
            if (this.Pull != null)
            {
                if (model != null)
                {
                    model.PullInfos.Add(this.Pull.Parse());
                }
                else
                {
                    ViewModelDB.Current.Errors.Add(new Error.ParseErrorInfo()
                    {
                        FileId = ViewModelDB.Current.FileId,
                        File = ViewModelDB.Current.File,
                        CharPositionInLine = this.BeginToken.CharPositionInLine,
                        Line = this.BeginToken.Line,
                        ErrorType = Error.ErrorType.Error,
                        Message = "不能在这里声明拉语句"
                    });
                }
            }

            return rslt;
        }
    }
}