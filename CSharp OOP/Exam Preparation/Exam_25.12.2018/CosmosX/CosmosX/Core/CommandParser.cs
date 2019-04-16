using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CosmosX.Core.Contracts;

namespace CosmosX.Core
{
    public class CommandParser : ICommandParser
    {
        private const string CommandNameSuffix = "Command";

        private readonly IManager reactorManager;

        public CommandParser(IManager reactorManager)
        {
            this.reactorManager = reactorManager;
        }

        public string Parse(IList<string> arguments)
        {
            string command = arguments[0] + CommandNameSuffix;

            string[] commandArguments = arguments.Skip(1).ToArray();

            MethodInfo currentMethod = reactorManager
                  .GetType()
                  .GetMethods()
                  .FirstOrDefault(x => x.Name == command);

            return (string)currentMethod.Invoke(reactorManager, new object[] { commandArguments });
        }
    }
}