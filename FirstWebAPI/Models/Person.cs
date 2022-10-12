namespace FirstWebAPI.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }

        public Person()
        {
        }

        public Person(string name, string surname, int id)
        {
            Name = name;
            Surname = surname;
            Id = id;
        }

        public override string? ToString()
        {
            return $"Name: {Name}, Surname: {Surname}, Id: {Id}.";
        }
    }
}
