using System.Threading.Tasks;

namespace TravelAgency.Interfaces.Services
{
    public interface ISubscriberService
    {
        Task AddAsync(string subscriberEmail);

        Task SendEmailAsync();
    }
}
