using System.ComponentModel.DataAnnotations;

namespace MainProgram.viewModels
{
    public class applicationUserVM
    {
        [Required]
        
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  confirmPassword { get; set; }
        public string address { get; set; }

    }
}
