using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Author;
using WebApi.Dto.Book;
using WebApi.Models;
using WebApi.Services.Author;
using WebApi.Services.Book;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        public BookController(IBookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }

        [HttpGet("ListBooks")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var books = await _bookInterface.ListBooks();
            return Ok(books);
        }

        [HttpGet("GetBookById/{idBook}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetAuthorById(int idBook)
        {
            var book = await _bookInterface.GetBookById(idBook);
            return Ok(book);
        }

        [HttpGet("GetBookByIdAuthor/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByIdAuthor(int idAuthor)
        {
            var book = await _bookInterface.GetBookByIdAuthor(idAuthor);
            return Ok(book);
        }
        [HttpPost("CreateBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateBook(CreateBookDto createBookDto)
        {
            var book = await _bookInterface.CreateBook(createBookDto);
            return Ok(book);
        }
        [HttpPut("EditBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> EditBook(EditBookDto editBookDto)
        {
            var books = await _bookInterface.EditBook(editBookDto);
            return Ok(books);
        }

        [HttpDelete("DeleteBook")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int idBook)
        {
            var books = await _bookInterface.DeleteBook(idBook);
            return Ok(books);
        }
    }
}
