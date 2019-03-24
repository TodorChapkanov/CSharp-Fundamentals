namespace Logger.Core
{
    using Contracts;
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Factories;
    using Logger.Appenders.Factories.Contracts;
    using Logger.Layouts.Contracts;
    using Logger.Layouts.Factories;
    using Logger.Layouts.Factories.Contracts;
    using Logger.Loggers.Enums;
    using System;
    using System.Collections.Generic;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> appenders;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public CommandInterpreter()
        {
            this.appenders = new List<IAppender>();
            this.appenderFactory = new AppenderFactory();
            this.layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            var appenderType = args[0];
            var layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2]);
            }

            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;

            this.appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0]);
            string dataTime = args[1];
            string message = args[2];

            foreach (var appender in appenders)
            {
                appender.Append(dataTime, reportLevel, message);
            }
        }

        public void PintInfo()
        {
            Console.WriteLine("Logger info");

            foreach (var apprender in appenders)
            {
                Console.WriteLine(apprender);
            }
        }
    }
}
