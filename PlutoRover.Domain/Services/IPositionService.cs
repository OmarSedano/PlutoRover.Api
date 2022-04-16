using CSharpFunctionalExtensions;
using PlutoRover.Domain.Models;

namespace PlutoRover.Domain.Services
{
    public interface IPositionService
    {
        Result SetPosition(string commands, IRover rover);
    }
}