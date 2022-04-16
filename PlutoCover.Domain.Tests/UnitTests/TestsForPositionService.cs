
using FluentAssertions;
using NUnit.Framework;
using PlutoRover.Domain.Models;
using PlutoRover.Domain.Services;

namespace PlutoCover.Domain.Tests.UnitTests
{
    public class TestsForPositionService
    {
        private IPositionService _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PositionService();
        }

        [Test]
        [TestCase("F", 0u, 0u, 'N', 0u, 1u, 'N')]
        [TestCase("B", 0u, 0u, 'N', 0u, 0u, 'N')]
        [TestCase("L", 0u, 0u, 'N', 0u, 0u, 'W')]
        [TestCase("R", 0u, 0u, 'N', 0u, 0u, 'E')]
        [TestCase("RFF", 0u, 0u, 'N', 2u, 0u, 'E')]
        [TestCase("FFF", 0u, 0u, 'N', 0u, 3u, 'N')]
        [TestCase("FFRFF", 0u, 0u, 'N', 2u, 2u, 'E')]
        [TestCase("FRFFLB", 0u, 0u, 'N', 2u, 0u, 'N')]
        public void Should_SetPosition(string commands, uint xInitial, uint yInitial, char orientationInitial, uint xFinal, uint yFinal, char orientationFinal)
        {
            //Arrange
            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            _sut.SetPosition(commands, rover);

            //Assert
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }
    }
}
