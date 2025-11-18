using WebApi.Dto.Book.Bond;
using WebApi.Models;

namespace WebApi.Dto.Book
{
    public class EditBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorBondDto Author { get; set; }
    }
}
