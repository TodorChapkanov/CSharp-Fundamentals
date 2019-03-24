namespace Logger.Layouts.Factories.Contracts
{
    using Logger.Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
