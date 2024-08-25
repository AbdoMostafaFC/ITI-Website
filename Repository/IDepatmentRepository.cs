using MainProgram.Models;

namespace MainProgram.Repository
{
    public interface IDepatmentRepository
    {

        public void add(Department dept);
       
        public void update(int id);
        public void delete(int id);
        public List<Department> getALl();
        public Department GetByID(int id);
        public void save();


    }
}
