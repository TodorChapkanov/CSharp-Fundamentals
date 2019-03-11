using System;
using System.Text;

namespace _02_BookShop
{
    public class Book
    {
        private string title;
        public string author;
        public decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        public string Title
        {
            get => this.title;
            set
            {
                this.ValidateTitle(value);
                this.title = value;
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                ValidateName(value);
                this.author = value;

            }
        }

        public virtual decimal Price
        {
            get => this.price;
            set
            {
                if (true)
                {
                    this.ValidatePrice(value);
                    this.price = value;
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Type: {this.GetType().Name}");
            builder.AppendLine($"Title: {this.Title}");
            builder.AppendLine($"Author: {this.Author}");
            builder.Append($"Price: {this.Price:f2}");

            return builder.ToString();
        }

        internal void ValidatePrice(decimal price)
        {
            if (price <= 0)
            {
                throw new ArgumentException(ConstantMessages.InvalidPrice);
            }
        }

        private void ValidateName(string value)
        {
            var splitedName = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (splitedName.Length>1)
            {
                if (char.IsDigit(splitedName[1][0]) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ConstantMessages.InvalidAuthorName);
                }
            }
           
        }

        private void ValidateTitle(string value)
        {
            if (value.Length < 3 || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ConstantMessages.InvalidTitle);
            }
        }
    }
}
