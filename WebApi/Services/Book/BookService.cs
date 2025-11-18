using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Author;
using WebApi.Dto.Book;
using WebApi.Models;

namespace WebApi.Services.Book
{
    public class BookService : IBookInterface
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDto createBookDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorBank => authorBank.Id == createBookDto.Author.Id);
                if (author == null)
                {
                    response.Messages = "No Author found with the given ID.";
                    return response;
                }
                var book = new BookModel
                {
                    Title = createBookDto.Title,
                    Author = author
                };

                _context.Add(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.Include(a => a.Author).ToListAsync();

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }
        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
                var book = await _context.Books.Include(a => a.Author)
                    .FirstOrDefaultAsync(bookBank => bookBank.Id == idBook);

                if (book == null)
                {
                    response.Messages = "Author not found.";
                    return response;
                }
                _context.Remove(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.ToListAsync();
                response.Messages = "Book deleted successfully.";

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto editBookDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();

            try
            {
               var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(bookBank => bookBank.Id == editBookDto.Id);

                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorBank => authorBank.Id == editBookDto.Author.Id);
                
                if (book == null)
                {
                    response.Messages = "Book not found.";
                    return response;
                }
                if (author == null)
                {
                    response.Messages = "No Author found with the given ID.";
                    return response;
                }
                book.Title = editBookDto.Title;
                book.Author = author;
                _context.Update(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                response.Messages = "Book updated successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int idBook)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author)
                    .FirstOrDefaultAsync(bookBank => bookBank.Id == idBook);

                if (book == null)
                {
                    response.Messages = "Book not found.";
                    return response;
                }
                response.Data = book;
                response.Messages = "Book retrieved successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBookByIdAuthor(int idAuthor)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .Where(bookBank => bookBank.Author.Id == idAuthor)
                    .ToListAsync();

                if (book == null)
                {
                    response.Messages = "Book not found for the given Author.";
                    return response;
                }
                response.Data = book;
                response.Messages = "Book retrieved successfully.";
                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).ToListAsync();
                response.Data = book;
                response.Messages = "Book retrieved successfully.";

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;

                return response;
            }
        }

        Task<ResponseModel<BookModel>> IBookInterface.GetBookByIdAuthor(int idAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
