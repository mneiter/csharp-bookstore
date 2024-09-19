using BookStore.API.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            this._booksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBooks()
        {
            try
            {
                var books = await _booksService.GetAllBooks();
                var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<BooksResponse>>> CreateBook([FromBody] BooksRequest request)
        {
            try
            {
                var (book, error) = Book.Create(Guid.NewGuid(), request.Title, request.Description, request.Price);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var bookId = await _booksService.CreateBook(book);

                return Ok(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<List<BooksResponse>>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            try
            {               
                var bookId = await _booksService.UpdateBook(id, request.Title, request.Description, request.Price);

                return Ok(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<List<BooksResponse>>> DeleteBook(Guid id)
        {
            try
            {
                var bookId = await _booksService.DeleteBook(id);

                return Ok(bookId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}