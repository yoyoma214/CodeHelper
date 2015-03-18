using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Commond
{
    class BaseCommand
    {
        public const string OpenDataModel = "OpenDataModel";

        public BaseCommand()
        {
        }

        public BaseCommand(string name)
        {
            this.Name = name;
        }

        public virtual string Name { get; private set; }

        public virtual void Execute()
        { }
    }
}
