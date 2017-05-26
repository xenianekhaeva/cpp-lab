using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Entities;
using DAL.Repository.Interface;

namespace WebUI.Controllers
{
    public class VisitorsController : Controller
    {
        private IVisitorRepository db;

        public VisitorsController(IVisitorRepository repository)
        {
            db = repository;
        }

        // GET: Visitors
        public ActionResult Index()
        {
            return View(db.GetVisitorsList());
        }

        // GET: Visitors/Details/5
        public ActionResult Details(int id)
        {
            Visitor visitor = db.GetVisitor(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Visitors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VisitorId,LastName,FirstName,Gender,Age,Telephone,Email,Feedback")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Create(visitor);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public ActionResult Edit(int id)
        {
            Visitor visitor = db.GetVisitor(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VisitorId,LastName,FirstName,Gender,Age,Telephone,Email,Feedback")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Update(visitor);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public ActionResult Delete(int id)
        {
            Visitor visitor = db.GetVisitor(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Visitor visitor = db.GetVisitor(id);
            db.Delete(visitor.VisitorId);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
