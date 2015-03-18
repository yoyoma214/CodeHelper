using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands.DataModel
{
    public class PropertySelectCommand : BaseCommand
    {
        public Object SelectedObj{get;set;}

        public override string Name
        {
            get
            {
                return Dict.Commands.PropertySelect;
            }
        }
        //IReceiver Receiver = null;

        public PropertySelectCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.PropertySelect(SelectedObj);
        }
    }
}
