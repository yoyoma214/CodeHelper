using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;
using CodeHelper.Core.Types;
using CodeHelper.Core.Infrastructure.Command;
using Project;

namespace CodeHelper.Core.Infrastructure.Model
{
    public delegate void OnParseError(string file, List<ParseErrorInfo> errors);

    public interface IModelManager : IReceiverHolder
    {
        void Regist(IModel model);
        
        void RegistDb(ConnectionType conn);

        void Remove(IModel model);

        void Remove(Guid fileId);

        IModel GetModel(Guid fileId);

        event OnParseError ParseError;

        List<ITypeInfo> ParseType(string type, IParseModule ctx , out string error);

        IModel MakeSureModel(string file);

        List<ParseErrorInfo> Errors
        {
            get;            
        }

        IParseModule MakeSureParseModule(string p);

        IParseModule GetParseModule(Guid fileId);
    }
}
