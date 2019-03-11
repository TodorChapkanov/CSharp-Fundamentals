namespace _05_BorderControl.Models
{
    using _06_BirthdayCelebrations.Contracts;

    class Robor : IIdentifiable
    {
        public Robor(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; set; }

        public string Model { get; set; }
    }
}
