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
    public class SessionResultsController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: SessionResults
        public ActionResult Index()
        {
            var sessionResults = db.SessionResults.Include(s => s.AcademicPlan).Include(s => s.Student).Include(s => s.Teacher);
            return View(sessionResults.ToList());
        }

        // GET: SessionResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionResult sessionResult = db.SessionResults.Find(id);
            if (sessionResult == null)
            {
                return HttpNotFound();
            }
            return View(sessionResult);
        }

        // GET: SessionResults/Create
        public ActionResult Create()
        {
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname");
            return View();
        }

        // POST: SessionResults/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionResultId,AcademicPlanId,StudentId,TeacherId,Date,Mark")] SessionResult sessionResult)
        {
            if (ModelState.IsValid)
            {
                db.SessionResults.Add(sessionResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", sessionResult.AcademicPlanId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", sessionResult.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", sessionResult.TeacherId);
            return View(sessionResult);
        }

        // GET: SessionResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionResult sessionResult = db.SessionResults.Find(id);
            if (sessionResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", sessionResult.AcademicPlanId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", sessionResult.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", sessionResult.TeacherId);
            return View(sessionResult);
        }

        // POST: SessionResults/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionResultId,AcademicPlanId,StudentId,TeacherId,Date,Mark")] SessionResult sessionResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessionResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", sessionResult.AcademicPlanId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", sessionResult.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", sessionResult.TeacherId);
            return View(sessionResult);
        }

        // GET: SessionResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SessionResult sessionResult = db.SessionResults.Find(id);
            if (sessionResult == null)
            {
                return HttpNotFound();
            }
            return View(sessionResult);
        }

        // POST: SessionResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SessionResult sessionResult = db.SessionResults.Find(id);
            db.SessionResults.Remove(sessionResult);
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
