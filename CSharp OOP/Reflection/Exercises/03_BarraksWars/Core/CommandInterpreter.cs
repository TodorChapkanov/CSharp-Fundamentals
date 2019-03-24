namespace _03_BarraksWars.Core
{
    using _03_BarracksFactory.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private  IRepository repository;
        private  IUnitFactory factory;

        public CommandInterpreter(IRepository repository, IUnitFactory factory)
        {
            this.repository = repository;
            this.factory = factory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var interfaceType = typeof(IExecutable);
            var allCalssesInAssembly = Assembly.GetExecutingAssembly();
            var allCommands = allCalssesInAssembly.GetTypes();
            var interfaceImplementers
                = allCommands.Where(t => t.GetInterfaces().Contains(interfaceType));


            var commandType = interfaceImplementers.First(c => c.Name.ToLower() == $"{commandName}command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            var command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data,this.repository, this.factory});
            return command;
        }
    }
}
