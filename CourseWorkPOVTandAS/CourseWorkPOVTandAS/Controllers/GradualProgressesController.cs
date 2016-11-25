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
    public class GradualProgressesController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: GradualProgresses
        public ActionResult Index()
        {
            var listGradualProgress = db.ListGradualProgress.Include(g => g.FixedTheme).Include(g => g.ScheduleOfWork);
            return View(listGradualProgress.ToList());
        }

        // GET: GradualProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradualProgress gradualProgress = db.ListGradualProgress.Find(id);
            if (gradualProgress == null)
            {
                return HttpNotFound();
            }
            return View(gradualProgress);
        }

        // GET: GradualProgresses/Create
        public ActionResult Create()
        {
            ViewBag.FixedThemeId = new SelectList(db.FixedThemes, "FixedThemeId", "FixedThemeId");
            ViewBag.ScheduleOfWorkId = new SelectList(db.ScheduleOfWorks, "ScheduleOfWorkId", "StageName");
            return View();
        }

        // POST: GradualProgresses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradualProgressId,ScheduleOfWorkId,FixedThemeId,ActualPercent,CompletionDate,Mark")] GradualProgress gradualProgress)
        {
            if (ModelState.IsValid)
            {
                db.ListGradualProgress.Add(gradualProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FixedThemeId = new SelectList(db.FixedThemes, "FixedThemeId", "FixedThemeId", gradualProgress.FixedThemeId);
            ViewBag.ScheduleOfWorkId = new SelectList(db.ScheduleOfWorks, "ScheduleOfWorkId", "StageName", gradualProgress.ScheduleOfWorkId);
            return View(gradualProgress);
        }

        // GET: GradualProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradualProgress gradualProgress = db.ListGradualProgress.Find(id);
            if (gradualProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.FixedThemeId = new SelectList(db.FixedThemes, "FixedThemeId", "FixedThemeId", gradualProgress.FixedThemeId);
            ViewBag.ScheduleOfWorkId = new SelectList(db.ScheduleOfWorks, "ScheduleOfWorkId", "StageName", gradualProgress.ScheduleOfWorkId);
            return View(gradualProgress);
        }

        // POST: GradualProgresses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradualProgressId,ScheduleOfWorkId,FixedThemeId,ActualPercent,CompletionDate,Mark")] GradualProgress gradualProgress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradualProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FixedThemeId = new SelectList(db.FixedThemes, "FixedThemeId", "FixedThemeId", gradualProgress.FixedThemeId);
            ViewBag.ScheduleOfWorkId = new SelectList(db.ScheduleOfWorks, "ScheduleOfWorkId", "StageName", gradualProgress.ScheduleOfWorkId);
            return View(gradualProgress);
        }

        // GET: GradualProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradualProgress gradualProgress = db.ListGradualProgress.Find(id);
            if (gradualProgress == null)
            {
                return HttpNotFound();
            }
            return View(gradualProgress);
        }

        // POST: GradualProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradualProgress gradualProgress = db.ListGradualProgress.Find(id);
            db.ListGradualProgress.Remove(gradualProgress);
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
