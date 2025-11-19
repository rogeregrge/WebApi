using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Author;
using WebApi.Models;
using WebApi.Services.Author;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("ListAuthors")]
        [Authorize]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> ListAuthors()
        {
            var authors = await _authorInterface.ListAuthors();
            return Ok(authors);
        }

        [HttpGet("GetAuthorById/{idAuthor}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int idAuthor)
        {
            var author = await _authorInterface.GetAuthorById(idAuthor);
            return Ok(author);
        }

        [HttpGet("GetAuthorByIdBook/{idBook}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByIdBook(int idBook)
        {
            var author = await _authorInterface.GetAuthorByIdBook(idBook);
            return Ok(author);
        }
        [HttpPost("CreateAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var authors = await _authorInterface.CreateAuthor(createAuthorDto);
            return Ok(authors);
        }
        [HttpPut("EditAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> EditAuthor(EditAuthorDto editAuthorDto)
        {
            var authors = await _authorInterface.EditAuthor(editAuthorDto);
            return Ok(authors);
        }

        [HttpDelete("DeleteAuthor")]

        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int idAuthor)
        {
            var authors = await _authorInterface.DeleteAuthor(idAuthor);
            return Ok(authors);
        }

    }
}
