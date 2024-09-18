using First_MVC_App.Data;
using First_MVC_App.Models;

namespace First_MVC_App.Repository
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAll();
       public void DeleteByID(int id);
       public void Add(Department department);
       public Department GetById(int id);
       public void Update(Department department);
    }
    public class DepartmentRepo : IDepartmentRepo
    {
       
        ITIContext db;// = new ITIContext();
        public DepartmentRepo(ITIContext _db) 
        {
            db = _db;
        }
        public void Add(Department department)
        {
            db.Add(department);
            db.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var dept =db.Departments.FirstOrDefault(a => a.DeptId == id);

            
            dept.DeptStatus = true;
            db.SaveChanges();
        }

        public List<Department> GetAll()
        {
           return db.Departments.Where(a => a.DeptStatus == false).ToList();
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
        
        }
    }
    public class DepartmentRepo2 : IDepartmentRepo
    {
       static  List<Department> db = new List<Department>();
        public void Add(Department department)
        {
            db.Add(department);
        }

        public void DeleteByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            return db;
        }

        public Department GetById(int id)
        {
            return db.FirstOrDefault(a => a.DeptId == id);
        }

        public void Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
