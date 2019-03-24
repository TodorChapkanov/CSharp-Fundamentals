namespace _08_CustomAttribute.Models.Gems
{
    using Constants;

   public class Ruby : Gem
    {
        public Ruby()
        {
            this.Agility = GemsConstants.RubyAgility;
            this.Strength = GemsConstants.RubyStrenght;
            this.Vitlity = GemsConstants.RubyVitality;
        }
    }
}
