using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.DataModel
{
    public class RenameModelCommand : BaseCommand
    {
        public string OldName { get; set; }

        public string NewName { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.RenameModel;
            }
        }

        IReceiver Receiver = null;

        public RenameModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.RenameFile(this.OldName, this.NewName);
        }
    }
}
