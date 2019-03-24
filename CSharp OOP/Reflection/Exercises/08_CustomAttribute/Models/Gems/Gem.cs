namespace _08_CustomAttribute.Models.Gems
{
    using Contracts;
    using Enums;

    public abstract class  Gem : IGem
    {
        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitlity { get; protected set; }

        public void SetClarityLevel (GemsClarityLevel clarityLevel)
        {
            this.Strength += (int)clarityLevel;
            this.Agility += (int)clarityLevel;
            this.Vitlity += (int)clarityLevel;
        }
    }
}
