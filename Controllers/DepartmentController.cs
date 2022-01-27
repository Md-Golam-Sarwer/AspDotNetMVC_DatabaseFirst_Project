using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeInformationSystem.Models;

namespace EmployeeInformationSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private Entities db = new Entities();
        // GET: Department
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.BranchName = new SelectList(db.Branches, "BranchID", "BranchName");
            return View();
            
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchName = new SelectList(db.Branches, "BranchID", "BranchName", department.BranchName);
            return View(department);
        }
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchName = new SelectList(db.Branches, "BranchID", "BranchName", department.BranchName);
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {

            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchName = new SelectList(db.Branches, "BranchID", "BranchName", department.BranchName);
            return View(department);
        }
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id = 0)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
    }
}