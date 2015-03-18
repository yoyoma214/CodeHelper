using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Infrastructure.Model;

namespace CodeHelper.Core
{
    public class EditorContext
    {
        public IEditor EditorContainer { get; set; }
        public IModel Model { get; set; }
        public IEditorController Controller { get; set; }
    }
}
