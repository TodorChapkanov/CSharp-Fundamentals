namespace _04_MergeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class MergeFiles
    {
        private const string firstInputPath = @"04. Merge Files\FileOne.txt";
        private const string secondInputPath = @"04. Merge Files\FileTwo.txt";
        private const string outputFilePath = @"..\..\..\04. Merge Files\output.txt";


        public static void Main()
        {
            var mergeString = new SortedSet<string>();
            using (var streamReader = new StreamReader(firstInputPath))
            {
                using (var secondReader = new StreamReader(secondInputPath))
                {
                    while (true)
                    {
                        var firstInput = streamReader.ReadLine();
                        var secondInput = secondReader.ReadLine();

                        if (firstInput == null || secondInput == null)
                        {
                            break;
                        }

                        mergeString.Add(firstInput);
                        mergeString.Add(secondInput);
                    }
                }
            }
            using (var sw = new StreamWriter(outputFilePath))
            {
                sw.Write(string.Join(Environment.NewLine, mergeString));
            }
        }
    }
}
