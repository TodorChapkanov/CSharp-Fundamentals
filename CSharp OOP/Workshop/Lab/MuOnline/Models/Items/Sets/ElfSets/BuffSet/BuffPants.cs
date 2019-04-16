namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffPants : Item
    {
        private const int StrengthPoints = 25;
        private const int AgilityPoints = 25;
        private const int EnergyPoints = 10;
        private const int StaminaPoints = 20;

        public BuffPants() : base(StrengthPoints, AgilityPoints, StaminaPoints, EnergyPoints)
        {
        }
    }
}
