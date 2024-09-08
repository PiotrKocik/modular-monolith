using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Modules;
using Microsoft.Extensions.Hosting;

namespace Kacu.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class BackgroundDispatcher : BackgroundService
    {
        private readonly IMessageChannel _channel;
        private readonly IModuleClient _moduleClient;

        public BackgroundDispatcher(IMessageChannel channel, IModuleClient moduleClient)
        {
            _channel = channel;
            _moduleClient = moduleClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var message in _channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}
