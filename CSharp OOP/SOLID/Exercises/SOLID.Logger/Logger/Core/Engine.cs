namespace Logger.Core
{
    using Logger.Core.Contracts;
    using System;

    public class Engine : IEngine
    {

        //TODO Finish the reading commands from console
        private ICommandInterpreter commondInterpreter;

        public Engine(ICommandInterpreter commondInterpreter)
        {
            this.commondInterpreter = commondInterpreter;
        }

        public void Run()
        {
            var appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                var input = Console.ReadLine().Split();
                this.commondInterpreter.AddAppender(input);
            }

            var inputMessage = string.Empty;
            while ((inputMessage = Console.ReadLine()) != "END")
            {
                var inputArguments = inputMessage.Split("|");

                this.commondInterpreter.AddMessage(inputArguments);
            }

            this.commondInterpreter.PintInfo();
        }
    }
}
