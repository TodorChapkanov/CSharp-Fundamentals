namespace _02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            //var blackBox = typeof(BlackBoxInteger);

           var  blackBoxType = typeof(BlackBoxInteger);

            var blackBox = (BlackBoxInteger)Activator.CreateInstance(blackBoxType, true);

            var allMethods = blackBoxType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var field = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo method;
            var line = string.Empty;
            while ((line = Console.ReadLine()) != "END")
            {
                var commands = line.Split('_');
                var methodName = commands[0];
                var parameter = int.Parse(commands[1]);
                switch (methodName)
                {
                    case "Add":
                        method = allMethods.First(m => m.Name == "Add");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;

                    case "Subtract":
                        method = allMethods.First(m => m.Name == "Subtract");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;

                    case "Divide":
                        method = allMethods.First(m => m.Name == "Divide");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;

                    case "Multiply":
                        method = allMethods.First(m => m.Name == "Multiply");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;

                    case "RightShift":
                        method = allMethods.First(m => m.Name == "RightShift");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;

                    case "LeftShift":
                        method = allMethods.First(m => m.Name == "LeftShift");
                        method.Invoke(blackBox, new object[] { parameter });
                        break;
                    default:
                        break;
                }

                var result = field.GetValue(blackBox);
                Console.WriteLine(result);
            }
        }
    }
}
