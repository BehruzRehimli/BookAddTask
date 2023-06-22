using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Models
{
    public class BookImage
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public byte PhotoNumber { get; set; }
    }
}
