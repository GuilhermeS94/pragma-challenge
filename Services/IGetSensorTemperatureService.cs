using System;
using System.Threading.Tasks;
using DotNetCodeChallenge.Models;

namespace DotNetCodeChallenge.Services
{
    public interface IGetSensorTemperatureService
    {
        Task<Sensor> Execute(string beerId);
    }
}
