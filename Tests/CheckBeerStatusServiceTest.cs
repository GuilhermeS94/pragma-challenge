using System;
using System.Threading.Tasks;
using DotNetCodeChallenge.Constants;
using DotNetCodeChallenge.Models;
using DotNetCodeChallenge.Services;
using Moq;
using Xunit;

namespace DotNetCodeChallenge.Tests
{
    public class CheckBeerStatusServiceTest
    {
        ICheckBeerStatusService _service;
        Mock<ICheckBeerStatusService> _serviceMock;
        Beer _beer;
        public CheckBeerStatusServiceTest()
        {
            _serviceMock = new Mock<ICheckBeerStatusService>();
            _beer = new Beer();
        }

        [Fact]
        public void ShouldReturnOneTemperatureByBeerId()
        {
            _serviceMock
            .Setup(item => item.Execute("1"))
            .Returns(Task.FromResult<Beer>(new Beer { Id = "1", Temperature = -7, TemperatureStatus = BeerTemperatureStatus.TOO_LOW }));
            _service = _serviceMock.Object;
            Beer beer = _service.Execute("1").Result;
            Assert.False(string.IsNullOrEmpty(beer.TemperatureStatus));
        }

        [Fact]
        public void ShouldReturnTooLowStatusTemperature()
        {
            _beer = new Beer
            {
                Id = "1",
                MaximumTemperature = -1,
                MinimumTemperature = -5,
                Temperature = -7
            };
            _beer.UpdateTemperatureStatus();

            _serviceMock
            .Setup(item => item.Execute("1"))
            .Returns(Task.FromResult<Beer>(_beer));
            _service = _serviceMock.Object;
            Beer beer = _service.Execute("1").Result;
            Assert.True(beer.TemperatureStatus.Equals(BeerTemperatureStatus.TOO_LOW));
        }

        [Fact]
        public void ShouldReturnTooHighStatusTemperature()
        {
            _beer = new Beer
            {
                Id = "1",
                MaximumTemperature = -1,
                MinimumTemperature = -5,
                Temperature = 0
            };
            _beer.UpdateTemperatureStatus();

            _serviceMock
            .Setup(item => item.Execute("1"))
            .Returns(Task.FromResult<Beer>(_beer));
            _service = _serviceMock.Object;
            Beer beer = _service.Execute("1").Result;
            Assert.True(beer.TemperatureStatus.Equals(BeerTemperatureStatus.TOO_HIGH));
        }

        [Fact]
        public void ShouldReturnAllGoodStatusTemperature()
        {
            _beer = new Beer
            {
                Id = "1",
                MaximumTemperature = -1,
                MinimumTemperature = -5,
                Temperature = -3
            };
            _beer.UpdateTemperatureStatus();

            _serviceMock
            .Setup(item => item.Execute("1"))
            .Returns(Task.FromResult<Beer>(_beer));
            _service = _serviceMock.Object;
            Beer beer = _service.Execute("1").Result;
            Assert.True(beer.TemperatureStatus.Equals(BeerTemperatureStatus.ALL_GOOD));
        }
    }
}
