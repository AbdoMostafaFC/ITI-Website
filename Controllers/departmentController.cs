using MainProgram.Models;
using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Controllers
{
	public class departmentController : Controller
	{
		itientities context = new itientities();
		public IActionResult Index()
		{
			List<Department> departmentList = context.departments.ToList();
			return View(departmentList);
		}
		public IActionResult showcousesindepartment(int deptid)
		{
              List<course>courses=context.Courses.Where(c=>c.dep_id==deptid).ToList();
			return Json(courses);


		}
		public IActionResult departmentbyid(int id)
		{
			Department dept = context.departments.FirstOrDefault(d => d.id == id);

			return View(dept);

		}
		
		public IActionResult newdept(Department de)
		{
			

           return View(de);
		}
		public IActionResult savenewdept(Department dept)
		{
			if (dept.name != null)
			{


				context.departments.Add(dept);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return RedirectToAction("newdept", dept);
    	}
		public IActionResult edit(int id)
		{
		 Department dept=context.departments.FirstOrDefault(d => d.id == id);

			return View(dept);
		}
		public IActionResult saveedit(int id, Department dept)
		{
			var deptartment=context.departments.FirstOrDefault(de => de.id == id);
		
			
				 deptartment.name= dept.name;
				deptartment.manager= dept.manager;
			context.SaveChanges();

				return RedirectToAction("Index");
			
		
		}

    }
}
