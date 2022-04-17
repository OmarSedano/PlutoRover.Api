using Microsoft.AspNetCore.Mvc;
using PlutoRover.Domain.Models;
using PlutoRover.Domain.Services;

namespace PlutoRover.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
        }

        [HttpPost]
        public ActionResult Post(PositionModel positionModel)
        {
            //Generate an existing rover to work with
            var rover = new Rover();

            var result = _positionService.SetPosition(positionModel?.Commands, rover);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok();
        }
    }
}