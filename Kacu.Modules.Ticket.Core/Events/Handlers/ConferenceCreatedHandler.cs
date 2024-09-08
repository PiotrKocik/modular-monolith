using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Shared.Abstraction.Events;

namespace Kacu.Modules.Ticket.Core.Events.Handlers
{
    internal class ConferenceCreatedHandler : IEventHandler<ConferenceCreated>
    {
        public Task HandleAsync(ConferenceCreated @event)
        {
            if (@event == null) return Task.CompletedTask;

            //do some stuff
            return Task.CompletedTask;
        }
    }
}
