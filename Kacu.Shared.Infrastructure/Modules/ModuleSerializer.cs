using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kacu.Shared.Infrastructure.Modules
{
    internal class ModuleSerializer : IModuleSerializer
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public byte[] Serialize<T>(T value)
        {
            return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, jsonSerializerOptions));
        }

        public object Deserialize(byte[] value, Type type)
        {
            return JsonSerializer.Deserialize(Encoding.UTF8.GetString(value), type, jsonSerializerOptions);
        }
    }
}
