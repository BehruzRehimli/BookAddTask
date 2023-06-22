using HomeworkPustok.CostumValidationAtributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkPustok.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title1 { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title2 { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        [Required]
        [MaxLength(50)]
        public string Des { get; set; }

        public byte SlideLocation { get; set; }
        [NotMapped]
        [FileIsImage]
        public IFormFile ImageFile { get; set; }


    }
}
