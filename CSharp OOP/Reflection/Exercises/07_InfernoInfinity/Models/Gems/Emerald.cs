namespace _07_InfernoInfinity.Models.Gems
{
    using Constants;

   public class Emerald : Gem
    {
        public Emerald()
        {
            this.Agility = GemsConstants.EmeraldAgility;
            this.Strength = GemsConstants.EmeraldStrenght;
            this.Vitlity = GemsConstants.EmeraldVitality;
        }
    }
}
