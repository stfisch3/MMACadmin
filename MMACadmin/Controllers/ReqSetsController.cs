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
    public class ReqSetsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ReqSets
        public ActionResult Index()
        {
            return View(db.ReqSets.ToList());
        }

        // GET: ReqSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqSet reqSet = db.ReqSets.Find(id);
            if (reqSet == null)
            {
                return HttpNotFound();
            }
            return View(reqSet);
        }

        // GET: ReqSets/CreateGroup
        public ActionResult CreateGroup()
        {
            return View();
        }
        // GET: ReqSets/CreateProject
        public ActionResult CreateProject()
        {
            return View();
        }

        // POST: ReqSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ReleaseID,GroupID,DateCreated,DateModified,RoleID,EnvID")] ReqSet reqSet)
        {
            if (ModelState.IsValid)
            {
                db.ReqSets.Add(reqSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reqSet);
        }

        // GET: ReqSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqSet reqSet = db.ReqSets.Find(id);
            if (reqSet == null)
            {
                return HttpNotFound();
            }
            return View(reqSet);
        }

        // POST: ReqSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReqSetID,ProjectID,ReleaseID,GroupID,DateCreated,DateModified,RoleID,EnvID")] ReqSet reqSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reqSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reqSet);
        }

        // GET: ReqSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReqSet reqSet = db.ReqSets.Find(id);
            if (reqSet == null)
            {
                return HttpNotFound();
            }
            return View(reqSet);
        }

        // POST: ReqSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReqSet reqSet = db.ReqSets.Find(id);
            db.ReqSets.Remove(reqSet);
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
