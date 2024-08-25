using System.ComponentModel.DataAnnotations;

namespace MainProgram.Models
{
    public class UserLoginVM
    {
        [Required]
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool rememberme { get; set; }
    }
}
