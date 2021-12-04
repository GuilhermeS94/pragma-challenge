using System;
using System.Collections.Generic;
using DotNetCodeChallenge.Models;
using DotNetCodeChallenge.Repo;
using Xunit;
using Moq;

namespace DotNetCodeChallenge.Tests
{
    public class BeersRepoTest
    {
        IBeersRepo _db;
        private List<Beer> _beers;
        Mock<IBeersRepo> _dbMock;

        public BeersRepoTest()
        {
            _dbMock = new Mock<IBeersRepo>();
        }

        [Fact]
        public void ShouldListAllBeers()
        {
            _dbMock
            .Setup(item => item.ListAll())
            .Returns(new List<Beer>()
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
                }
            );
            _db = _dbMock.Object;

            List<Beer> beers = _db.ListAll();
            
            Assert.True(beers.Count == 6);
        }

        [Fact]
        public void ShouldGetOneBeerById()
        {
            _dbMock
            .Setup(item => item.GetById("3"))
            .Returns(new Beer
                    {
                        Id = "3",
                        Name = "Lager",
                        MinimumTemperature = 4,
                        MaximumTemperature = 7,
                        Temperature = 0,
                        TemperatureStatus = "",
                    }
            );
            _db = _dbMock.Object;
            Beer beer = _db.GetById("3");
            Assert.NotNull(beer);
        }
    }
}
