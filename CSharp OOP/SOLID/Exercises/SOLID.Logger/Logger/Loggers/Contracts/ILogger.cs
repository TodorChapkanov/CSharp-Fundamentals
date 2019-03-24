namespace Logger.Loggers.Contracts
{
    using Appenders.Contracts;

    public interface ILogger
    {
        IAppender ConsoleAppender { get; }

        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Error(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dataTime, string message);
    }
}
