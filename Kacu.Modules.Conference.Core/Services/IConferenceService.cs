using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kacu.Modules.Conference.Core.DTO;

namespace Kacu.Modules.Conference.Core.Services
{
    internal interface IConferenceService
    {
        Task AddAsync(ConferenceDTO conference);
    }
}
