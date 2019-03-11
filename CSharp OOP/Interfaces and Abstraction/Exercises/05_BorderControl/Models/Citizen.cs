namespace _05_BorderControl.Models
{
    using Contracts;
    class Citizen : IIdentifiable
    {

        public Citizen(string Id, string name, int age)
        {
            this.Id = Id;
            this.Name = name;
            this.Age = age;
        }

        public string Id { get;  set; }

        public string Name { get; private set; }

        public int Age { get; private set; }
    }
}
