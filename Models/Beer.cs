using DotNetCodeChallenge.Constants;

namespace DotNetCodeChallenge.Models
{
    public class Beer
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int MinimumTemperature { get; set; }

        public int MaximumTemperature { get; set; }

        public int Temperature  { get; set; }

        public string TemperatureStatus  { get; set; }

        public void UpdateTemperatureStatus()
        {
            if (this.Temperature < this.MinimumTemperature)
            {
                this.TemperatureStatus = BeerTemperatureStatus.TOO_LOW;
            }

            if (this.Temperature > this.MaximumTemperature)
            {
                this.TemperatureStatus = BeerTemperatureStatus.TOO_HIGH;
            }

            if (this.Temperature >= this.MinimumTemperature && this.Temperature <= this.MaximumTemperature)
            {
                this.TemperatureStatus = BeerTemperatureStatus.ALL_GOOD;
            }
        }
    }
}