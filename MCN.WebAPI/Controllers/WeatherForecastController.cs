using System;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 

namespace MCN.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // initialize Objects "AutoCodeNumber" :
        //private readonly IAutoCodeNumberBL autoCodeNumberBL;
        //babar private readonly IAuthResponse authResponse; 
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger )
        {
            try
            { 
                _logger = logger;
            }
            catch (Exception exc)
            {
                //MCN.Infrastructure.Logging.LockLoggingService.LockErrorLog(exc);
            }
        }
        [HttpGet]
        public object Get()
        {
            try
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
            catch (Exception exc)
            {
                //MCN.Infrastructure.Logging.LockLoggingService.LockErrorLog(exc);
                return null;
            }
        }
        [HttpGet("{id:int}")]
        public object Get(int id)
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
    }
}
