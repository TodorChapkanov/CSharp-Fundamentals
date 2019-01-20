namespace _09_Miner
{
    using System;
    using System.Collections.Generic;

    public class Miner
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var matrix = new string[matrixSize, matrixSize];

            var input = Console.ReadLine().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var commands = new Queue<string>(input);
            var startRow = 0;
            var startCol = 0;
            var coal = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                var line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == "s")
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if (line[col] == "c")
                    {
                        coal++;
                    }
                }
            }
            var coalCount = 0;
            var rowToMove = 0;
            var colToMove = 0;
            while (coal != 0)
            {

                if (commands.Count == 0)
                {
                    Console.WriteLine($"{coal} coals left. ({rowToMove}, {colToMove})");
                    return;
                }
                var curentCommand = commands.Dequeue();
                switch (curentCommand)
                {
                    case "left":
                        rowToMove = startRow;
                        colToMove = startCol - 1;
                        break;
                    case "right":
                        rowToMove = startRow;
                        colToMove = startCol + 1;
                        break;
                    case "up":
                        rowToMove = startRow - 1;
                        colToMove = startCol;
                        break;
                    case "down":
                        rowToMove = startRow + 1;
                        colToMove = startCol;
                        break;
                }
                if (rowToMove >= 0 && rowToMove < matrix.GetLength(0) &&
                    colToMove >= 0 && colToMove < matrix.GetLength(1))
                {
                    if (matrix[rowToMove, colToMove] == "e")
                    {
                        Console.WriteLine($"Game over! ({rowToMove}, {colToMove})");
                        return;
                    }
                    if (matrix[rowToMove, colToMove] == "c")
                    {
                        coal--;
                        coalCount++;
                        matrix[rowToMove, colToMove] = "*";
                    }
                    startRow = rowToMove;
                    startCol = colToMove;
                }


            }
            Console.WriteLine($"You collected all coals! ({rowToMove}, {colToMove})");
        }
    }
}
