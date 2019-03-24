namespace Logger.Appenders.Factories
{
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factories.Contracts;
    using Logger.Layouts.Contracts;
    using Logger.Loggers;
    using System;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            var typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);

                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid Appenter type!");
            }
        }
    }
}
