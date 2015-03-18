using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.DataModel
{
    public class DeleteModelCommand : BaseCommand
    {        

        public string FileName { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.DeleteModel;
            }
        }

        IReceiver Receiver = null;

        public DeleteModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.DeleteFile(FileName);
        }
    }
}
