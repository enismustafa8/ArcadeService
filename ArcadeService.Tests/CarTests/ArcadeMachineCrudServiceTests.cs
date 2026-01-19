using System;
using System.Linq;
using ArcadeService.BL.Services;
using ArcadeService.DL.Interfaces;
using ArcadeService.Models.Dto;
using ArcadeService.Tests.MockData;
using Moq;
using Xunit;

namespace ArcadeService.Tests.CarTests
{
    public class ArcadeMachineCrudServiceTests
    {
        private readonly Mock<IArcadeMachineRepository> _arcadeMachineRepositoryMock;

        public ArcadeMachineCrudServiceTests()
        {
            _arcadeMachineRepositoryMock = new Mock<IArcadeMachineRepository>();
        }

        [Fact]
        public void AddArcadeMachine_Ok()
        {
            // arrange
            var expectedCount = ArcadeMachineMockedData.ArcadeMachines.Count + 1;
            var id = Guid.NewGuid();

            var arcadeMachine = new ArcadeMachine
            {
                Id = id,
                Model = "Pac-Man",
                Year = 1985,
                BasePrice = 2500
            };

            _arcadeMachineRepositoryMock
                .Setup(r => r.Add(It.IsAny<ArcadeMachine>()))
                .Callback<ArcadeMachine>(a =>
                {
                    ArcadeMachineMockedData.ArcadeMachines.Add(a);
                });

            var service = new ArcadeMachineCrudService(
                _arcadeMachineRepositoryMock.Object);

            // act
            service.Add(arcadeMachine);

            var result = ArcadeMachineMockedData.ArcadeMachines
                .FirstOrDefault(a => a.Id == id);

            // assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, ArcadeMachineMockedData.ArcadeMachines.Count);
            Assert.Equal(id, result!.Id);
        }
    }
}
