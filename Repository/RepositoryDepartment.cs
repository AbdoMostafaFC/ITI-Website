using MainProgram.Models;

namespace MainProgram.Repository
{
    public class RepositoryDepartment:IDepatmentRepository
    {


       //itientities context= new itientities();
        private readonly itientities iti;

        public RepositoryDepartment(itientities iti)
        {
            this.iti = iti;
        }
        public void add(Department newdept)
        {

            iti.Add(newdept);
        }

        public void update(int id)
        {
            Department dept=GetByID(id);
            iti.Update(dept);
        }

        public void delete(int id)
        {
            Department department = GetByID(id);
            iti.Remove(department);
        }

        public List<Department> getALl()
        {
            return iti.departments.ToList();
        }

        public Department GetByID(int id)
        {
            return iti.departments.FirstOrDefault(d => d.id == id);
        }
        public void save()
        {

            iti.SaveChanges();
        }
    }
}
