using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Kacu.Shared.Infrastructure.Modules
{
    public sealed class ModuleRegistration
    {
        public Type ReceiverType { get; set; }
        public Func<object, Task> Action { get; set; }

        public string Key => ReceiverType.Name;
    }
}
