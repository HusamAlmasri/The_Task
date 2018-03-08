using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cloud_Connectiv_Task.Context;
using Cloud_Connectiv_Task.Models;

namespace Cloud_Connectiv_Task.Controllers
{
    public class TODO_MIRRORController : Controller
    {
        private TODOContext db = new TODOContext();

        // GET: TODO_MIRROR
        public ActionResult Index()
        {
            return View(db.TODO_MIRRORS.ToList());
        }

        // GET: TODO_MIRROR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            TODO tODO = db.TODOS.Find(id);
            if (tODO_MIRROR == null && tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO_MIRROR);
        }

        // GET: TODO_MIRROR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODO_MIRROR/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION")] TODO_MIRROR tODO_MIRROR , TODO tODO)
        {
            if (ModelState.IsValid)
            {
                db.TODO_MIRRORS.Add(tODO_MIRROR);
                db.TODOS.Add(tODO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tODO_MIRROR);
        }

        // GET: TODO_MIRROR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            TODO tODO = db.TODOS.Find(id);
            if (tODO_MIRROR == null && tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO_MIRROR);
        }

        // POST: TODO_MIRROR/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION")] TODO_MIRROR tODO_MIRROR , TODO tODO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tODO_MIRROR).State = EntityState.Modified;
                db.Entry(tODO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tODO_MIRROR);
        }

        // GET: TODO_MIRROR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            TODO tODO = db.TODOS.Find(id);
            if (tODO_MIRROR == null && tODO == null)
            {
                return HttpNotFound();
            }
            return View(tODO_MIRROR);
        }

        // POST: TODO_MIRROR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            TODO tODO = db.TODOS.Find(id);
            db.TODO_MIRRORS.Remove(tODO_MIRROR);
            db.TODOS.Remove(tODO);
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
