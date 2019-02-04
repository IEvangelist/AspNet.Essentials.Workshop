using AspNet.Essentials.Workshop.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/beers"), ApiController]
    public class BeersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IBreweryClient client)
            => new JsonResult(await client.GetBeersAsync());
    }
}