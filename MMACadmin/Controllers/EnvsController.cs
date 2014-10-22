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
    public class EnvsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Envs
        public ActionResult Index()
        {
            return View(db.Envs.ToList());
        }

        // GET: Envs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Envs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnvName")] Env env)
        {
            if (ModelState.IsValid)
            {
                db.Envs.Add(env);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(env);
        }

        // GET: Envs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Env env = db.Envs.Find(id);
            if (env == null)
            {
                return HttpNotFound();
            }
            return View(env);
        }

        // POST: Envs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnvID,EnvName")] Env env)
        {
            if (ModelState.IsValid)
            {
                db.Entry(env).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(env);
        }

        // GET: Envs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Env env = db.Envs.Find(id);
            if (env == null)
            {
                return HttpNotFound();
            }
            return View(env);
        }

        // POST: Envs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Env env = db.Envs.Find(id);
            db.Envs.Remove(env);
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
