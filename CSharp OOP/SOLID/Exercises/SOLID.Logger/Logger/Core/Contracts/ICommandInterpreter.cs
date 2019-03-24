namespace Logger.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void AddAppender(string[] arg);

        void AddMessage(string[] arg);

        void PintInfo();
    }
}
