using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // grazie a [] prende da solo "WeatherForecast"
    public class StringController : ControllerBase
    {
        List<string> list = new List<string>();

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost("fill")]
        public string FillList()
        {
            foreach (var s in Summaries)
                list.Add(s);
            return "lista riempita";
        }

        [HttpPost("add/{s}")]
        public string AddToList(string s)
        {
            list.Add(s);
            return "Stringa inserita: " + s;
        }

        
    }
}