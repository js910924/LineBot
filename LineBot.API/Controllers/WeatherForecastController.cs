using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LineBot.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public ActionResult Test()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                      .Add("Authorization", @"Bearer {YvWZ+lhw4mBszIb4cuow/211m0BvEDX2AB5auS3IwkzkN1POJ3ej4Gw20tX17/hL/3PN0wKXlHl4xeFcySt4TbhujKQWqUlcuJhnIeI84xb3kHagP3gIwEoHppOvugwexZeNAPc14O0fbX7Stek35QdB04t89/1O/w1cDnyilFU=}");

            var postData = "";

            return Ok("OK");
        }
    }
}
