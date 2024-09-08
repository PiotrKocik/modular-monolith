using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Modules;

namespace Kacu.Shared.Infrastructure.Modules
{
    public class ModuleClient : IModuleClient
    {
        private readonly IModuleSerializer _moduleSerializer;
        private readonly IModuleRegistry _moduleRegistry;

        public ModuleClient(IModuleSerializer moduleSerializer, IModuleRegistry moduleRegistry)
        {
            _moduleSerializer = moduleSerializer;
            _moduleRegistry = moduleRegistry;
        }

        public async Task PublishAsync(object message)
        {
            var key = message.GetType().Name;
            var registrations = _moduleRegistry.GetRegistrations(key)
                .Where(x=> x.ReceiverType != message.GetType());

            var tasks = new List<Task>();
            foreach (var registration in registrations)
            {
                var action = registration.Action;
                var messageToPublish = TranslateType(message, registration.ReceiverType);
                tasks.Add(action(messageToPublish));
            }

            await Task.WhenAll(tasks);
        }

        private object TranslateType(object message, Type type)
        {
            return _moduleSerializer.Deserialize(_moduleSerializer.Serialize(message), type)
        }
    }
}
