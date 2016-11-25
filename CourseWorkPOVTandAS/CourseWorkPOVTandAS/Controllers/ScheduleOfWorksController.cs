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
    public class ScheduleOfWorksController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: ScheduleOfWorks
        public ActionResult Index()
        {
            var scheduleOfWorks = db.ScheduleOfWorks.Include(s => s.AcademicPlan);
            return View(scheduleOfWorks.ToList());
        }

        // GET: ScheduleOfWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleOfWork scheduleOfWork = db.ScheduleOfWorks.Find(id);
            if (scheduleOfWork == null)
            {
                return HttpNotFound();
            }
            return View(scheduleOfWork);
        }

        // GET: ScheduleOfWorks/Create
        public ActionResult Create()
        {
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment");
            return View();
        }

        // POST: ScheduleOfWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleOfWorkId,AcademicPlanId,StageName,ProjectedDate,PlannedPercent")] ScheduleOfWork scheduleOfWork)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleOfWorks.Add(scheduleOfWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", scheduleOfWork.AcademicPlanId);
            return View(scheduleOfWork);
        }

        // GET: ScheduleOfWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleOfWork scheduleOfWork = db.ScheduleOfWorks.Find(id);
            if (scheduleOfWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", scheduleOfWork.AcademicPlanId);
            return View(scheduleOfWork);
        }

        // POST: ScheduleOfWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleOfWorkId,AcademicPlanId,StageName,ProjectedDate,PlannedPercent")] ScheduleOfWork scheduleOfWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleOfWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AcademicPlanId = new SelectList(db.AcademicPlans, "AcademicPlanId", "CodeOfDepartment", scheduleOfWork.AcademicPlanId);
            return View(scheduleOfWork);
        }

        // GET: ScheduleOfWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleOfWork scheduleOfWork = db.ScheduleOfWorks.Find(id);
            if (scheduleOfWork == null)
            {
                return HttpNotFound();
            }
            return View(scheduleOfWork);
        }

        // POST: ScheduleOfWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleOfWork scheduleOfWork = db.ScheduleOfWorks.Find(id);
            db.ScheduleOfWorks.Remove(scheduleOfWork);
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
