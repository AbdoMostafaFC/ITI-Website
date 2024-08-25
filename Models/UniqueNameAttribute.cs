using System.ComponentModel.DataAnnotations;

namespace MainProgram.Models
{
    public class UniqueNameAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           itientities context= new itientities();
            string name = value.ToString();
            course inst = context.Courses.FirstOrDefault(c=>c.name==name);
            if(inst == null) {
                return ValidationResult.Success;
            
            }
            return new ValidationResult("invalide name");

        }
    }
}
