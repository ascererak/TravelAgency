using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Services;

namespace TravelAgency.WebApi.Controllers
{
    [Route("api/subscriber")]
    [ApiController]
    public class SubscriberApiController : Controller
    {
        private readonly ISubscriberService subscriberService;

        public SubscriberApiController(ISubscriberService subscriberService)
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
