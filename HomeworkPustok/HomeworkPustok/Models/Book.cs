
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeworkPustok.CostumValidationAtributes;
namespace HomeworkPustok.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        [Required]
        [MaxLength(60)]
        public string Title { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        public byte Discount { get; set; } = 0;
        public bool Availability { get; set; } = true;
        public int RewardPoint { get; set; }
        [Required]
        public string Desc { get; set; }
        public List<BookImage> Images { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        [NotMapped]
        public List<int> TagsIds { get; set; }=new List<int>();
        public bool IsFeature { get; set; } = false;
        [FileIsImage]
        [NotMapped]
        public IFormFile MainImage { get; set; }
        [FileIsImage]
        [NotMapped]
        public IFormFile SecondImage { get; set; }
        [FileIsImage]
        [NotMapped]
        public List<IFormFile> MoreImageis { get; set; }=new List<IFormFile>();
        public List<BookTag> BookTag { get; set; }= new List<BookTag>();
    }
}
