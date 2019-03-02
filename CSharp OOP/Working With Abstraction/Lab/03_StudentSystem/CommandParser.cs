using System.Linq;

namespace P03_StudentSystem
{
    public class CommandParser
    {
        public Command Parse(string command)
        {
            var parts = command.Split();
            return new Command
            {
                Name = parts[0],
                Argumentd = parts.Skip(1).ToArray()
            };
        }
    }
}
