namespace Logger.Loggers
{
    using Contracts;
    using global::Logger.Appenders.Contracts;
    using global::Logger.Loggers.Enums;

    public class Logger : ILogger
    {
        public Logger(IAppender consoleAppender)
        {
            this.ConsoleAppender = consoleAppender;
        }

        public Logger(IAppender consoleAppender, IAppender fileAppender)
            :this(consoleAppender)
        {
            
            this.FileAppender = fileAppender;
            
        }

        public IAppender ConsoleAppender { get; private set; }

        public IAppender FileAppender { get; private set; }

        public void Critical(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.CRITICAL, message);
        }

        public void Error(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.ERROR, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.FATAL, message);

        }

        public void Info(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.INFO, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.Log(dateTime, ReportLevel.WARNING, message);
        }

        private void Log(string dateTime, ReportLevel reportLevel, string message)
        {
            this.ConsoleAppender?.Append(dateTime, reportLevel, message);
            this.FileAppender?.Append(dateTime, reportLevel, message);
        }
    }
}
