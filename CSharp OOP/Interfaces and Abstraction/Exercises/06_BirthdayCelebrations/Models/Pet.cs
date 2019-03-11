namespace _06_BirthdayCelebrations.Models
{
    using Contracts;
    
    class Pet : IBirth
    {

        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
