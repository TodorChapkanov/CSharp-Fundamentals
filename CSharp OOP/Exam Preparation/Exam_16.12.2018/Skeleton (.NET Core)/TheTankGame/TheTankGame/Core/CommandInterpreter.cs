namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPrefix = "Add";

        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            inputParameters = inputParameters.Skip(1).ToList();

            string result = string.Empty;
            var methodName = CommandPrefix + command;
            result = (string)this.tankManager
                .GetType()
                .GetMethods()
                .First(m => m.Name == methodName || m.Name == command)
                .Invoke(this.tankManager, new object[] { inputParameters });

       
            return result;
        }
    }
}