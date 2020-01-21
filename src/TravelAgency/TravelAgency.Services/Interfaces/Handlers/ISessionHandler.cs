using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Services.Interfaces.Handlers
{
    internal interface ISessionHandler
    {
       Task<RegisteredUserData> GetUserAsync(string token);
    }
}