namespace PlutoRover.Domain.Models
{
    public class Rover : IRover
    {
        public IPosition Position { get; private set; }

        public Rover()
        {
            Position = new Position();
        }

        public Rover(uint x, uint y, char orientation)
        {
            Position = new Position(x, y, orientation);
        }

    }

    public class Position : IPosition
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }
        public char Orientation { get; private set; }

        private const char North = 'N';
        private const char East = 'E';
        private const char South = 'S';
        private const char West = 'W';

        public Position()
        {
            X = 0;
            Y = 0;
            Orientation = North;
        }

        public Position(uint x, uint y, char orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public void SetPosition(char command)
        {
            switch (command)
            {
                case 'R':
                    TurnRight();
                    break;
                case 'L':
                    TurnLeft();
                    break;
                case 'F':
                    MoveForward();
                    break;
                case 'B':
                    MoveBackward();
                    break;
            }
        }

        private void TurnLeft()
        {
            switch (Orientation)
            {
                case North:
                    Orientation = West;
                    break;
                case East:
                    Orientation = North;
                    break;
                case South:
                    Orientation = East;
                    break;
                case West:
                    Orientation = South;
                    break;
            }
        }

        private void TurnRight()
        {
            switch (Orientation)
            {
                case North:
                    Orientation = East;
                    break;
                case East:
                    Orientation = South;
                    break;
                case South:
                    Orientation = West;
                    break;
                case West:
                    Orientation = North;
                    break;
            }
        }

        private void MoveForward()
        {
            switch (Orientation)
            {
                case North:
                    Y += 1;
                    break;
                case East:
                    X += 1;
                    break;
                case South:
                    Y = Y > 0 ? Y - 1 : 0;
                    break;
                case West:
                    X = X > 0 ? X - 1 : 0;
                    break;
            }
        }

        private void MoveBackward()
        {
            switch (Orientation)
            {
                case North:
                    Y = Y > 0 ? Y - 1 : 0;
                    break;
                case East:
                    X = X > 0 ? X - 1 : 0;
                    break;
                case South:
                    Y += 1;
                    break;
                case West:
                    X += 1;
                    break;
            }
        }
    }
}
