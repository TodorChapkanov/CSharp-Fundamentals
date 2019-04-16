namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
        public override string ToString()
        {
            return $"    Animal type: {typeof(Pig).Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
