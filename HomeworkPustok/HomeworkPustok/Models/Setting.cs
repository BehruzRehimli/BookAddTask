
using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
