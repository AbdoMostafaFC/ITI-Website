using Microsoft.AspNetCore.Identity;

namespace MainProgram.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string address { get; set; }


    }
}
