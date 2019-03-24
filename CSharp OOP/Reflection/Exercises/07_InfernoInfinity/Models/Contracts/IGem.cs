namespace _07_InfernoInfinity.Models.Contracts
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
