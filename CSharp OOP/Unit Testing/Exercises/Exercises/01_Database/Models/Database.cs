namespace _01_Database.Models
{
    using System;
    using System.Linq;

    public class Database
    {
        public const int DatabaseLength = 16;
        public static string ErrorMessage = "Canot add more than {0} numbers in Database";

        private int[] database;
        private int index;

        public Database()
        {
            this.database = new int[DatabaseLength];
        }

        public Database(params int[] parameters)
            :this()
        {
            AddInitialNumbersToDatabase(parameters);
        }

        public void Add(int number)
        {
            if (index == DatabaseLength)
            {
                throw new InvalidOperationException(string.Format(ErrorMessage, DatabaseLength));
            }
            database[index] = number;

            index++;
        }

        public int Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("DataBase is empty");
            }

            this.index--;
            var result = database[index];
            this.database[index] = default(int);
            return result;
        }

        public int[] Fetch => this.database.Take(index).ToArray();

        private void AddInitialNumbersToDatabase(int[] parameters)
        {
            foreach (var number in parameters)
            {
                this.Add(number);
            }
        }
    }
}
