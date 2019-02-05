using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/bac"), ApiController]
    public class BloodAlcoholContentController : ControllerBase
    {
        [HttpPost("post-body")]
        public ActionResult CalculateFromBodyAsModel(
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

        [HttpPost("post-route/{weight:int},{hours:float},{sex}")]
        public ActionResult CalculateFromRoute(
            [FromRoute] int weight,
            [FromRoute] float hours,
            [FromRoute] Sex sex,
            [FromQuery] double[] abvs,
            [FromServices] IBloodAlcoholCalculator calculator)
            => new JsonResult(new
               {
                   BloodAlcoholContent =
                          calculator.Calculate(
                              weight,
                              hours,
                              sex,
                              abvs)
               });
    }
}