using System.Threading.Tasks;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Services.Interfaces;
using TravelAgency.Services.Interfaces.Handlers;

namespace TravelAgency.Services.Handlers
{
    internal class SessionHandler : ISessionHandler
    {
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly ISessionRepository sessionRepository;
        private readonly IRegisteredUserRepository registeredUserRepository;

        public SessionHandler(
            IApplicationUserRepository applicationUserRepository,
            ISessionRepository sessionRepository,
            IRegisteredUserRepository registeredUserRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
            this.sessionRepository = sessionRepository;
            this.registeredUserRepository = registeredUserRepository;
        }

        public async Task<RegisteredUserData> GetUserAsync(string token)
        {
            SessionData session = await sessionRepository.GetByTokenAsync(token);
            if (session == null)
            {
                return null;
            }

            UserData user = await applicationUserRepository.FindByIdAsync(session.UserId);
            if (user == null)
            {
                return null;
            }

            return registeredUserRepository.FindByUser(user);
        }
    }
}