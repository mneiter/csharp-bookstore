using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    //You're now ready to add your first migration! Instruct EF Core to create a migration named InitialCreate:
    //dotnet ef migrations add init -p ".\BookStore.DataAccess\" -s ".\BookStore.API\"
    //Create your database and schema
    //dotnet ef database update -p.\BookStore.DataAccess\ -s.\BookStore.API\

    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;

        public BooksRepository(BookStoreDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities = await _context.Books
                .AsNoTracking()
                .ToListAsync();
                
            var books =  bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book).ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id
                ,
                Title = book.Title
                ,
                Description = book.Description
                ,
                Price = book.Price
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(i => i
                .SetProperty(b => b.Title, title)
                .SetProperty(b => b.Description, description)
                .SetProperty(b => b.Price, price));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
