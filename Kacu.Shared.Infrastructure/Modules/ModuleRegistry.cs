using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kacu.Shared.Infrastructure.Modules
{
    public class ModuleRegistry : IModuleRegistry
    {
        private readonly List<ModuleRegistration> _modules = new();

        public IEnumerable<ModuleRegistration> GetRegistrations(string key)
            => _modules.Where(x => x.Key == key);

        public void AddRegistry(Type receiverType, Func<object, Task> action)
        {
            if (string.IsNullOrWhiteSpace(receiverType.Namespace)) //dynamic doesn't have namespace
            {
                throw new InvalidOperationException("missing namespace");
            }

            var registration = new ModuleRegistration
            {
                Action = action,
                ReceiverType = receiverType
            };

            _modules.Add(registration);
        }
    }
}
