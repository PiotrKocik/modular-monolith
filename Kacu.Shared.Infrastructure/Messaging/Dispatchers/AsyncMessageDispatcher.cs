using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Messaging;

namespace Kacu.Shared.Infrastructure.Messaging.Dispatchers
{
    public class AsyncMessageDispatcher : IAsyncMessageDispatcher
    {
        private readonly IMessageChannel _channel;

        public AsyncMessageDispatcher(IMessageChannel channel)
        {
            _channel = channel;
        }

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage
        => await _channel.Writer.WriteAsync(message);
    }
}
