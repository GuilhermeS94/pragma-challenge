using System;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCodeChallenge.Models;
using Newtonsoft.Json;

namespace DotNetCodeChallenge.Services
{
    public class GetSensorTemperatureService : IGetSensorTemperatureService
    {
        private const string BASE_URL = "https://temperature-sensor-service.herokuapp.com/sensor/{0}";

        public async Task<Sensor> Execute(string beerId)
        {
            Sensor sensor;
            HttpClient request = new HttpClient();
            HttpResponseMessage response = await request.GetAsync(string.Format(BASE_URL, beerId)).ConfigureAwait(false);

            sensor = JsonConvert.DeserializeObject<Sensor>(await response.Content.ReadAsStringAsync());
            return sensor;
        }
    }
}
