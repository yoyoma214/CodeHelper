using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Command
{
    public class BaseCommand
    {


        public BaseCommand()
        {
        }

        public BaseCommand(string name)
        {
            this.Name = name;
        }

        protected IReceiver Receiver = null;

        public BaseCommand(string name,IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public BaseCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public virtual string Name { get; private set; }

        public virtual void Execute()
        { }
    }
}
