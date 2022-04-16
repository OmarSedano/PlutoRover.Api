using CSharpFunctionalExtensions;
using PlutoRover.Api.Models;

namespace PlutoRover.Api.Services
{
    //TODO: Add unit testing
    public class ValidatorService : IValidatorService
    {
        private List<char> _allowedCommandLetters = new List<char>() { 'R', 'L', 'F', 'B' };

        public Result Validate(PositionModel positionModel)
        {
            if (positionModel == null)
            {
                return Result.Failure("Position Model can not be null or empty");
            }

            if (string.IsNullOrWhiteSpace(positionModel.Commands))
            {
                return Result.Failure("Commands can not be null or empty");
            }

            var commandsArray = positionModel.Commands.Trim().ToCharArray();
            if (commandsArray.Any(x => !_allowedCommandLetters.Contains(x)))
            {
                return Result.Failure("Invalid commands. One or more command are invalid");
            }

            return Result.Success();
        }
    }
}
