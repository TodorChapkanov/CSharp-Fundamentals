using System.Collections;
using System.Collections.Generic;

namespace _03_ComparableBook
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator() => this.books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    }

}
