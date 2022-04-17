using CSharpFunctionalExtensions;
using PlutoRover.Domain.Models;

namespace PlutoRover.Domain.Services
{
    public interface IValidatorService
    {
        public Result Validate(string commands);
    }
}