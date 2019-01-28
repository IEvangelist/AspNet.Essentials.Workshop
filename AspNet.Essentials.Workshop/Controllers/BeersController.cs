using AspNet.Essentials.Workshop.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/beers"), ApiController]
    public class BeersController : ControllerBase
    {
        readonly IBreweryClient _breweryClient;

        public BeersController(IBreweryClient breweryClient) => _breweryClient = breweryClient;

        [HttpGet]
        public async Task<ActionResult> Get()
            => new JsonResult(await _breweryClient.GetBeersAsync());
    }
}