using MainProgram.Models;
using MainProgram.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MainProgram.Controllers
{
    public class acountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signinmanager;

        public acountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinmanager)
        {
            this.userManager = userManager;
            this.signinmanager = signinmanager;
        }
        [HttpGet]
      
        public IActionResult register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register(applicationUserVM newuser)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser appuser = new ApplicationUser();
                appuser.UserName = newuser.username;
                appuser.PasswordHash = newuser.password;
                appuser.address = newuser.address;
                IdentityResult result = await userManager.CreateAsync(appuser, appuser.PasswordHash);
                //add cliams when create user this means that this claims will story in database for each user 
                //List<Claim> claims = new List<Claim>();
                //claims.Add(new Claim("adult", "yes"));    
                //claims.Add(new Claim("student", "yes"));
                //userManager.AddClaimsAsync(appuser, claims);

                if (result.Succeeded)
                {

                    userManager.AddToRoleAsync(appuser, "Student");
                    // List<Claim>clams=new List<Claim>();
                    //clams.Add(new Claim ( "color", "red" ));   use clam if i want to add external info additiion to id ,name,role
                    //signinmanager.SignInWithClaimsAsync(appuser,false, clams);

                    //create cookes
                    await signinmanager.SignInAsync(appuser, false);//create coockes for each client represented in id ,name,role
                                                                    // await  signinmanager.SignOutAsync();  //  this line to remove cookes from user
                    return RedirectToAction("Index", "instructor");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }

            }


            return View(newuser);
        }
        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(applicationUserVM appuser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.UserName=appuser.username;
                user.PasswordHash = appuser.password;
                user.address=appuser.address;
              IdentityResult result=  await userManager.CreateAsync(user,user.PasswordHash);
                if(result.Succeeded)
                {
                   await userManager.AddToRoleAsync(user, "Admin");
                    //create cookes1
                   await signinmanager.SignInAsync(user, false);
                    return RedirectToAction("index","instructor");


                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }

            }



            return View(appuser);

        }
        public IActionResult logout()
        {
            //logout signinmanager
            signinmanager.SignOutAsync();
            return RedirectToAction("register");


        }

        public async Task< IActionResult> login(UserLoginVM userLlog)
        {
        
        
            if(ModelState.IsValid)
                {

                  ApplicationUser usermodel= await userManager.FindByNameAsync(userLlog.username);
                    if (usermodel != null) {
                
                     bool x=  await userManager.CheckPasswordAsync(usermodel, userLlog.password);
                        if (x)
                        {
                            await signinmanager.SignInAsync(usermodel,userLlog.rememberme);
                            return RedirectToAction("Index", "instructor");
                        }
                
                    }
                    ModelState.AddModelError("", "invalid userName or password");

                }


            return View(userLlog);        
        }
    }
}
