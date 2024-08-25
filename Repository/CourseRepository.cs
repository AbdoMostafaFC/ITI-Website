using MainProgram.Models;

namespace MainProgram.Repository
{
    public class CourseRepository:IcourseRepository
    {
        itientities contexit=new itientities();
       

        public course GetByID(int id)
        {
            course course = contexit.Courses.FirstOrDefault(c => c.id == id);
            return course;

        }
        public void delete(int id)
        {
            contexit.Remove(GetByID(id));

        }
        public void add(course c)
        {
            contexit.Add(c);

        }
        public void update(int couid) {
           course c= GetByID(couid);
            contexit.Update(c);
        }
       public void save()
            {

                contexit.SaveChanges();
            }

     
        public List<course> getAll()
        {
            return contexit.Courses.ToList();

        }
    }
}
