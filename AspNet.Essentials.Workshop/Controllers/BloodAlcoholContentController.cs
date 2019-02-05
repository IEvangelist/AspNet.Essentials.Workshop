using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/bac"), ApiController]
    public class BloodAlcoholContentController : ControllerBase
    {
        [HttpPost("calculate")]
        public ActionResult Calculate(
            [FromBody] BacCalculationRequest request,
            [FromServices] IBloodAlcoholCalculator calculator)
            => new JsonResult(new
               {
                   BloodAlcoholContent =
                       calculator.Calculate(
                           request.WeightInPounds,
                           request.HoursOfDrinking,
                           request.Sex,
                           request.Beers)
               });
    }
}