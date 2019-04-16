namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            var inputParameters = this.reader.ReadLine().Split();
            while (inputParameters[0] != "Terminate")
            {
                var result = this.commandInterpreter.ProcessInput(inputParameters);
                this.writer.WriteLine(result);
                inputParameters = this.reader.ReadLine().Split();
            }

            var report = this.commandInterpreter.ProcessInput(inputParameters);
            this.writer.WriteLine(report);
        }
    }
}