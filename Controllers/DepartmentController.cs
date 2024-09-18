using First_MVC_App.Data;
using First_MVC_App.Models;
using First_MVC_App.Repository;
using First_MVC_App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace First_MVC_App.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentRepo deptRepo;//=new DepartmentRepo();
        public DepartmentController(IDepartmentRepo _deptrepo)
        {
            deptRepo = _deptrepo;
        }
        //ITIContext db = new ITIContext();
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            if (ModelState.IsValid)
            {

                deptRepo.Add(dept);
                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.depts = deptRepo.GetAll();
                return View(dept);

            }
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            Department dept = deptRepo.GetById(id.Value);
            if (dept == null)
                return NotFound();

            DetailsViewModels model = new DetailsViewModels() {  Department = dept };

            return View(model);


            // return View();



            //string str =$"{dept.DeptId}:{dept.DeptName}:{dept.Capacity}";
            //return Json(dept);
            // return RedirectPermanent("http://www.google.com");
            // return Content(str);
        }
        public IActionResult Delete(int id)
        {
            var dept = deptRepo.GetById(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int deptid)
        {
            //var dept = db.Departments.SingleOrDefault(a => a.DeptId == deptid);
            //db.Departments.Remove(dept);
            //db.SaveChanges();
            deptRepo.DeleteByID(deptid);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var dept = deptRepo.GetById(id);

            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                deptRepo.Update(department);
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public IActionResult Index()
        {
            var res = deptRepo.GetAll();


            return View(res);
            //return Json(res);
        }

    }
}