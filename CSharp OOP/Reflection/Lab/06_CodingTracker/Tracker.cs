
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var classType = typeof(StartUp);

        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(n => n.AttributeType == (typeof(AuthorAttribute))))
            {
                var attributes = methodInfo.GetCustomAttributes(false);

                foreach (AuthorAttribute attribute in attributes)
                {
                    System.Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
