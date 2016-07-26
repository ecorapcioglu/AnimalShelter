using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class PersonnelTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonnelTypes
        public ActionResult Index()
        {
            return View(db.PersonnelTypes.ToList());
        }

        // GET: PersonnelTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelType personnelType = db.PersonnelTypes.Find(id);
            if (personnelType == null)
            {
                return HttpNotFound();
            }
            return View(personnelType);
        }

        // GET: PersonnelTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonnelTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonnelTypeId,PersonnelTypeTitle")] PersonnelType personnelType)
        {
            if (ModelState.IsValid)
            {
                db.PersonnelTypes.Add(personnelType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personnelType);
        }

        // GET: PersonnelTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelType personnelType = db.PersonnelTypes.Find(id);
            if (personnelType == null)
            {
                return HttpNotFound();
            }
            return View(personnelType);
        }

        // POST: PersonnelTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonnelTypeId,PersonnelTypeTitle")] PersonnelType personnelType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnelType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personnelType);
        }

        // GET: PersonnelTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonnelType personnelType = db.PersonnelTypes.Find(id);
            if (personnelType == null)
            {
                return HttpNotFound();
            }
            return View(personnelType);
        }

        // POST: PersonnelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonnelType personnelType = db.PersonnelTypes.Find(id);
            db.PersonnelTypes.Remove(personnelType);
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
