using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Infrastructure.Command
{
    public interface IReceiverHolder
    {
        ReceiverBase Receiver { get; }
    }
}
