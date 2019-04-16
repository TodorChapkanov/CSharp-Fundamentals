namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffHelmet : Item
    {
        private const int StrengthPoints = 20;
        private const int AgilityPoints = 5;
        private const int EnergyPoints = 5;
        private const int StaminaPoints = 15;

        public BuffHelmet() : base(StrengthPoints, AgilityPoints, StaminaPoints, EnergyPoints)
        {
        }
    }
}
