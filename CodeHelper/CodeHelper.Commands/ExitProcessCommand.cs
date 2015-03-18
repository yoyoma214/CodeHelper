using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands
{
    public class ExitProcessCommand : BaseCommand
    {
        
        public override string Name
        {
            get
            {
                return Dict.Commands.ExitProcess;
            }
        }

        public ExitProcessCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.ExitProcess();
        }
    }
}
