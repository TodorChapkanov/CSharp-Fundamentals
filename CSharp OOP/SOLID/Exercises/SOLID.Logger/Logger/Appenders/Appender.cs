namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Layouts.Contracts;
    using Logger.Loggers.Enums;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }
        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string datatime, ReportLevel reportLevel, string message);

    }
}
