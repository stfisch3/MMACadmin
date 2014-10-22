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
    public class MACRequestsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: MACRequests
        public ActionResult Index()
        {
            return View(db.MACRequests.ToList());
        }

        // GET: MACRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MACRequest mACRequest = db.MACRequests.Find(id);
            if (mACRequest == null)
            {
                return HttpNotFound();
            }
            return View(mACRequest);
        }

        // GET: MACRequests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MACRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MACID,AccSystem,AccEnv,AccGroup,AccServer,AccDB,AccJust,isElevated,ReqSetID")] MACRequest mACRequest)
        {
            if (ModelState.IsValid)
            {
                db.MACRequests.Add(mACRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mACRequest);
        }

        // GET: MACRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MACRequest mACRequest = db.MACRequests.Find(id);
            if (mACRequest == null)
            {
                return HttpNotFound();
            }
            return View(mACRequest);
        }

        // POST: MACRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MACID,AccSystem,AccEnv,AccGroup,AccServer,AccDB,AccJust,isElevated,ReqSetID")] MACRequest mACRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mACRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mACRequest);
        }

        // GET: MACRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MACRequest mACRequest = db.MACRequests.Find(id);
            if (mACRequest == null)
            {
                return HttpNotFound();
            }
            return View(mACRequest);
        }

        // POST: MACRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MACRequest mACRequest = db.MACRequests.Find(id);
            db.MACRequests.Remove(mACRequest);
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
