using Kacu.Shared.Abstraction.Events;

namespace Kacu.Modules.Conference.Core.Events
{
    public record ConferenceCreated(Guid Id) : IEvent;
}
