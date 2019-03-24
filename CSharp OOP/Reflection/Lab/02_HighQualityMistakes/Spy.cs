using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);
        var buider = new StringBuilder();

        classType.
            GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public)
            .ToList()
            .ForEach(f => buider.AppendLine($"{f.Name} must be private!"));

        classType
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("get"))
            .ToList()
            .ForEach(m => buider.AppendLine($"{m.Name} have to be public!"));

        classType
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name.StartsWith("set"))
            .ToList()
            .ForEach(m => buider.Append($"{m.Name} have to be private!"));


        var result = buider.ToString().Trim();
        return result;
    }



    public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
    {
        var classType = Type.GetType(classToInvestigate);
        var classInstance = Activator.CreateInstance(classType, new object[0] { });

        var fields = classType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Where(f => fieldsToInvestigate.Contains(f.Name))
            .ToList();

        var result = new StringBuilder()
            .AppendLine($"Class under investigation: {classToInvestigate}");

        fields
                .ForEach(f => result.AppendLine($"{f.Name} = {f.GetValue(classInstance)}"));

        return result.ToString();

    }
}
