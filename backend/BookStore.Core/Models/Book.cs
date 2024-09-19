using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 256;

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public decimal Price { get; }

        private Book(Guid id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }

        public static (Book Book, string Error) Create(Guid id, string title, string description, decimal price)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(title) && title.Length < MAX_TITLE_LENGTH)
            {
                error = $"The title cannot be empty and longer than {MAX_TITLE_LENGTH} characters.";
            }
            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
