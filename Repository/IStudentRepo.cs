using First_MVC_App.Data;
using First_MVC_App.Models;

namespace First_MVC_App.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAll();
        public void DeleteByID(int id);
        public void Add(Student stu);
        public Student GetById(int id);
        public void Update(Student stu);
    }
    public class StudentRepo : IStudentRepo
    {
        ITIContext db;
        public StudentRepo(ITIContext _db) 
        {
            db=_db;
        }
        public void Add(Student stu)
        {
            db.Add(stu);
            db.SaveChanges();
        }


        public List<Student> GetAll()
        {
            return db.Students.Where(a => a.StuStatus == false).ToList();
        }
        public void DeleteByID(int id)
        {
            var stu = GetById(id);
            stu.StuStatus = true;
            db.SaveChanges();
        }

        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Student stu)
        {
            db.Students.Update(stu);
            db.SaveChanges();
        }
    }
}
