using WebApi.Dto.Book;
using WebApi.Models;

namespace WebApi.Services.Book
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookById(int idBook);
        Task<ResponseModel<BookModel>> GetBookByIdAuthor(int idAuthor);
        Task<ResponseModel<List<BookModel>>> CreateBook(CreateBookDto createBookDto);
        Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto editBookDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int idBook);
    }
}
