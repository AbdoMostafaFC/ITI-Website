using System.ComponentModel.DataAnnotations;

namespace MainProgram.Models
{
    public class dividby3: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            itientities context = new itientities();
            int houres =(int) value;
           // course inst = context.Courses.FirstOrDefault(c => c.name == name);
            if (houres%3==0)
            {
                return ValidationResult.Success;

            }
            return new ValidationResult("invalide course hourse");

        }


    }
}
