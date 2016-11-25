using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseWorkPOVTandAS.Models;

namespace CourseWorkPOVTandAS.Controllers
{
    public class AcademicPlansController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: AcademicPlans
        public ActionResult Index()
        {
            var academicPlans = db.AcademicPlans.Include(a => a.Speciality);
            return View(academicPlans.ToList());
        }

        // GET: AcademicPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            return View(academicPlan);
        }

        // GET: AcademicPlans/Create
        public ActionResult Create()
        {
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Name");
            return View();
        }

        // POST: AcademicPlans/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AcademicPlanId,CodeOfDepartment,ItemName,SpecialityId,YearOfSet,Semester,StatementForm")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                db.AcademicPlans.Add(academicPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Name", academicPlan.SpecialityId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Name", academicPlan.SpecialityId);
            return View(academicPlan);
        }

        // POST: AcademicPlans/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AcademicPlanId,CodeOfDepartment,ItemName,SpecialityId,YearOfSet,Semester,StatementForm")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Name", academicPlan.SpecialityId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            return View(academicPlan);
        }

        // POST: AcademicPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AcademicPlan academicPlan = db.AcademicPlans.Find(id);
            db.AcademicPlans.Remove(academicPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
