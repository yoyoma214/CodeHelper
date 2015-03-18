using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Commond
{
    class OpenDataModelCommand : BaseCommand
    {
        string File { get; set; }

        public override string Name
        {
            get
            {
                return BaseCommand.OpenDataModel;
            }
        }

        IReceiver Receiver = null;

        public OpenDataModelCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenDataModel(this);
        }
    }
}
