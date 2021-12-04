using System;
using System.Collections.Generic;
using DotNetCodeChallenge.Models;

namespace DotNetCodeChallenge.Repo
{
    public class BeersRepo
    {
        private readonly List<Beer> beers = new()
        {
            new Beer
            {
                Id = "1",
                Name = "Pilsner",
                MinimumTemperature = 4,
                MaximumTemperature = 6,
                Temperature = 0,
                TemperatureStatus = "",
            },

            new Beer
            {
                Id = "2",
                Name = "IPA",
                MinimumTemperature = 5,
                MaximumTemperature = 6,
                Temperature = 0,
                TemperatureStatus = "",
            },

            new Beer
            {
                Id = "3",
                Name = "Lager",
                MinimumTemperature = 4,
                MaximumTemperature = 7,
                Temperature = 0,
                TemperatureStatus = "",
            },

            new Beer
            {
                Id = "4",
                Name = "Stout",
                MinimumTemperature = 6,
                MaximumTemperature = 8,
                Temperature = 0,
                TemperatureStatus = "",
            },

            new Beer
            {
                Id = "5",
                Name = "Wheat beer",
                MinimumTemperature = 3,
                MaximumTemperature = 5,
                Temperature = 0,
                TemperatureStatus = "",
            },

            new Beer
            {
                Id = "6",
                Name = "Pale Ale",
                MinimumTemperature = 4,
                MaximumTemperature = 6,
                Temperature = 0,
                TemperatureStatus = "",
            }
        };
        public BeersRepo()
        {
        }

        public List<Beer> ListAll()
        {
            return beers;
        }

        public Beer GetById(string id)
        {
            return beers.Find(beer => beer.Id.Equals(id));
        }
    }
}
