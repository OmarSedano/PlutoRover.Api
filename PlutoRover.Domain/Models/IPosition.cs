namespace PlutoRover.Domain.Models
{
    public interface IPosition
    {
        char Orientation { get; }
        uint X { get; }
        uint Y { get; }
        void SetPosition(char command);
    }
}