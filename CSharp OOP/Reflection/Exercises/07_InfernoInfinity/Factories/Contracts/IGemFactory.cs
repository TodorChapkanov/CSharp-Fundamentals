namespace _07_InfernoInfinity.Factories.Contracts
{
    using Models.Contracts;


    public interface IGemFactory
    {
        IGem CreateGem(string gemType, string clarityLevel);
    }
}
