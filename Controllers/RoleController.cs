using MainProgram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Controllers
{
    [Authorize(Roles="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rollemanager;

        public RoleController(RoleManager<IdentityRole>rollemanager)
        {
            this.rollemanager = rollemanager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult newR()
        {


            return View();
        }
        [HttpPost]
        public async Task< IActionResult> newR(RoleViewModel newrole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole();
                identityRole.Name=newrole.roleName;
             IdentityResult result=   await rollemanager.CreateAsync(identityRole);
                if(result.Succeeded)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item  in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }

                }

            }

            return View(newrole);
        }
    }
}
