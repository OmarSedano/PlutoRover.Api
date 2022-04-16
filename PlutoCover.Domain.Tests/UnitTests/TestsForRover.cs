using FluentAssertions;
using NUnit.Framework;
using PlutoRover.Domain.Models;

namespace PlutoCover.Domain.Tests.UnitTests
{
    public class TestsForRover
    {
        [Test]
        [TestCase(0u, 0u, 'N', 0u, 0u, 'W')]
        [TestCase(0u, 0u, 'E', 0u, 0u, 'N')]
        [TestCase(0u, 0u, 'S', 0u, 0u, 'E')]
        [TestCase(0u, 0u, 'W', 0u, 0u, 'S')]
        public void Should_TurnLeft_WithLCommand(uint xInitial, uint yInitial, char orientationInitial, uint xFinal, uint yFinal, char orientationFinal)
        {
            //Arrange
            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            rover.Position.SetPosition('L');

            //Assert
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }

        [Test]
        [TestCase(0u, 0u, 'N', 0u, 0u, 'E')]
        [TestCase(0u, 0u, 'E', 0u, 0u, 'S')]
        [TestCase(0u, 0u, 'S', 0u, 0u, 'W')]
        [TestCase(0u, 0u, 'W', 0u, 0u, 'N')]
        public void Should_TurnLeft_WithRCommand(uint xInitial, uint yInitial, char orientationInitial, uint xFinal, uint yFinal, char orientationFinal)
        {
            //Arrange
            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            rover.Position.SetPosition('R');

            //Assert
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }


        [Test]
        [TestCase(0u, 0u, 'N', 0u, 1u, 'N')]
        [TestCase(0u, 0u, 'E', 1u, 0u, 'E')]
        [TestCase(0u, 0u, 'S', 0u, 0u, 'S')]
        [TestCase(0u, 1u, 'S', 0u, 0u, 'S')]
        [TestCase(0u, 0u, 'W', 0u, 0u, 'W')]
        [TestCase(1u, 0u, 'W', 0u, 0u, 'W')]
        public void Should_MoveForward_WithFCommand(uint xInitial, uint yInitial, char orientationInitial, uint xFinal, uint yFinal, char orientationFinal)
        {
            //Arrange
            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            rover.Position.SetPosition('F');

            //Assert
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }

        [Test]
        [TestCase(0u, 0u, 'N', 0u, 0u, 'N')]
        [TestCase(0u, 1u, 'N', 0u, 0u, 'N')]
        [TestCase(0u, 0u, 'E', 0u, 0u, 'E')]
        [TestCase(1u, 0u, 'E', 0u, 0u, 'E')]
        [TestCase(0u, 0u, 'S', 0u, 1u, 'S')]
        [TestCase(0u, 0u, 'W', 1u, 0u, 'W')]
        public void Should_MoveBackward_WithBCommand(uint xInitial, uint yInitial, char orientationInitial, uint xFinal, uint yFinal, char orientationFinal)
        {
            //Arrange
            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            rover.Position.SetPosition('B');

            //Assert
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }
    }
}
