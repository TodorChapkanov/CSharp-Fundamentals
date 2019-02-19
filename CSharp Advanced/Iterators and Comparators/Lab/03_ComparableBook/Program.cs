namespace _03_ComparableBook
{
    using System;


    public class Program
    {
        public static void Main(string[] args)
        {
            var firstBook = new Book("Animal Farm", 2003, "George Orwell");
            var secondBook = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            var thirdBook = new Book("The Documents in the Case", 1930);

            var libraryOne = new Library();
            var libraryTwo = new Library( secondBook, thirdBook, firstBook);

            foreach (var item in libraryTwo)
            {
                Console.WriteLine(item);
            }
        }
    }
}
