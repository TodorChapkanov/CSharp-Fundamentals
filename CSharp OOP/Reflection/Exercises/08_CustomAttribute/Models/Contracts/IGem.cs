namespace _08_CustomAttribute.Models.Contracts
{
    using Gems.Enums;


    public interface IGem
    {
        int Strength { get; }

        int Agility { get; }

        int Vitlity { get; }

        void SetClarityLevel(GemsClarityLevel clarityLevel);
    }
}
