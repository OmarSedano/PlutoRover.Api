
using CSharpFunctionalExtensions;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PlutoRover.Domain.Models;
using PlutoRover.Domain.Services;

namespace PlutoCover.Domain.Tests.UnitTests
{
    public class TestsForPositionService
    {
        [SetUp]
        public void SetUp()
        {
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
            var validatorServiceMock = new Mock<IValidatorService>();
            validatorServiceMock.Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(Result.Success());

            var sut = new PositionService(validatorServiceMock.Object);

            var rover = new Rover(xInitial, yInitial, orientationInitial);

            //Act
            var result = sut.SetPosition(commands, rover);

            //Assert
            result.Should().Be(Result.Success());
            rover.Position.X.Should().Be(xFinal);
            rover.Position.Y.Should().Be(yFinal);
            rover.Position.Orientation.Should().Be(orientationFinal);
        }

        [Test]
        public void Should_ReturnFailedResult_WhenInvalidCommands()
        {
            //Arrange
            var validatorServiceMock = new Mock<IValidatorService>();
            validatorServiceMock.Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(Result.Failure("error"));

            var rover = new Rover();
            var commands = "ALEI";

            var sut = new PositionService(validatorServiceMock.Object);

            //Act
            var result = sut.SetPosition(commands, rover);

            //Assert
            result.Should().Be(Result.Failure("error"));
        }
    }
}
