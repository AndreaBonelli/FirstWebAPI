using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public List<Person> list = new List<Person>();

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

        [HttpPost("add/{s}")]
        public string AddToList(Person p)
        {
            list.Add(p);
            return "Persona inserita: " + p;
        }

        [HttpPost("removeAt/{index}")]
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

        [HttpGet("elementAt/{index}")]
        public string ElementAt(int index)
        {
            return "Persona trovata: " + list.ElementAt(index); ;
        }

    }
}
