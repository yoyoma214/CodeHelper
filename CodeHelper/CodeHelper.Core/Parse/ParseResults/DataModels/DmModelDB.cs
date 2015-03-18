using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Error;
using CodeHelper.Core.Services;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class DmModelDB : ParseModuleBase
    {
        //private Dictionary<String, ModelInfo> models = new Dictionary<String, ModelInfo>();
        //private List<MappingInfo> mapings = new List<MappingInfo>();
        //private String nameSpace = null;

        public DmModelDB():base()
        {
            this.Mapings = new List<MappingInfo>();
            this.UsingNameSpaces = new List<string>();
            this.Models = new Dictionary<string, ModelInfo>();
        }

        public DbProgram Program { get; set; }

        public void AddModel(ModelInfo modelInfo)
        {
            Models.Add(modelInfo.Name, modelInfo);
        }

        public ModelInfo GetModel(String name)
        {
            return Models[name];
        }

        public Dictionary<String, ModelInfo> Models { get; set; }

        public List<MappingInfo> Mapings { get; set; }

        public override ParseType ParseType
        {
            get
            {
                return Parser.ParseType.DataModel;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Parse()
        {
            if (this.Program != null)
                this.Program.Parse(this);
        }

        public override void Initialize()
        {
            try
            {
                this.Parse();

                if (this.Models != null && this.Models.Count == 0)
                    return;

                this.Models.Values.ToList().ForEach(x =>
                {
                    this.Types.Add(x);
                    x.Init();
                });

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
            
        }

        private void AddError(ParseErrorInfo error)
        {
            this.Errors.Add(error);
        }

        private void AddError(IList<ParseErrorInfo> errors)
        {
            this.Errors.AddRange(errors);
        }

        public override void Wise()
        {
            string error = null;
            var errors = new List<ParseErrorInfo>();

            //列去重
            foreach (var model in this.Models.Values)
            {
                for (var i = 0; i < model.PropertyInfos.Count; i++)
                {
                    var column1 = model.PropertyInfos[i];
                    for (var j = i + 1; j < model.PropertyInfos.Count; j++)
                    {
                        var column2 = model.PropertyInfos[j];
                        if (column1.Name.Equals(column2.Name, StringComparison.InvariantCultureIgnoreCase))
                        {                                                      
                            errors.Add(new ParseErrorInfo()
                            {
                                FileId = this.FileId,
                                File = this.File,
                                CharPositionInLine = column2.TokenPair.BeginToken.CharPositionInLine,
                                ErrorType = ErrorType.Error,
                                Line = column2.TokenPair.BeginToken.Line,
                                Message = string.Format("{0}列重复", column1.Name)
                            });
                        }
                    }
                }
            }

            foreach (var mapping in this.Mapings)
            {
                #region Wise FromModel
                var types = GlobalService.ModelManager.ParseType(mapping.FromModel.Value, this, out error);
                
                if (!string.IsNullOrWhiteSpace(error))
                {
                    errors.Add(new ParseErrorInfo()
                    {
                        FileId = this.FileId,
                        File = this.File,
                        CharPositionInLine = mapping.FromModel.BeginToken.CharPositionInLine,
                        ErrorType = ErrorType.Error,
                        Line = mapping.FromModel.BeginToken.Line,
                        Message = error
                    });
                }
                if (types == null || types.Count == 0)
                {
                    errors.Add(new ParseErrorInfo()
                    {
                        FileId = this.FileId,
                        File = this.File,
                        CharPositionInLine = mapping.FromModel.BeginToken.CharPositionInLine,
                        ErrorType = ErrorType.Error,
                        Line = mapping.FromModel.BeginToken.Line,
                        Message = string.Format("当前上下文无此类型{0}", mapping.FromModel.Value)
                    });
                }
                else if (types.Count > 1)
                {
                    /*
                    errors.Add(new ParseErrorInfo()
                    {
                        FileId = this.FileId,
                        File = this.File,
                        CharPositionInLine = mapping.FromModel.BeginToken.CharPositionInLine,
                        ErrorType = ErrorType.Error,
                        Line = mapping.FromModel.BeginToken.Line,
                        Message = string.Format("当前上下文有多个此类型{0}:{1}"
                       , mapping.FromModel.Value
                       , mapping.FromModel.Value)
                        //,  String.Join(",", types.Select(x => x.FullName).ToArray()))

                    });
                     */
                }
                else
                {
                    //p.TypeInfo = types[0];
                }

                #endregion

                if (types != null && types.Count > 0)
                {
                    #region Wise FromField
                    var fromModel = types[0];
                    var fromField = mapping.FromField.Value;
                    bool has = false;
                    foreach (var p in fromModel.PropertyInfos)
                    {
                        if (p.Name.Equals(fromField))
                        {
                            has = true;
                            break;
                        }
                    }
                    if (!has)
                    {
                        errors.Add(new ParseErrorInfo()
                        {
                            FileId = this.FileId,
                            File = this.File,
                            CharPositionInLine = mapping.FromModel.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = mapping.FromModel.BeginToken.Line,
                            Message = string.Format("{0}没有该字段{1}", mapping.FromModel.Value, fromField)
                        });
                    }
                    #endregion

                    #region Wise TargetModel
                    types = GlobalService.ModelManager.ParseType(mapping.TargetModel.Value, this, out error);
                    if (!string.IsNullOrWhiteSpace(error))
                    {
                        errors.Add(new ParseErrorInfo()
                        {
                            FileId = this.FileId,
                            File = this.File,
                            CharPositionInLine = mapping.TargetModel.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = mapping.TargetModel.BeginToken.Line,
                            Message = error
                        });
                    }
                    if (types == null || types.Count == 0)
                    {
                        errors.Add(new ParseErrorInfo()
                        {
                            FileId = this.FileId,
                            File = this.File,
                            CharPositionInLine = mapping.TargetModel.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = mapping.TargetModel.BeginToken.Line,
                            Message = string.Format("当前上下文无此类型{0}", mapping.TargetModel.Value)
                        });
                    }
                    else if (types.Count > 1)
                    {
                        /*
                        errors.Add(new ParseErrorInfo()
                        {
                            FileId = this.FileId,
                            File = this.File,
                            CharPositionInLine = mapping.TargetModel.BeginToken.CharPositionInLine,
                            ErrorType = ErrorType.Error,
                            Line = mapping.TargetModel.BeginToken.Line,
                            Message = string.Format("当前上下文有多个此类型{0}:{1}"
                           , mapping.TargetModel.Value
                           , mapping.TargetModel.Value)
                            //,  String.Join(",", types.Select(x => x.FullName).ToArray()))

                        });
                         */
                    }
                    #endregion

                    if (types != null && types.Count > 0)
                    {
                        #region Wise TargetField
                        var targetModel = types[0];
                        var targetField = mapping.TargetField.Value;
                        has = false;
                        foreach (var p in targetModel.PropertyInfos)
                        {
                            if (p.Name.Equals(targetField))
                            {
                                has = true;
                                break;
                            }
                        }
                        if (!has)
                        {
                            errors.Add(new ParseErrorInfo()
                            {
                                FileId = this.FileId,
                                File = this.File,
                                CharPositionInLine = mapping.TargetModel.BeginToken.CharPositionInLine,
                                ErrorType = ErrorType.Error,
                                Line = mapping.TargetModel.BeginToken.Line,
                                Message = string.Format("{0}没有该字段{1}", mapping.TargetModel.Value, targetField)
                            });
                        }
                        #endregion

                        foreach (var showField in mapping.ShowFields)
                        {
                            #region Wise ShowField
                            has = false;
                            foreach (var p in targetModel.PropertyInfos)
                            {
                                if (p.Name.Equals(showField.Value))
                                {
                                    has = true;
                                    break;
                                }
                            }
                            if (!has)
                            {
                                errors.Add(new ParseErrorInfo()
                                {
                                    FileId = this.FileId,
                                    File = this.File,
                                    CharPositionInLine = showField.BeginToken.CharPositionInLine,
                                    ErrorType = ErrorType.Error,
                                    Line = showField.BeginToken.Line,
                                    Message = string.Format("{0}没有该字段{1}", mapping.TargetModel.Value, showField.Value)
                                });
                            }
                            #endregion
                        }
                    }
                }

                AddError(errors);
                //GlobalService.ModelManager.Errors.AddRange(errors);
            }


            //base.Wise();
        }

        public void RenderSql(IndentStringBuilder builder)
        {
            foreach (var type in this.Types)
            {
                builder.AppendFormatLine("IF OBJECT_ID(N'{0}',N'U') IS NOT NULL", type.Name);
                builder.AppendFormatLine("DROP TABLE [dbo].[{0}];", type.Name);
                builder.AppendFormatLine("CREATE TABLE [dbo].[{0}](", type.Name);
                foreach (var property in type.PropertyInfos)
                {
                    builder.AppendFormatLine("[{0}] {1} {2},", property.Name, ((FieldInfo)property).Db_type
                        , property.Nullabe == true ? "" : "NOT NULL");
                }
                builder.AppendFormatLine(
@" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO", type.Name);
            }

            //生成DDLconfig语句
            foreach (var type in this.Types)
            {
                foreach (var property in type.PropertyInfos)
                {
                    foreach (var attr in property.Attributes)
                    {
                        if (attr.Name.Equals("ddlconfig", StringComparison.InvariantCultureIgnoreCase))
                        {
                            List<string> values = new List<string>();

                            foreach(var attr2 in property.Attributes)
                            {
                                if (attr2.Name.Equals("choices", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    values.AddRange(attr2.Parameters);
                                }
                            }                            
                            
                            if (attr.Parameters.Count > 2)
                            {
                                values.AddRange(attr.Parameters.Skip(2).Take(attr.Parameters.Count - 2));
                            }

                            var func = attr.Parameters[0];
                            var category = attr.Parameters[1];
                            
                            if (attr.Parameters.Count > 0)
                            {
                                builder.AppendFormatLine("DELETE FROM [dbo].[System_Business_Config] WHERE Func='{0}' AND Category = '{1}';",func,category);

                                for(var index = 0 ; index < values.Count ; index ++ )
                                {
                                    builder.AppendFormatLine(
                                        "INSERT INTO [dbo].[System_Business_Config] ([Id],[Func],[Category],[Owner],[Data],[SeqOrder]) VALUES(newid(),'{0}','{1}','{2}','{3}',{4});"
                                        , func, category, GlobalService.UserId, values[index], index);
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
