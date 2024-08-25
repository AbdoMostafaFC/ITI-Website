using MainProgram.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Controllers
{
	public class instructorController : Controller
	{
		itientities context=new itientities();
		public IActionResult detals(int id)
		{

			instructor ins=context.instructors.FirstOrDefault(ins=>ins.id==id);
			return PartialView("_instructorspartial", ins);

		}
		public IActionResult show()
		{

          List<instructor>instlist = context.instructors.ToList();




			return View(instlist);
		}
		[Authorize]
		public IActionResult Index()
		{
		    List<instructor>resultmodel=context.instructors.OrderByDescending(s=>s.name).ToList();
			return View(resultmodel);
		}

		public IActionResult edit(int Id)
		{
			instructor instruct=context.instructors.FirstOrDefault(ins=>ins.id==Id);
			List<course>c=context.Courses.ToList();
			ViewBag.courses = c;

			return View(instruct);


		}


		public IActionResult saveedit(int Id,instructor inst) {
		

		     instructor intt= context.instructors.FirstOrDefault(i=>i.id==Id) ;
			intt.name=inst.name;
			intt.salary=inst.salary;
			intt.address=inst.address;
			intt.course_id=inst.course_id;
			intt.image=inst.image;
			context.SaveChanges();
            List<course> c = context.Courses.ToList();
            ViewBag.courses = c;
            return RedirectToAction("index");		
		
		}

		public IActionResult delete(int Id)
		{
			instructor intt=context.instructors.FirstOrDefault(inc=>inc.id==Id);
			context.Remove(intt);
			context.SaveChanges();
			return RedirectToAction("index");


		}
		public IActionResult add(instructor intt)
		{
			List<course> c=context.Courses.ToList();
			List<Department>dept=context.departments.ToList();
			ViewData["dept"] = dept;
			ViewData["courselist"] = c;
			return View(intt);

		}
		public IActionResult getallcourses(int Id)
		{
			List<course>cs=context.Courses.Where(c=>c.dep_id==Id).ToList();
			return Json(cs);
		}
		public IActionResult saveadd(instructor intt)
		{

			 if(intt.name==null)
			{
				List<course> c = context.Courses.ToList();
				ViewData["courselist"] = c;
                List<Department> dept = context.departments.ToList();
                ViewData["dept"] = dept;
                return RedirectToAction("add", intt);
			}
			context.instructors.Add(intt);
			context.SaveChanges();
			return RedirectToAction("index");



		}
		[HttpPost]
		public IActionResult search(string Name)
		{
			instructor instr = context.instructors.FirstOrDefault(c => c.name == Name);
			if(instr != null)
			{

				return View("search",instr);

			}

			return NotFound();


		}


		public IActionResult CreateCookies()
		{

			HttpContext.Response.Cookies.Append("name", "ahmed");
            HttpContext.Response.Cookies.Append("Age", "123");


			return Content("Cookies SAved");

		}
		public IActionResult ReadCookies()
		{
          string name = HttpContext.Request.Cookies["name"];
            string age = HttpContext.Request.Cookies["Age"];

			return Content($"the name ={name} and Age={age}");

		}
        public IActionResult CreateSession(string name)
        {

			HttpContext.Session.SetString("name", name);
            


            return Content("session  SAved");

        }
        public IActionResult ReadSession()
        {
            string name = HttpContext.Session.GetString("name");
            

            return Content($"the name ={name}");

        }
    }
}
