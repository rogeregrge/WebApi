using WebApi.Dto.Author;
using WebApi.Models;

namespace WebApi.Services.Author
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor);
        Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook); 
        Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDto createAuthorDto);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditAuthorDto editAuthorDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor);
    }
}
