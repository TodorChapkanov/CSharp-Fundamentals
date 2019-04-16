namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }

        public override string ToString()
        {
            return $"    Animal type: {typeof(Cat).Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
