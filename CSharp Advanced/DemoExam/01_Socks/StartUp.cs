namespace _01_Socks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var left = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var right = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var leftSocks = new Stack<int>(left);
            var rightSocks = new Queue<int>(right);

            var pairs = new Queue<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                var leftSock = leftSocks.Peek();
                var rightSock = rightSocks.Peek();
                if (leftSock == rightSock)
                {
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSock + 1);
                }
                else if (rightSock > leftSock)
                {
                    leftSocks.Pop();
                }
                else if (leftSock > rightSock)
                {
                    var pair = leftSock + rightSock;
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                    pairs.Enqueue(pair);
                }
            }
            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(' ', pairs));
        }
    }
}
