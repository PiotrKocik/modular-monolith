using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kacu.Shared.Abstraction.Modules
{
    public interface IModuleClient
    {
        Task PublishAsync(object message);
    }
}
