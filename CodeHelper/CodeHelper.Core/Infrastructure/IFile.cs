using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Infrastructure
{
    public interface IFile
    {
        string FileName { get; }

        string Extension { get; set; }

        string FullName { get; set; }

        void Open();

        void Close();
    }
}
