namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffBoots : Item
    {
        private const int StrengthPoints = 11;
        private const int AgilityPoints = 20;
        private const int EnergyPoints = 10;
        private const int StaminaPoints = 20;

        public BuffBoots() : base(StrengthPoints, AgilityPoints, StaminaPoints, EnergyPoints)
        {
        }
    }
}
