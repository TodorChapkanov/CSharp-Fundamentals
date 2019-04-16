namespace MuOnline.Core
{
    using System;

    using Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var inputaArguments = Console.ReadLine().Split();

            var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

           var result = commandInterpreter.Read(inputaArguments);
            Console.WriteLine(result);
        }
    }
}
