using CSharpFunctionalExtensions;
using PlutoRover.Api.Models;

namespace PlutoRover.Api.Services
{
    public interface IValidatorService
    {
        public Result Validate(PositionModel positionModel);
    }
}