using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface IRegisteredUserRepository
    {
        Task<RegisteredUserData> AddAsync(RegisteredUserData client);

        Task<RegisteredUserData> FindByIdAsync(int id);

        RegisteredUserData FindByUser(UserData userData);
    }
}
