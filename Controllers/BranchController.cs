using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmployeeInformationSystem.Models;


namespace EmployeeInformationSystem.Controllers
{
    public class BranchController : Controller
    {
        private Entities db = new Entities();
        // GET: Branch
        public ActionResult Index()
        {
            return View(db.Branches.ToList());
        }

        public ActionResult Add()
        {
            //return View();///
            return PartialView();
        }
        [HttpPost]
        public ActionResult Add(Branch branch)
        {
            if(ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index"); ////
            return PartialView("_BranchDetail", db.Branches.ToList());

        }

        public ActionResult Edit(int id)
        {
            //return View();///
            return PartialView(db.Branches.Find(id));

        }
        [HttpPost]
        public ActionResult Edit(Branch branch, int id)
        {
            if(ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index");////
            return PartialView("_BranchDetail", db.Branches.ToList());
        }

        public ActionResult Delete(int id)
        {
            db.Branches.Remove(db.Branches.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}