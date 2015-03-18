using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;

namespace CodeHelper.Core.Command
{
    public class CommandHostManager
    {
        public enum HostType
        {
            Common,XmlMode,DataModel,DataView,ViewModel,WorkFlow
        }

        Dictionary<HostType, CommandHost> commandHosts = new Dictionary<HostType, CommandHost>();

        private CommandHostManager()
        {

        }

        private static CommandHostManager _instance = null;

        public static CommandHostManager Instance()
        {
            if (_instance == null)
            {
                _instance = new CommandHostManager();
                _instance.Add(HostType.Common, new CommandHost());
                _instance.Add(HostType.XmlMode, new CommandHost());
                _instance.Add(HostType.DataModel, new CommandHost());
                _instance.Add(HostType.DataView, new CommandHost());
                _instance.Add(HostType.ViewModel, new CommandHost());
                _instance.Add(HostType.WorkFlow, new CommandHost());
            }
            return _instance;
        }

        public void Run(HostType type, string commandName)
        {
            var host = this.Get(type);
            host.RunCommand(commandName);
        }
        

        public BaseCommand Get(HostType type, string commandName)
        {
            var host = this.Get(type);
            return host.GetCommand(commandName);
        }

        public T Get<T>(HostType type, string commandName) where T: BaseCommand
        {
            var host = this.Get(type);
            return (T)host.GetCommand(commandName);
        }

        private void Add(HostType hashCode, CommandHost commandHost)
        {
            this.commandHosts.Add(hashCode, commandHost);
        }

        public void AddCommand(HostType hashCode, BaseCommand command)
        {
            if (this.commandHosts.ContainsKey(hashCode))
            {
                this.commandHosts[hashCode].AddCommand(command);
            }
        }

        public void Remove(HostType hashCode)
        {
            if (this.commandHosts.ContainsKey(hashCode))
            {
                this.commandHosts.Remove(hashCode);
            }
        }

        public CommandHost Get(HostType hashCode)
        {
            if (this.commandHosts.ContainsKey(hashCode))
            {
                return this.commandHosts[hashCode];
            }

            return null;
        }

     
    }
}
