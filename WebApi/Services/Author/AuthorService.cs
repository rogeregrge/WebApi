using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dto.Author;
using WebApi.Models;

namespace WebApi.Services.Author
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int idAuthor)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor);

                if (author == null)
                {
                    response.Messages = "Author not found.";
                    return response;
                }
                response.Data = author;
                response.Messages = "Author retrieved successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByIdBook(int idBook)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books
                    .Include(a => a.Author)
                    .FirstOrDefaultAsync(BankBook => BankBook.Id == idBook);

                if (book == null)
                {
                    response.Messages = "Author not found for the given book.";
                    return response;
                }
                response.Data = book.Author;
                response.Messages = "Author retrieved successfully.";
                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var authors = await _context.Authors.ToListAsync();
                response.Data = authors;
                response.Messages = "Authors retrieved successfully.";

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;

                return response;
            }
        }
        public async Task<ResponseModel<List<AuthorModel>>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = new AuthorModel()
                {
                    Name = createAuthorDto.Name,
                    Surname = createAuthorDto.Surname
                };

                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Messages = "Author created successfully.";

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditAuthorDto editAuthorDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorBank => authorBank.Id == editAuthorDto.Id);

                if (author == null)
                {
                    response.Messages = "Author not found.";
                    return response;
                }
                author.Name = editAuthorDto.Name;
                author.Surname = editAuthorDto.Surname;

                _context.Update(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Messages = "Author edited successfully!";

                return response;
            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int idAuthor)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors
                    .FirstOrDefaultAsync(authorBank => authorBank.Id == idAuthor);
                
                if (author == null)
                {
                    response.Messages = "Author not found.";
                    return response;
                }
                _context.Remove(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Messages = "Author deleted successfully.";

                return response;

            }
            catch (Exception ex)
            {
                response.Messages = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
