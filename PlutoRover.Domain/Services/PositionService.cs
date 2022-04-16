using CSharpFunctionalExtensions;
using PlutoRover.Domain.Models;

namespace PlutoRover.Domain.Services
{
    public class PositionService : IPositionService
    {
        public Result SetPosition(string commands, IRover rover)
        {
            var commandsArray = commands.Trim().ToCharArray();
            foreach (var command in commandsArray)
            {
                rover.Position.SetPosition(command);
            }

            return Result.Success();
        }
    }
}
