using First_MVC_App.Models;
using First_MVC_App.Repository;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC_App.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepo courseRepo;
        IDepartmentRepo deptRepo;

        public CourseController(ICourseRepo _courseRepo, IDepartmentRepo _deptRepo)
        {
            courseRepo = _courseRepo;
            deptRepo = _deptRepo;
        }

        public IActionResult Create()
        {
            ViewBag.depts = deptRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            courseRepo.Add(course);
            ViewBag.depts = deptRepo.GetAll();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
                return NotFound();
            ViewBag.depts = deptRepo.GetAll();
            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Update(course);
                return RedirectToAction("Index");
            }
            ViewBag.depts = deptRepo.GetAll();
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = courseRepo.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int CourseId)
        {
            var course = courseRepo.GetById(CourseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            courseRepo.DeleteByID(CourseId);
            return RedirectToAction("Index");
        }




        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Course course = courseRepo.GetById(id.Value);
            if (course == null)
                return NotFound();

            DetailsViewModels model = new DetailsViewModels() { Course = course };

            return View(model);
        }
        public IActionResult Index()
        {
            var courses = courseRepo.GetAll();
            return View(courses);
        }
    }
}
