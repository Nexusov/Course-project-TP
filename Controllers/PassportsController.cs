using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Course_Project_TP_6.Models;

namespace Course_Project_TP_6.Controllers
{
    public class PassportsController : Controller
    {
        private passportofficeEntities db = new passportofficeEntities();

        // GET: Passports
        public ActionResult Index()
        {
            var passport = db.Passport.Include(p => p.Users);
            return View(passport.ToList());
        }

        // GET: Passports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passport passport = db.Passport.Find(id);
            if (passport == null)
            {
                return HttpNotFound();
            }
            return View(passport);
        }

        // GET: Passports/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "UserName");
            return View();
        }

        // POST: Passports/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Passport_Id,User_Id,IssuedBy,DateOfIssue,DepartamentCode,Number")] Passport passport)
        {
            if (ModelState.IsValid)
            {
                db.Passport.Add(passport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "UserName", passport.User_Id);
            return View(passport);
        }

        // GET: Passports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passport passport = db.Passport.Find(id);
            if (passport == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "UserName", passport.User_Id);
            return View(passport);
        }

        // POST: Passports/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Passport_Id,User_Id,IssuedBy,DateOfIssue,DepartamentCode,Number")] Passport passport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "UserName", passport.User_Id);
            return View(passport);
        }

        // GET: Passports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passport passport = db.Passport.Find(id);
            if (passport == null)
            {
                return HttpNotFound();
            }
            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Passport passport = db.Passport.Find(id);
            db.Passport.Remove(passport);
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
