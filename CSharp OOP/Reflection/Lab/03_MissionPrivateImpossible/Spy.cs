
using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string RevealPrivateMethods(string className)
    {
        Type testClassType = Type.GetType(className);
        MethodInfo[] methods = testClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var builder = new StringBuilder();

        builder.AppendLine($"All Private Methods of Class: {className}");
        builder.AppendLine($"Base Class: {testClassType.BaseType.Name}");

        foreach (MethodInfo method in methods)
        {
            builder.AppendLine(method.Name);
        }

        var result = builder.ToString().Trim();

        return result;
    }
}
