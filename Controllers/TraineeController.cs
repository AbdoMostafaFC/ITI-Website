using MainProgram.Models;
using MainProgram.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MainProgram.Controllers
{
	public class TraineeController : Controller
	{
		itientities context=new itientities();
		public IActionResult Index()
		{
			List<trainee> result = context.trainees.ToList();
			return View(result);
		}
        public IActionResult edit(int id)
        {
            trainee restrain = context.trainees.FirstOrDefault(t => t.id == id);
            return View(restrain);
        }
		[HttpPost]
        public IActionResult saveedit(int id,trainee traine)
        {
            trainee restrain = context.trainees.FirstOrDefault(t => t.id == id);
			
			   restrain.name=traine.name;
				restrain.dept_id = traine.dept_id;
				restrain.address=traine.address;
				//restrain.image=traine.image;
	
				restrain.level=traine.level;
				context.SaveChanges();
			    return RedirectToAction("index");
			
			
             // return View("edit",traine);

			
        }
  ////      public IActionResult traineebyid(int id)
		////{
		////	////trainee_course_result obj= new trainee_course_result();
		////	////trainee result= context.trainees.Where(t=>t.id==id).Include(c=>c.CrsResults).FirstOrDefault();
		     
			
		////	////obj.name=result.name;
		
	
		////	////foreach (var item in result.CrsResults)
		////	////{
			
		////	////course course1=context.Courses.Where(c=>c.id==item.coure_id).FirstOrDefault();
		////	////	string nam = course1.name;
		////	////	obj.degree.Add(item.degree);
		////	////	obj.couse_name.Add(nam);
		////	////}
		////	////obj.color = "red";
		////	//foreach (var item in obj.dic)
		////	//{
		////	//	 string n=item.Key;
		////	//	int x= item.Value;
		////	//}
		////	return View(obj);
		////}
		public IActionResult ShowResult(int id,int courseid) {


			var rsult = context.crsResults.Include(c=>c.Trainee).Include(c=>c.course).FirstOrDefault(crs => crs.trainee_id == id && crs.coure_id == courseid);
			if (rsult != null)
			{
				trainee_course_result tt=new trainee_course_result();

				tt.TraineeName = rsult.Trainee.name;
				tt.CourseName = rsult.course.name;
				tt.greed = rsult.degree;
				if(rsult.degree>rsult.course.min_degree) {

					tt.color = "green";
				
				}
				else
				{
                    tt.color = "red";

                }

                  return View(tt);

            }
			return NotFound();
		
		
		
		}
		public IActionResult showCourseResult(int id)
		{
                  

              var list=context.crsResults.Include(c=>c.Trainee).Include(c=>c.course).Where(c=>c.coure_id==id).ToList();

			  return View("showCoursesResult",list);




		}
        public IActionResult showstudentResult(int id)
        {
            var list = context.crsResults.Include(c => c.Trainee).Include(c => c.course).Where(c => c.trainee_id == id).ToList();

            return View("showCoursesResult", list);




        }
    }
}
