namespace _06_JaggedArrayModification
{
    using System;
    using System.Linq;

    public class JaggedArrayModification
    {
        public static void Main(string[] args)
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            while (true)
            {
                var input = Console.ReadLine().Split();

                if (input[0].ToLower() == "end")
                {
                    break;
                }
                
                var command = input[0].ToLower();
                var curentRow = int.Parse(input[1]);
                var curentCol = int.Parse(input[2]);
                var value = int.Parse(input[3]);

                if (curentRow < 0 || curentRow > matrix.GetLength(0) -1 ||
                    curentCol < 0 || curentCol > matrix.GetLength(1) -1 )
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                if (command == "add")
                {
                    matrix[curentRow , curentCol] += value;
                }
                else if (command == "subtract")
                {
                    matrix[curentRow, curentCol ] -= value;
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
