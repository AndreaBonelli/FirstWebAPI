using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // grazie a [] prende da solo "WeatherForecast"
    public class StringController : ControllerBase
    {
        public static List<string> list = new List<string>();

        public string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpPost("fill")]
        public string FillList()
        {
            foreach (var s in Summaries)
                list.Add(s);

            foreach (var s in Summaries)
                Console.WriteLine(s);
            return "lista riempita";
        }

        [HttpPost("add/{s}")]
        public string AddToList(string s)
        {
            list.Add(s);
            return "Stringa inserita: " + s;
        }

        [HttpPost("removeAt/{index}")]
        public string RemoveAt(int index)
        {
            if(list.Remove(list.ElementAt(index)))
                return "Elemento eliminato: " + list.ElementAt(index); ;
            return "Elemento non trovato";
        }

        [HttpGet()]
        public string GetAllFromList()
        {
            string all=string.Empty;
            foreach (var s in list)
                all += s + "\n";
            return "lista completa:\n" + all;
        }

        [HttpGet("elementAt/{index}")]
        public string ElementAt(int index)
        {
            Console.WriteLine("Elemento trovato: " + list.ElementAt(index));
            return "Elemento trovato: " + list.ElementAt(index); ;
        }


    }
}