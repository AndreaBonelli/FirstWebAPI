using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

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
            
            return "lista riempita";
        }

        [HttpPost("add/{s}")]
        public string AddToList(string s)
        {
            list.Add(s);
            return "Stringa inserita: " + s;
        }

        [HttpDelete("removeAt/{index}")]
        public string RemoveAt(int index)
        {
            string elem = list.ElementAt(index);
            if (list.Remove(elem))
                return "Elemento eliminato: " + elem;
            
            return "Elemento non eliminato";
        }

        [HttpGet()]
        public string GetAllFromList()
        {
            string all=string.Empty;
            foreach (var s in list)
                all += "\n" + s;
            
            return "lista completa:" + all;
        }

        [HttpGet("elementAt/{index}")]
        public string ElementAt(int index)
        {
            //if(list.Count > index && index>0)
            try
            {
                return "Elemento trovato: " + list.ElementAt(index);
            }
            catch(ArgumentOutOfRangeException)
            {
                return "L'ndice inserito è fuori dai confini della lista";
            }
            
        }


    }
}