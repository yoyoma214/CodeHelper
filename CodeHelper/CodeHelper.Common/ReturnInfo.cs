using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Common
{
    public class ReturnInfo
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    public class ReturnInfo<T>:ReturnInfo
    {
        public T Data { get; set; }
    }

    public class PageOfReturnInfo<T> : ReturnInfo
    {
        public List<T> Data { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int RecordCount { get; set; }
        public int PageCount
        {
            get
            {
                if (this.PageSize < 1)
                    return -1;

                return (int)Math.Ceiling(this.RecordCount * 1.0 / this.PageSize);
            }
        }
    }
}
