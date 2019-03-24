namespace Logger.Appenders
{
    using Layouts.Contracts;
    using Loggers.Enums;


    public  class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string dataTime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.MessagesCount++;
                System.Console.WriteLine(string.Format(this.Layout.Format, dataTime, reportLevel, message));
            }

        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}" +
                $", Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}
