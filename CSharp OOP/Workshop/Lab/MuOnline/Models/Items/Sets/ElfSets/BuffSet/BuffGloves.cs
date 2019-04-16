namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffGloves : Item
    {
        private const int StrengthPoints = 10;
        private const int AgilityPoints = 10;
        private const int EnergyPoints = 0;
        private const int StaminaPoints = 5;

        public BuffGloves() : base(StrengthPoints, AgilityPoints, StaminaPoints, EnergyPoints)
        {
        }
    }
}
