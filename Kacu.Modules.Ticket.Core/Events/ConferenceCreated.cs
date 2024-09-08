using Kacu.Shared.Abstraction.Events;

namespace Kacu.Modules.Ticket.Core.Events
{
    public record ConferenceCreated(Guid Id) : IEvent;
}
