using MainProgram.Models;

namespace MainProgram.Repository
{
    public interface IcourseRepository
    {



        public void add(course dept);

        public void update(int id);
        public void delete(int id);
        public List<course> getAll();
        public course GetByID(int id);
        public void save();
    }
}
