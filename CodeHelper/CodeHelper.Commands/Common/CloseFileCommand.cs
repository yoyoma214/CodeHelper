using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.DataModel
{
    public class CloseFileCommand : BaseCommand
    {
        public Guid FileId{get;set;}

        public override string Name
        {
            get
            {
                return Dict.Commands.CloseFile;
            }
        }

        IReceiver Receiver = null;

        public CloseFileCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.CloseFile(this.FileId);
        }
    }
}
