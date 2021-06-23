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
    public class ProductController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        public string Message { get; set; }
        /*
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
        */
        // GET api/ProductController/id
        //[HttpGet("{id}", Name = nameof(GetProductControllerById))]
        [HttpGet("{id}")]
        public IActionResult GetProductControllerById([FromForm] int id)
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

