namespace _03_JediGalaxy
{
   public class Hero
    {
        public Hero(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }


        public long Move(int[,] matrix)
        {
            var heroRow = this.Row;
            var heroCol = this.Col;
            var sum = 0L;

             while (heroRow >= 0 && heroCol < matrix.GetLength(1))
             {
                 if (heroRow >= 0 && heroRow < matrix.GetLength(0) && heroCol >= 0 && heroCol < matrix.GetLength(1))
                 {
                     sum += matrix[heroRow, heroCol];
                 }
            
                 heroCol++;
                 heroRow--;
             }

            // while (row >= 0 && col < matrix.GetLength(1))
            // {
            //     if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            //     {
            //         sum += matrix[row,col];
            //     }
            //
            //     row--;
            //     col++;
            // }
            return sum;
        }
        
    }
}
