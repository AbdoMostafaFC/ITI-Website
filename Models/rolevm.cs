using System.ComponentModel.DataAnnotations;

namespace MainProgram.Models
{
    public class RoleViewModel
    {
        [Required]
        public string roleName { get; set; }
    }
}
