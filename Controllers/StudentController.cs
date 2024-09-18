using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.Repository;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class StudentController : Controller
    {
        IDepartmentRepo deptRepo; //= new DepartmentRepo();
        IStudentRepo studentRepo;//= new StudentRepo();
        public StudentController(IDepartmentRepo _deptrepo,IStudentRepo _studentRepo)
        {
            deptRepo = _deptrepo;
            studentRepo = _studentRepo;
        }

        public IActionResult Create()
        {
            ViewBag.depts=deptRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {

                studentRepo.Add(stu);
                return RedirectToAction("Index");
            }
            else
            {
                
                ViewBag.depts = deptRepo.GetAll();
                return View(stu);

            }
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Student student = studentRepo.GetById(id.Value);
            if (student == null)
                return NotFound();
            Department dept = deptRepo.GetById(student.DeptNo);

            DetailsViewModels model = new DetailsViewModels() { Student = student, Department= dept };

                 return View(model);


        }


        public IActionResult Delete(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View (student);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int CourseId)
        {
            studentRepo.DeleteByID(CourseId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            ViewBag.depts  = deptRepo.GetAll();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            
                studentRepo.Update(stu);
                ViewBag.depts = deptRepo.GetAll();
                return RedirectToAction("Index");
            
        }


        public IActionResult CheckEmail(string email)
        {
            bool emailExists = studentRepo.GetAll().Any(s => s.Email == email);
            if (emailExists)
            {
                return Json($"Email '{email}' is already taken.");
            }
            return Json(true);
        }


        public IActionResult Index()
        {
            var res = studentRepo.GetAll();
            return View(res);
        }
    }
}
