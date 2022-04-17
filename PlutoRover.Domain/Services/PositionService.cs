using CSharpFunctionalExtensions;
using PlutoRover.Domain.Models;

namespace PlutoRover.Domain.Services
{
    public class PositionService : IPositionService
    {
        private readonly IValidatorService _validatorService;

        public PositionService(IValidatorService validatorService)
        {
            _validatorService = validatorService;
        }

        public Result SetPosition(string commands, IRover rover)
        {
            var isValid = _validatorService.Validate(commands);

            if (isValid.IsFailure)
            {
                return Result.Failure(isValid.Error);
            }

            var commandsArray = commands.Trim().ToCharArray();
            foreach (var command in commandsArray)
            {
                rover.Position.SetPosition(command);
            }

            return Result.Success();
        }
    }
}
