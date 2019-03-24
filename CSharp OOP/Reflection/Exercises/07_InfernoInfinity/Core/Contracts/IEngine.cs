namespace _07_InfernoInfinity.Core.Contracts
{
   public  interface IEngine
    {
        ICommandInterpreter CommandInterpreter { get; }

        void Run();
    }
}
