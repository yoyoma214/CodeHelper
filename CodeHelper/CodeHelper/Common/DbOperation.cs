using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.Common
{
    #region 操作类型枚举

    public enum CompareOprType
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual
    }

    public enum LikeOprType
    {
        Like,
        NotLike
    }

    public enum InOprType
    {
        In,
        NotIn
    }

    #endregion

    class DbOperation
    {
    }
}
