using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/subscription")]
    [ApiController]
    public class SubscriptionApiController : Controller
    {
        private readonly ISubscriberService subscriberService;

        public SubscriptionApiController(ISubscriberService subscriberService)
        {
            this.subscriberService = subscriberService;
        }

        [HttpGet]
        [Route("send")]
        public async Task<IActionResult> GetAll()
        {
            await subscriberService.SendEmailAsync();

            return Json("Probably sent ¯\\_(ツ)_/¯ ");
        }
    }
}
