using _05_BorderControl.Contracts;

namespace _05_BorderControl.Models
{
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
