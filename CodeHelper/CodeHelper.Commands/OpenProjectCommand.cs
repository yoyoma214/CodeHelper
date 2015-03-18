using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Command;
using CodeHelper.Core.Services;

namespace CodeHelper.Commands
{
    public class OpenProjectCommand : BaseCommand
    {
        public string Path { get; set; }

        public override string Name
        {
            get
            {
                return Dict.Commands.OpenProject;
            }
        }

        public OpenProjectCommand(IReceiver reciver)
        {
            this.Receiver = reciver;
        }

        public override void Execute()
        {
            this.Receiver.OpenProject(this.Path);
        }
    }
}
