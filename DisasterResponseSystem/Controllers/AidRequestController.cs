using DisasterResponseSystem.Core;
using DisasterResponseSystem.Models;
using DisasterResponseSystem.PostModels;
using DisasterResponseSystem.ResponseModels;
using DisasterResponseSystem.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace DisasterResponseSystem.Controllers
{
    public class AidRequestController : ControllerBase
    {
        private  ILogicService _logicService { get; set; }

        public AidRequestController(ILogicService logicService)
        {
            _logicService = logicService;
        }

        [HttpPost]
        [Route("v1/AidRequest")]
        [SwaggerResponse(StatusCodes.Status200OK, "Id of created record", typeof(long))]
        public ActionResult AidRequest([FromBody] AidRequestPost post)
        {
            var result = _logicService.CreateAidRequest(post);
            return new OkObjectResult(result);
        }

        [HttpGet]
        [Route("v1/AidRequests")]
        [SwaggerResponse(StatusCodes.Status200OK, "List of  Aie requests", typeof(ListResponse<AidRequestResponse>))]
        public ActionResult Index(RankEnum? Rank = null, StatusEnum? Status= null, int Skip = 0,int Length = 10)
        {
            var result = _logicService.GetAllAidRequests((int?)Rank, (int?)Status, Length, Skip, out int total);
            return new OkObjectResult(new ListResponse<AidRequestResponse>
            {
                Result = result,
                Total = total
            });
        }

        [HttpPost]
        [Route("v1/AidRequest/{Id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Edit Aid request by Orgenizatin", typeof(long))]

        public ActionResult EditAidRequest(long Id,[FromBody] EditAidRequestPost post)
        {
            var result = _logicService.EditAidRequest(Id, post);
            if (result == 0)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        [HttpPost]
        [Route("v1/AidRequest/Process/{Id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "start processing Aid request by Orgenizatin", typeof(long))]

        public ActionResult ProcessAidRequest(long Id, [FromBody] ProcessAidRequestPost post)
        {
            var result = _logicService.ProcessAidRequest(Id, post);
            return new OkObjectResult(result);
        }
    }
}
