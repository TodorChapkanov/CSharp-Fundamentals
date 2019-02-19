namespace _01_Library
{
    using System;


    public class StartUp
    {
        public static void Main()
        {
            var firstBook = new Book("Animal Farm", 2003, "George Orwell");
            var secondBook = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            var thirdBook = new Book("The Documents in the Case", 1930);

            var libraryOne = new Library();
            var libraryTwo = new Library(firstBook, secondBook, thirdBook);

            foreach (var item in libraryTwo)
            {
                foreach (var author in item.Authors)
                {
                    Console.WriteLine(author);
                }
            }
        }
    }
}
