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
    public class TODOController : Controller
    {
        private TODOContext db = new TODOContext();



        // GET: TODO
        public ActionResult Index()
        {
            return View(db.TODOS.ToList());
        }

        // GET: TODO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOS.Find(id);
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            if (tODO == null && tODO_MIRROR == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // GET: TODO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TODO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

          [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION")] TODO tODO , TODO_MIRROR tODO_MIRROR)
        {
            if (ModelState.IsValid)
            {
                db.TODOS.Add(tODO);
                db.TODO_MIRRORS.Add(tODO_MIRROR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tODO);
            
        } 

    

        // GET: TODO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOS.Find(id);
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            
            if (tODO == null && tODO_MIRROR == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // POST: TODO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION")] TODO tODO , TODO_MIRROR tODO_MIRROR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tODO).State = EntityState.Modified;
                db.Entry(tODO_MIRROR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tODO);
        }

        // GET: TODO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TODO tODO = db.TODOS.Find(id);
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            if (tODO == null && tODO_MIRROR == null)
            {
                return HttpNotFound();
            }
            return View(tODO);
        }

        // POST: TODO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TODO tODO = db.TODOS.Find(id);
            TODO_MIRROR tODO_MIRROR = db.TODO_MIRRORS.Find(id);
            db.TODOS.Remove(tODO);
            db.TODO_MIRRORS.Remove(tODO_MIRROR);
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
