using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.Interfaces.DatabaseAccess.Repositories
{
    public interface ISubscriberRepository
    {
        Task<SubscriberData> AddAsycn(string subscriberData);

        Task<IReadOnlyCollection<SubscriberData>> GetAsync();
    }
}
