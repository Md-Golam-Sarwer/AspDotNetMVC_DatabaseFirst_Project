using EmployeeInformationSystem.Models;
using EmployeeInformationSystem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeInformationSystem.Controllers
{
    public class SalaryController : Controller
    {
        private Entities db = new Entities();


        // GET: Salary
        public ActionResult Index()
        {
            return View(db.Salaries.ToList());
        }
        public ActionResult Add()
        {
            ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeID", "EmployeeName");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SalaryVM salaryVM)
        {
            Salary salary = new Salary();
            if (ModelState.IsValid)
            {
                salary.EmployeeName = salaryVM.EmployeeName;
                salary.BasicSalary = salaryVM.BasicSalary;
                salary.HouseRent = salaryVM.HouseRent;
                salary.TotalSalary = salaryVM.TotalSalary;
                salary.IsActive = salaryVM.IsActive;

                db.Salaries.Add(salary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeID", "EmployeeName", salaryVM.EmployeeName);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            Salary salary = db.Salaries.Find(id);
            if (salary == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeID", "EmployeeName", salary.ToString());
            return View(salary);
        }
        [HttpPost]
        public ActionResult Edit(Salary salary)
        {

            if (ModelState.IsValid)
            {
                db.Entry(salary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeID", "EmployeeName", salary.ToString());
            return View(salary);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Salary salary = db.Salaries.SingleOrDefault(s => s.SalaryID == id);
            var salaryVM = new SalaryVM();
            salaryVM.EmployeeName = salary.EmployeeName.Value;
            salaryVM.BasicSalary = salary.BasicSalary.Value;
            salaryVM.HouseRent = salary.HouseRent.Value;
            salaryVM.HouseRent = salary.TotalSalary.Value;
            salaryVM.IsActive = salary.IsActive;
            return View(salaryVM);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SalaryVM salaryVM, int id)
        {

            Salary salary = db.Salaries.Find(id);
            if (salary != null)
            {
                db.Salaries.Remove(salary);



                db.SaveChanges();

            }
            ViewBag.EmployeeName = new SelectList(db.Employees, "EmployeeID", "EmployeeName", salary.ToString());
            return RedirectToAction("Index");

        }

        public ActionResult Details(int id)
        {

            Salary salary = db.Salaries.SingleOrDefault(s => s.SalaryID == id);
            var salaryVM = new SalaryVM();
            salaryVM.EmployeeName = salary.EmployeeName.Value;
            salaryVM.BasicSalary = salary.BasicSalary.Value;
            salaryVM.HouseRent = salary.HouseRent.Value;
            salaryVM.HouseRent = salary.TotalSalary.Value;
            salaryVM.IsActive = salary.IsActive;
            return View(salaryVM);

        }
    }
}