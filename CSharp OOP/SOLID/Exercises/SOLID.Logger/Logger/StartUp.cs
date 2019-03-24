namespace Logger
{
    using System;
    using Core;
    using Logger.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commondInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commondInterpreter);

            engine.Run();
        }
    }
}
