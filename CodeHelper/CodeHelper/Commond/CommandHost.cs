using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Commond
{
    class CommandHost
    {
        Dictionary<string, BaseCommand> Commands = new Dictionary<string, BaseCommand>();

        public void AddCommand(BaseCommand command)
        {
            this.Commands.Add(command.Name , command);
        }

        public void RunCommand(string commandName)
        {
            if (Commands.ContainsKey(commandName))
            {
                Commands[commandName].Execute();
            }
        }
    }
}
