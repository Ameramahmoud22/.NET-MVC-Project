using First_MVC_App.Data;
using First_MVC_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace First_MVC_App.Repository
{
    public interface ICourseRepo
    {
        List<Course> GetAll();
        void DeleteByID(int id);
        void Add(Course course);
        Course GetById(int id);
        void Update(Course course);
    }

    public class CourseRepo : ICourseRepo
    {
        ITIContext db;

        public CourseRepo(ITIContext _db)
        {
            db = _db;
        }

        public void Add(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void DeleteByID(int CourseId)
        {
            var course = db.Courses.FirstOrDefault(a => a.CourseId == CourseId);
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course), "Course not found in the database.");
            }

            db.Courses.Remove(course);
            db.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(a => a.CourseId == id);
        }

        public void Update(Course course)
        {
            db.Courses.Update(course);
            db.SaveChanges();
        }
    }
}
