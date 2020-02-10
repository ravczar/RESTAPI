using AccountOwnerServer.Models;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static readonly string[] Models = new string[]
        {
            "Multipla", "Note", "126p", "Panda", "NewBeetle", "Fiesta", "GTR", "911Turbo", "Skyline", "Panda", "Berlingo"
        };
        private static readonly string[] Brand = new string[]
        {
            "Fiat", "Nissan", "Ford", "Opel", "Aston Martin", "Citroen", "Porsche", "VolksWagen"
        };
        private readonly ILoggerManager _logger;
        public CarController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Car> Get()
        {
            var randGen = new Random();

            return Enumerable.Range(1, 5).Select(index => new Car(
                DateTime.Now,
                Models[randGen.Next(Models.Length)],
                Brand[randGen.Next(Brand.Length)])
            ).ToArray();
        }

    }
}
