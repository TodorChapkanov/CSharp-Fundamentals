using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
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
