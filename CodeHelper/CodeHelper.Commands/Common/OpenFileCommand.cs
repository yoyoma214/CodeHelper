using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.DataModel
{
    public class OpenFileCommand : BaseCommand
    {
        public string File{get;set;}

        public override string Name
        {
            get
            {
                return Dict.Commands.OpenFile;
            }
        }

        IReceiver Receiver = null;

        public OpenFileCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenFile(this.File);
        }
    }
}
