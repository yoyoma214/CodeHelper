using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types;

namespace CodeHelper.Core.Parse.ParseResults
{
    public interface IPropertyInfo:IWiseble//, IToken
    {
        String Name { get; set; }

        string Type { get; set; }

        List<AttributeInfo> Attributes { get; set; }

        //string FullTypeName { get; set; }

        ITypeInfo TypeInfo { get; set; }
        //bool IsXmlNode { get; set; }

        //void Wise();
        TokenPair TokenPair { get; set; }

        bool Nullabe { get; set; }

        void Init();
    }
}
