namespace _04_MatchingBrackets
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var indexOfBrackets = new Stack<int>();
            var sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexOfBrackets.Push(i);
                }
                else if (input[i] == ')')
                {
                    var startIndex = indexOfBrackets.Pop();
                    var endIndex = i - startIndex + 1;
                    sb.AppendLine(input.Substring(startIndex, endIndex));
                }
            }
            Console.WriteLine(sb);
        }
    }
}
