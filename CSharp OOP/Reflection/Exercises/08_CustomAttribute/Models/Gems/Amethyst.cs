namespace _08_CustomAttribute.Models.Gems
{
    using Constants;
   public  class Amethyst : Gem
    {
        public Amethyst()
        {
            this.Agility = GemsConstants.AmathistAgility;
            this.Strength = GemsConstants.AmathistStrenght;
            this.Vitlity = GemsConstants.AmathistVitality;
        }
    }
}
