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
    public class PersonnelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personnels
        public ActionResult Index()
        {
            var personnels = db.Personnels.Include(p => p.AnimalShelter).Include(p => p.PersonnelType);
            return View(personnels.ToList());
        }

        // GET: Personnels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = db.Personnels.Find(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // GET: Personnels/Create
        public ActionResult Create()
        {
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress");
            ViewBag.PersonnelTypeId = new SelectList(db.PersonnelTypes, "PersonnelTypeId", "PersonnelTypeTitle");
            return View();
        }

        // POST: Personnels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonnelId,PersonnelFirstName,PersonnelLastName,PersonnelPhoneNumber,PersonnelEmail,PersonnelTypeId,ShelterId")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                db.Personnels.Add(personnel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", personnel.ShelterId);
            ViewBag.PersonnelTypeId = new SelectList(db.PersonnelTypes, "PersonnelTypeId", "PersonnelTypeTitle", personnel.PersonnelTypeId);
            return View(personnel);
        }

        // GET: Personnels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = db.Personnels.Find(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", personnel.ShelterId);
            ViewBag.PersonnelTypeId = new SelectList(db.PersonnelTypes, "PersonnelTypeId", "PersonnelTypeTitle", personnel.PersonnelTypeId);
            return View(personnel);
        }

        // POST: Personnels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonnelId,PersonnelFirstName,PersonnelLastName,PersonnelPhoneNumber,PersonnelEmail,PersonnelTypeId,ShelterId")] Personnel personnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personnel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", personnel.ShelterId);
            ViewBag.PersonnelTypeId = new SelectList(db.PersonnelTypes, "PersonnelTypeId", "PersonnelTypeTitle", personnel.PersonnelTypeId);
            return View(personnel);
        }

        // GET: Personnels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personnel personnel = db.Personnels.Find(id);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            return View(personnel);
        }

        // POST: Personnels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personnel personnel = db.Personnels.Find(id);
            db.Personnels.Remove(personnel);
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
