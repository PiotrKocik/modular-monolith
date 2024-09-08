using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Messaging;

namespace Kacu.Shared.Infrastructure.Messaging.Dispatchers
{
    public interface IMessageChannel
    {
        ChannelReader<IMessage> Reader { get; }
        ChannelWriter<IMessage> Writer { get; }
    }
}
