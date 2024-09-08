using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kacu.Shared.Infrastructure.Modules
{
    public interface IModuleRegistry
    {
        IEnumerable<ModuleRegistration> GetRegistrations(string key);
        void AddRegistry(Type receiverType, Func<object, Task> action);
    }
}
