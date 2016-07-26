using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class VetHospitalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VetHospitals
        public ActionResult Index()
        {
            var vetHospitals = db.VetHospitals.Include(v => v.AnimalShelter);
            return View(vetHospitals.ToList());
        }

        // GET: VetHospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetHospital vetHospital = db.VetHospitals.Find(id);
            if (vetHospital == null)
            {
                return HttpNotFound();
            }
            return View(vetHospital);
        }

        // GET: VetHospitals/Create
        public ActionResult Create()
        {
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress");
            return View();
        }

        // POST: VetHospitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VetHospitalId,VetHospitalName,VetHospitalAddress,VetHospitalHours,VetHospitalPhoneNumber,VetHospitalEmail,ShelterId")] VetHospital vetHospital)
        {
            if (ModelState.IsValid)
            {
                db.VetHospitals.Add(vetHospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", vetHospital.ShelterId);
            return View(vetHospital);
        }

        // GET: VetHospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetHospital vetHospital = db.VetHospitals.Find(id);
            if (vetHospital == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", vetHospital.ShelterId);
            return View(vetHospital);
        }

        // POST: VetHospitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VetHospitalId,VetHospitalName,VetHospitalAddress,VetHospitalHours,VetHospitalPhoneNumber,VetHospitalEmail,ShelterId")] VetHospital vetHospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vetHospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShelterId = new SelectList(db.AnimalShelters, "ShelterId", "ShelterAddress", vetHospital.ShelterId);
            return View(vetHospital);
        }

        // GET: VetHospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VetHospital vetHospital = db.VetHospitals.Find(id);
            if (vetHospital == null)
            {
                return HttpNotFound();
            }
            return View(vetHospital);
        }

        // POST: VetHospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VetHospital vetHospital = db.VetHospitals.Find(id);
            db.VetHospitals.Remove(vetHospital);
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
