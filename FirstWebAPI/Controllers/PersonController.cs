using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static List<Person> list = new List<Person>();

        public Person[] RandomPeople = new[]
        {
            new Person("Bruce","Ketta",4),
            new Person("Nino","Galba",7),
            new Person("Jenny","Ferlopez",2)
        };

        [HttpPost("fill")]
        public string FillList()
        {
            foreach (var p in RandomPeople)
                list.Add(p);
            return "lista riempita";
        }

        [HttpPost("add")]
        public string AddToList([FromBody]Person p)
        {
            list.Add(p);
            return "Persona inserita: " + p;
        }

        [HttpDelete("removeAt/{index}")]
        public string RemoveAt(int index)
        {
            if (list.Remove(list.ElementAt(index)))
                return "Persona eliminata: " + list.ElementAt(index); ;
            
            return "Persona non trovata";
        }

        [HttpGet()]
        public string GetAllFromList()
        {
            string all = string.Empty;
            foreach (var p in list)
                all += p + "\n";
            return "lista completa:\n" + all;
        }

        [HttpGet("personAt/{index}")]
        public string personAt(int index)
        {
            try
            {
                return "Elemento trovato: " + list.ElementAt(index);
            }
            catch (ArgumentOutOfRangeException)
            {
                //return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
                return "L'indice inserito è fuori dai confini della lista";
            }
        }

    }
}
