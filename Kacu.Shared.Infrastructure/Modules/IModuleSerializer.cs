using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kacu.Shared.Infrastructure.Modules
{
    public interface IModuleSerializer
    {
        byte[] Serialize<T>(T value);
        object Deserialize(byte[] value, Type type);
    }
}
