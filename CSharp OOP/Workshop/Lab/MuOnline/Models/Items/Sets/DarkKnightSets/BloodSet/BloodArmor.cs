namespace MuOnline.Models.Items.Sets.DarkKnightSets.BloodSet
{
    public class BloodArmor : Item
    {
        private const int StrengthPoints = 10;
        private const int AgilityPoints = 30;
        private const int EnergyPoints = 0;
        private const int StaminaPoints = 25;

        public BloodArmor() 
            : base(StrengthPoints, AgilityPoints, EnergyPoints, StaminaPoints)
        {
        }
    }
}
