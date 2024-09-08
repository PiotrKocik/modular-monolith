using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Messaging;
using Kacu.Shared.Abstraction.Modules;
using Kacu.Shared.Infrastructure.Messaging.Dispatchers;

namespace Kacu.Shared.Infrastructure.Messaging
{
    internal class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly MessagingOptions _messagingOptions;
        private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
        
        public MessageBroker(IModuleClient moduleClient, MessagingOptions messagingOptions, IAsyncMessageDispatcher asyncMessageDispatcher)
        {
            _moduleClient = moduleClient;
            _messagingOptions = messagingOptions;
            _asyncMessageDispatcher = asyncMessageDispatcher;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages == null) return;
            messages = messages.Where(x => x != null).ToArray();

            if(messages.Length == 0) return;

            var tasks = new List<Task>();

            foreach (var message in messages)
            {
                if (_messagingOptions.UseBackgroundDispatcher)
                {
                    await _asyncMessageDispatcher.PublishAsync(message);
                    continue;
                }
                tasks.Add(_moduleClient.PublishAsync(message));
            }

            await Task.WhenAll(tasks);
        }
    }
}
