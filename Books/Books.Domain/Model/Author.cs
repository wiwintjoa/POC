using System.ComponentModel.DataAnnotations;

namespace Books.Domain.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
