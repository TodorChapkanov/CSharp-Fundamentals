namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {
        private const int StrengthPoints = 15;
        private const int AgilityPoints = 40;
        private const int EnergyPoints = 15;
        private const int StaminaPoints = 25;

        public BuffArmor() : base(StrengthPoints, AgilityPoints, StaminaPoints, EnergyPoints)
        {
        }
    }
}
