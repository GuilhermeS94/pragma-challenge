using System;
using System.Threading.Tasks;
using DotNetCodeChallenge.Models;
using DotNetCodeChallenge.Services;
using Moq;
using Xunit;

namespace DotNetCodeChallenge.Tests
{
    public class GetSensorTemperatureServiceTest
    {
        IGetSensorTemperatureService _service;
        Mock<IGetSensorTemperatureService> _serviceMock;
        public GetSensorTemperatureServiceTest()
        {
            _serviceMock = new Mock<IGetSensorTemperatureService>();
        }

        [Fact]
        public void ShouldReturnOneTemperatureByBeerId()
        {
            _serviceMock
            .Setup(item => item.Execute("1"))
            .Returns(Task.FromResult<Sensor>(new Sensor { Id = "1", Temperature = -7 }));
            _service = _serviceMock.Object;
            Sensor sensor = _service.Execute("1").Result;
            Assert.NotNull(sensor);
        }
    }
}
