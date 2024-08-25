using MainProgram.Models;
using MainProgram.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MainProgram.Controllers
{
    public class courseController : Controller
    {
        private readonly IDepatmentRepository deptartment;
        private readonly IcourseRepository _courses;

        public courseController( IcourseRepository cor,IDepatmentRepository dept)
        {
            this.deptartment = dept;//new RepositoryDepartment();
            this._courses = cor;//new CourseRepository();
        }
        public IActionResult Index()
        {
            List<course> courseList =_courses.getAll();
            
            return View(courseList);

        }
       
        public IActionResult add()
        {

            List<Department> dept=deptartment.getALl();
            ViewData["dept"] = dept;

            return View();
        }

        public IActionResult SaveAdd(course c) {
            if (ModelState.IsValid)
            {


                //contex.Add(c);
                _courses.add(c);
                ////contex.SaveChanges();
                _courses.save();
               
                return RedirectToAction("Index");
            }
              List<Department> dept=deptartment.getALl();
            ViewData["dept"] = dept;
            return View("add",c);
        }
        public IActionResult checkdegree(int min_degree,int degree)
        {
            if(min_degree<degree)
            {

                return Json(true);
            }
            else
            {
                return Json("invlaide min-degree");
            }


        }
        public IActionResult checkHoure(int houres,int dept_id)
        {
            if (dept_id %2==0 && houres%2==0  )
            {

                return Json(true);

            }
            else
            {
                return Json("invlaide hourse /2");
            }
             if(dept_id%3==0&&houres%3==0) 
            {
                return Json(true);
            }
            else
            {

                return Json("invlaide hours number for this /3");
            }

        }
        public IActionResult edit(int  id)
        {
            course cour = _courses.GetByID(id);//contex.Courses.FirstOrDefault(c=>c.id==id);
            ViewBag.dept = deptartment.getALl();// contex.departments.ToList();
            return View(cour);

        }
        [HttpPost]
        public IActionResult saveedit(int id,course reslt)
        {
            ViewBag.dept = deptartment.getALl(); //contex.departments.ToList();

            course cour = _courses.GetByID(id);//contex.Courses.FirstOrDefault(c => c.id == id);
          
            
                cour.name = reslt.name;
                cour.degree = reslt.degree;
                cour.min_degree = reslt.min_degree;
                cour.dep_id = reslt.dep_id;
            ////contex.SaveChanges();
            _courses.save();
              //  RedirectToAction("index");

            
            return View("edit",reslt);


        }
    }
}
