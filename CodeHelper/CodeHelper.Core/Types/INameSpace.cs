using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Types
{
    public interface INameSpace
    {
        string Name { get; set; }

        List<ITypeInfo> TypeInfos { get; set; }
    }
}
