namespace _02_ExtendedDatabase.Models
{
    using _02_ExtendedDatabase.Models.Contracts;

    public class Person : IPerson
    {
        public Person(long id, string name)
        {
            this.Name = name;
            this.Id = id;
        }
        public string Name { get; private set; }

        public long Id { get; private set; }
    }
}
