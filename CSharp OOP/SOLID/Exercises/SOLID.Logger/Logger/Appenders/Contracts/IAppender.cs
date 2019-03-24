namespace Logger.Appenders.Contracts
{
    using Logger.Loggers.Enums;

    public interface IAppender
    {
        void Append(string datatime, ReportLevel reportLevel, string message);

        ReportLevel ReportLevel { get; set; }

        int MessagesCount { get; }
    }
}
