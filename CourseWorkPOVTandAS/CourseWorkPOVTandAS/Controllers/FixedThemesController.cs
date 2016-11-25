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
    public class FixedThemesController : Controller
    {
        private CourseContext db = new CourseContext();

        // GET: FixedThemes
        public ActionResult Index()
        {
            var fixedThemes = db.FixedThemes.Include(f => f.Student).Include(f => f.Teacher).Include(f => f.Theme);
            return View(fixedThemes.ToList());
        }

        // GET: FixedThemes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedTheme fixedTheme = db.FixedThemes.Find(id);
            if (fixedTheme == null)
            {
                return HttpNotFound();
            }
            return View(fixedTheme);
        }

        // GET: FixedThemes/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname");
            ViewBag.ThemeId = new SelectList(db.Themes, "ThemeId", "TopicTitle");
            return View();
        }

        // POST: FixedThemes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FixedThemeId,TeacherId,StudentId,ThemeId,DateOfIssue,CompletionDate")] FixedTheme fixedTheme)
        {
            if (ModelState.IsValid)
            {
                db.FixedThemes.Add(fixedTheme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", fixedTheme.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", fixedTheme.TeacherId);
            ViewBag.ThemeId = new SelectList(db.Themes, "ThemeId", "TopicTitle", fixedTheme.ThemeId);
            return View(fixedTheme);
        }

        // GET: FixedThemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedTheme fixedTheme = db.FixedThemes.Find(id);
            if (fixedTheme == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", fixedTheme.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", fixedTheme.TeacherId);
            ViewBag.ThemeId = new SelectList(db.Themes, "ThemeId", "TopicTitle", fixedTheme.ThemeId);
            return View(fixedTheme);
        }

        // POST: FixedThemes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FixedThemeId,TeacherId,StudentId,ThemeId,DateOfIssue,CompletionDate")] FixedTheme fixedTheme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixedTheme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "Surname", fixedTheme.StudentId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Surname", fixedTheme.TeacherId);
            ViewBag.ThemeId = new SelectList(db.Themes, "ThemeId", "TopicTitle", fixedTheme.ThemeId);
            return View(fixedTheme);
        }

        // GET: FixedThemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixedTheme fixedTheme = db.FixedThemes.Find(id);
            if (fixedTheme == null)
            {
                return HttpNotFound();
            }
            return View(fixedTheme);
        }

        // POST: FixedThemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FixedTheme fixedTheme = db.FixedThemes.Find(id);
            db.FixedThemes.Remove(fixedTheme);
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
