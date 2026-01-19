using System;
using ArcadeService.BL.Interfaces;
using ArcadeService.BL.Services;
using ArcadeService.DL.Interfaces;
using ArcadeService.Models.Dto;
using Moq;
using Xunit;

namespace ArcadeService.Tests.CarTests
{
    public class SellCarTests
    {
        private Mock<IArcadeMachineCrudService> _arcadeMachineCrudServiceMock;
        private Mock<ICustomerRepository> _customerRepositoryMock;

        [Fact]
        public void Sell_Returns_Ok()
        {
            // arrange
            _arcadeMachineCrudServiceMock = new Mock<IArcadeMachineCrudService>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            var expectedPrice = 24000m;

            _arcadeMachineCrudServiceMock
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new ArcadeMachine
                {
                    Id = Guid.NewGuid(),
                    Model = "Pac-Man",
                    Year = 1985,
                    BasePrice = 25000m
                });

            _customerRepositoryMock
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new Customer
                {
                    Id = Guid.NewGuid(),
                    Email = "xxx@xxx.com",
                    Discount = 1000,
                    Name = "John Doe"
                });

            var sellService = new SellArcadeMachine(
                _arcadeMachineCrudServiceMock.Object,
                _customerRepositoryMock.Object);

            // act
            var result = sellService.Sell(Guid.NewGuid(), Guid.NewGuid());

            // assert
            Assert.NotNull(result);
            Assert.Equal(expectedPrice, result.Price);
        }

        [Fact]
        public void Sell_When_Customer_Missing_Should_Throw()
        {
            // arrange
            _arcadeMachineCrudServiceMock = new Mock<IArcadeMachineCrudService>();
            _customerRepositoryMock = new Mock<ICustomerRepository>();

            _arcadeMachineCrudServiceMock
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new ArcadeMachine
                {
                    Id = Guid.NewGuid(),
                    Model = "Pac-Man",
                    Year = 1985,
                    BasePrice = 25000m
                });

            _customerRepositoryMock
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns((Customer)null!);

            var sellService = new SellArcadeMachine(
                _arcadeMachineCrudServiceMock.Object,
                _customerRepositoryMock.Object);

            // act + assert
            Assert.Throws<ArgumentException>(() =>
                sellService.Sell(Guid.NewGuid(), Guid.NewGuid()));
        }
    }
}
