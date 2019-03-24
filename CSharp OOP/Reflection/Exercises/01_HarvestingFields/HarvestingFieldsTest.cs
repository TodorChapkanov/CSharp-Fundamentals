namespace _01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "HARVEST")
            {



                string fields = null;


                switch (command.ToLower())
                {
                    case "public":
                        fields = GetPublicFieldsAsString();
                        break;

                    case "protected":
                        fields = GetProtectedFieldsAsString();
                        break;

                    case "private":
                        fields = GetPrivateFieldsAsString();
                        break;

                    case "all":
                        fields = GetAllFieldsAsString();
                        break;
                    default:
                        break;
                }

                if (fields != null)
                {
                    Console.WriteLine(fields);
                }
            }
        }

        public static string GetPublicFieldsAsString()
        {
            var stringBuilder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields()
                .ToList()
                .ForEach(f => stringBuilder.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));

            return stringBuilder.ToString().TrimEnd();
        }

        public static string GetProtectedFieldsAsString()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsFamily)
                .ToList()
                .ForEach(f => builder.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));

            return builder.ToString().Replace("family", "protected").TrimEnd();
        }

        public static string GetPrivateFieldsAsString()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => !f.IsFamily)
                .ToList()
                .ForEach(f => builder.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));

            return builder.ToString().TrimEnd();
        }

        public static string GetAllFieldsAsString()
        {
            var builder = new StringBuilder();

            var type = typeof(HarvestingFields);

            type
                .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
                .ToList()
                .ForEach(f => builder.AppendLine($"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}"));

            return builder.ToString().Replace("family", "protected").TrimEnd();
        }
    }
}
