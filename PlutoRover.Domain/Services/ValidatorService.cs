using CSharpFunctionalExtensions;

namespace PlutoRover.Domain.Services
{
    //TODO: Add unit testing
    public class ValidatorService : IValidatorService
    {
        private List<char> _allowedCommandLetters = new List<char>() { 'R', 'L', 'F', 'B' };

        public Result Validate(string commands)
        {
            if (string.IsNullOrWhiteSpace(commands))
            {
                return Result.Failure("Commands can not be null or empty");
            }

            var commandsArray = commands.Trim().ToCharArray();
            if (commandsArray.Any(x => !_allowedCommandLetters.Contains(x)))
            {
                return Result.Failure("Invalid commands. One or more commands are invalid");
            }

            return Result.Success();
        }
    }
}
