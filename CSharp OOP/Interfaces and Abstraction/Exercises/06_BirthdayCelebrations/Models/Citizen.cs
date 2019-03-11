namespace _06_BirthdayCelebrations.Models
{
    using Contracts;
    class Citizen : IIdentifiable, IBirth
    {

        public Citizen(string Id, string name, int age, string birthdate)
        {
            this.Id = Id;
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Id { get; set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; set; }
    }
}
