using DisasterResponseSystem.Core;
using DisasterResponseSystem.PostModels;
using DisasterResponseSystem.ResponseModels;
using DisasterResponseSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DisasterResponseSystem.Controllers
{
    public class DonerController : ControllerBase
    {
        private ILogicService _logicService { get; set; }

        public DonerController(ILogicService logicService)
        {
            _logicService = logicService;
        }

        [HttpPost]
        [Route("v1/Donait")]
        [SwaggerResponse(StatusCodes.Status200OK, "Donate", typeof(long))]

        public ActionResult DonaitRequest([FromBody] DonaitPost post)
        {
            var result = _logicService.CreateDonation(post);
            return new OkObjectResult(result);
        }
    }
}
