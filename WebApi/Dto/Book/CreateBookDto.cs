using WebApi.Dto.Book.Bond;
using WebApi.Models;

namespace WebApi.Dto.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }

        public AuthorBondDto Author { get; set; }
    }
}
