namespace MuOnline.Core
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }   

        public string Read(string[] args)
        {
            var command = args[0].ToLower() + Suffix;
            var arguments = args.Skip(1).ToArray();
            
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == command);

            var constructor = type
                .GetConstructors()
                .First();

            var constructorParameters = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var parameters = constructorParameters
                .Select(this.serviceProvider.GetService)
                .ToArray();

            var typeInstance = (ICommand)Activator.CreateInstance(type, parameters);
            var result = typeInstance.Execute(arguments);
            return result;
        }
    }
}
