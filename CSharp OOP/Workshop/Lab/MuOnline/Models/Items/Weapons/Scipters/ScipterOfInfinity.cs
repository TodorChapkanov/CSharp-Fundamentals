namespace MuOnline.Models.Items.Weapons.Scipters
{
    public class ScipterOfInfinity : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 30;
        private const int energyPoints = 30;
        private const int staminaPoints = 10;

        public ScipterOfInfinity() : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
