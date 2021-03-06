﻿namespace _04_BookComparator
{
    using System.Collections;
    using System.Collections.Generic;


    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator() => this.books.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
