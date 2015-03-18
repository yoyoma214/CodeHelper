using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Commond
{
    class CommandHostManager
    {
        public enum HostType
        {
            DataModel,ViewModel,WorkFlow
        }

        Dictionary<HostType, CommandHost> commandHosts = new Dictionary<HostType, CommandHost>();

        private CommandHostManager()
        {

        }

        private static CommandHostManager _instance = new CommandHostManager();

        public static CommandHostManager Instance()
        {
            _instance.Add(HostType.DataModel, new CommandHost());
            _instance.Add(HostType.ViewModel, new CommandHost());
            _instance.Add(HostType.WorkFlow, new CommandHost());

            return _instance;
        }

        public void Add(HostType hashCode, CommandHost commandHost)
        {
            this.commandHosts.Add(hashCode, commandHost);
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
