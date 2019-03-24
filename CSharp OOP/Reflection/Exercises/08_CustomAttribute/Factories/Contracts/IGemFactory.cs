namespace _08_CustomAttribute.Factories.Contracts
{
    using Models.Contracts;


    public interface IGemFactory
    {
        IGem CreateGem(string gemType, string clarityLevel);
    }
}
