using System.ComponentModel.DataAnnotations;

namespace HomeworkPustok.CostumValidationAtributes
{
    public class FileIsImage:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile)
            {
                var data = (IFormFile)value;
                if (!data.ContentType.Contains("image"))
                {
                    return new ValidationResult("File Must Be Image!");
                }
            }
            else if(value is List<IFormFile> list)
            {
                foreach (var item in list)
                {
                    if (!item.ContentType.Contains("image"))
                    {
                        return new ValidationResult("File Must Be Image!");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
