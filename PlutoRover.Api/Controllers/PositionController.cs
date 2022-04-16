using Microsoft.AspNetCore.Mvc;
using PlutoRover.Api.Models;
using PlutoRover.Api.Services;
using PlutoRover.Domain.Models;
using PlutoRover.Domain.Services;

namespace PlutoRover.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;
        private readonly IValidatorService _validatorService;

        public PositionController(IPositionService positionService, IValidatorService validatorService)
        {
            _positionService = positionService ?? throw new ArgumentNullException(nameof(positionService));
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(validatorService));
        }

        //TODO: Add unit testing

        [HttpPost]
        public ActionResult Post(PositionModel positionModel)
        {
            var validate = _validatorService.Validate(positionModel);
            if (validate.IsFailure)
            {
                return BadRequest(validate.Error);
            }

            //Generate an existing rover to work with
            var rover = new Rover();

            var result = _positionService.SetPosition(positionModel.Commands, rover);
            if (result.IsFailure)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
            }
            return Ok();
        }
    }
}