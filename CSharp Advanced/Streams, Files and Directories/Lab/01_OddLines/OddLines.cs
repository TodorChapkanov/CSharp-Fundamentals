namespace _01_OddLines
{
    using System;
    using System.IO;
    using System.Text;

    public class OddLines
    {
        public static void Main()
        {
            var couner = 0;

            using (var streamReader = new StreamReader("01. Odd Lines/input.txt"))
            {
                using (var streamWriter = new StreamWriter("Output.txt"))
                {
                    while (true)
                    {
                        var line = streamReader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (couner % 2 != 0)
                        {
                            streamWriter.WriteLine(line);
                        }
                        couner++;
                    }
                }
            }
        }
    }
}
