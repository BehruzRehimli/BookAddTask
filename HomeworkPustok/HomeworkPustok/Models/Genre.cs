using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Genre adin uzunlugu 30 simvoldan chox ola bilmez!")]
        public string Name { get; set; }
        public List<Book> Books { get; set; }=new List<Book>();
    }
}
