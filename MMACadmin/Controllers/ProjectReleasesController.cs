using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MMACadmin.Models;

namespace MMACadmin.Controllers
{
    public class ProjectReleasesController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ProjectReleases
        public ActionResult Index()
        {
            return View(db.ProjectReleases.ToList());
        }

        // GET: ProjectReleases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRelease projectRelease = db.ProjectReleases.Find(id);
            if (projectRelease == null)
            {
                return HttpNotFound();
            }
            return View(projectRelease);
        }

        // GET: ProjectReleases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReleaseID,ReleaseName,DateCreated,Owner,BackUpOwner,ProjectID")] ProjectRelease projectRelease)
        {
            if (ModelState.IsValid)
            {
                db.ProjectReleases.Add(projectRelease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectRelease);
        }

        // GET: ProjectReleases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRelease projectRelease = db.ProjectReleases.Find(id);
            if (projectRelease == null)
            {
                return HttpNotFound();
            }
            return View(projectRelease);
        }

        // POST: ProjectReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReleaseID,ReleaseName,DateCreated,Owner,BackUpOwner,ProjectID")] ProjectRelease projectRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectRelease);
        }

        // GET: ProjectReleases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectRelease projectRelease = db.ProjectReleases.Find(id);
            if (projectRelease == null)
            {
                return HttpNotFound();
            }
            return View(projectRelease);
        }

        // POST: ProjectReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectRelease projectRelease = db.ProjectReleases.Find(id);
            db.ProjectReleases.Remove(projectRelease);
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
