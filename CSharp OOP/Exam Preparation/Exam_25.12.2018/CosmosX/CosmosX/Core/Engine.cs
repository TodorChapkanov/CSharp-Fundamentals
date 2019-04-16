using CosmosX.Core.Contracts;
using CosmosX.IO.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CosmosX.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandParser commandParser;

        public Engine(IReader reader, IWriter writer, ICommandParser commandParser)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandParser = commandParser;
        }

        public void Run()
        {
            List<string> arguments ;
            var builder = new StringBuilder();
            while (true)
            {
                arguments = reader.ReadLine().Split().ToList();
                if (arguments[0] == "Exit")
                {
                    break;
                }
                builder.AppendLine(commandParser.Parse(arguments));
            }

            builder.Append(commandParser.Parse(arguments));

            writer.WriteLine(builder.ToString());
        }
    }
}