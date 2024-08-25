using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MainProgram.Controllers
{
        [Authorize]//to allow authorization for all action in this controller
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {//check on atributes stored as a cookes like name id role and use it in control and view using User
             var name=User.Identity.Name;
           Claim id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return Content("Welcome sir" + name+"\n and id = "+id.Value);
        }

        [AllowAnonymous]//all action in this controller will be authorize except this action
        public IActionResult show() {



            return Content("adsnflksd");
                
                }
    }
}
