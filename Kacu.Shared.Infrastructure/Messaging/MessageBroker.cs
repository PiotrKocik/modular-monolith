using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Messaging;
using Kacu.Shared.Abstraction.Modules;

namespace Kacu.Shared.Infrastructure.Messaging
{
    internal class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;

        public MessageBroker(IModuleClient moduleClient)
        {
            _moduleClient = moduleClient;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages == null) return;
            messages = messages.Where(x => x != null).ToArray();

            if(messages.Length == 0) return;

            var tasks = new List<Task>();

            foreach (var message in messages)
            {
                tasks.Add(_moduleClient.PublishAsync(message));
            }

            await Task.WhenAll(tasks);
        }
    }
}
