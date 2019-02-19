namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;


    public class Library : IEnumerable<Book>
    {
        private readonly IList<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

       
        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.books);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private IList<Book> books;
            private int currentIndex;

            public LibraryIterator(IList<Book> books)
            {
                this.books = books;
                this.currentIndex = -1;
                Reset();
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public bool MoveNext() => ++this.currentIndex < this.books.Count;

            public void Reset() => this.currentIndex = -1;

            public void Dispose()
            {
            }
        }
    }
}
