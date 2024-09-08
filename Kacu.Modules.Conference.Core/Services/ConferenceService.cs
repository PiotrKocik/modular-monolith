using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Modules.Conference.Core.DTO;
using Kacu.Modules.Conference.Core.Events;
using Kacu.Shared.Abstraction.Events;

namespace Kacu.Modules.Conference.Core.Services
{
    internal class ConferenceService : IConferenceService
    {
        private readonly IEventDispatcher _dispatcher;

        public ConferenceService(IEventDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public async Task AddAsync(ConferenceDTO conference)
        {
            var conferenceToPublish = new ConferenceCreated(Guid.NewGuid());
            await _dispatcher.PublishAsync(conferenceToPublish);
        }
    }
}
