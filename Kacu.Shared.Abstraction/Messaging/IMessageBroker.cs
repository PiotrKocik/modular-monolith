using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kacu.Shared.Abstraction.Messaging
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IMessage[] messages);
    }
}
