namespace _09_CollectionHierarchy.Contracts
{
    public interface IRemovable : IAddable<string>
    {
        string Remove();
    }
}
