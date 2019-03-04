namespace _03_JediGalaxy
{
    class Enemy
    {
        public Enemy(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }



        public void Move(int[,] matrix)
        {
            var row = this.Row;
            var col = this.Col;

            while (row >= 0 && col >= 0)
            {
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                {
                    matrix[row, col] = 0;
                }
                row--;
                col--;
            }

        }
    }
}
