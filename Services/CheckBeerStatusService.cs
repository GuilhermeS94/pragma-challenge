using System;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCodeChallenge.Constants;
using DotNetCodeChallenge.Models;
using DotNetCodeChallenge.Repo;
using Newtonsoft.Json;

namespace DotNetCodeChallenge.Services
{
    public class CheckBeerStatusService : ICheckBeerStatusService
    {
        private IGetSensorTemperatureService _sensorService;
        private BeersRepo repo;
        public CheckBeerStatusService(IGetSensorTemperatureService sensorService)
        {
            _sensorService = sensorService;
            repo = new BeersRepo();
        }

        public async Task<Beer> Execute(string beerId)
        {
            Beer beer = repo.GetById(beerId);
            Sensor sensor = await _sensorService.Execute(beerId);

            beer.Temperature = sensor.Temperature;
            beer.UpdateTemperatureStatus();

            return beer;
        }
    }
}
