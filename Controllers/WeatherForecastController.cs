using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ASPWebNETCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET /WeatherForecast/id
        [HttpGet("{id}", Name = nameof(GetWeatherForecastById))]
        public IActionResult GetWeatherForecastById([FromBody] int id)
        {

            string res = id.ToString();
             res = GetDetails.GetIpdetails();


            return new ObjectResult(res);



        }

        [HttpPut("{id}")]
        public static string Get([FromBody] string userId, string productId, int quantity)
        {
            var rng = new Random();

            Console.WriteLine($"AddItemAsync called with userId={userId}, productId={productId}, quantity={quantity}");
            var sum = "AddItem  called with userId= " + userId + "  Product " + productId;

            return sum;
        }




    }
}

