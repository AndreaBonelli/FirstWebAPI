using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // grazie a [] prende da solo "WeatherForecast"
    public class StringController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public StringController()
        {
        }

        [HttpGet()]
        public string GetString(string s)
        {
            return "Stringa inserita: " + s;
        }
    }
}