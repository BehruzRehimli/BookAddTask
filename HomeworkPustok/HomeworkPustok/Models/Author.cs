using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
