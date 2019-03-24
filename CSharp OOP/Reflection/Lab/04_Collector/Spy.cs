using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);
        var methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var builder = new StringBuilder();

        foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (var method in methods.Where(m=> m.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        var result = builder.ToString().Trim();
        return result;
    }
}