using System;
using System.Threading.Tasks;
using DotNetCodeChallenge.Models;

namespace DotNetCodeChallenge.Services
{
    public interface ICheckBeerStatusService
    {
        Task<Beer> Execute(string beerId);
    }
}
