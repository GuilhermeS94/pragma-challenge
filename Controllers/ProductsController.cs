using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCodeChallenge.Models;
using DotNetCodeChallenge.Services;
using System.Linq;
using DotNetCodeChallenge.Repo;

namespace DotNetCodeChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private BeersRepo repo;
        private readonly ICheckBeerStatusService _service;
        public ProductsController(ICheckBeerStatusService service)
        {
            _service = service;
            repo = new BeersRepo();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Beer> beers = repo.ListAll();
            List<Task<Beer>> requests = new List<Task<Beer>>();

            beers.ForEach(beer => {
                requests.Add(_service.Execute(beer.Id));
            });

            var tasks = Task.WhenAll(requests);
            beers.Clear();
            beers.AddRange(tasks.Result.ToList());

            return Ok(beers);
        }
    }
}
