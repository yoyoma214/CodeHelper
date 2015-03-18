using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;
using CodeHelper.Core.Parse;

namespace CodeHelper.Core.Types
{
    public interface ITypeInfo : IWiseble, IToken
    {
        string Name { get; set; }

        string FullName { get; set; }

        Guid? FileId { get; set; }

        List<ITypeInfo> TypeInfos { get; set; }

        List<IPropertyInfo> PropertyInfos { get; set; }

        void Init();

        //void Wise();

        bool IsPrimitive { get; set; }

        bool IsGenericType { get; set; }

        bool IsGenericTypeDefinition{get;set;}

        ITypeInfo GenericParameterType { get; set; }

        TokenPair TokenPair { get; set; }
    }
}
