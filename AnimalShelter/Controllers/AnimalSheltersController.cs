using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class AnimalSheltersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AnimalShelters
        public ActionResult Index(string shelterAddress, string searchString)
        {
            // var searchString = id;
            var animalShelters = from a in db.AnimalShelters
                                 select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                animalShelters = animalShelters.Where(s => s.ShelterName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(shelterAddress))
            {
                animalShelters = animalShelters.Where(s => s.ShelterAddress.Contains(shelterAddress));
            }

            return View(animalShelters);
            //return View(db.AnimalShelters.ToList());
        }

        // GET: AnimalShelters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AnimalShelter animalShelter = db.AnimalShelters.Find(id);
            if (animalShelter == null)
            {
                return HttpNotFound();
            }
            return View(animalShelter);
        }

        // GET: AnimalShelters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalShelters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShelterId,ShelterAddress,ShelterName,ShelterPhoneNumber,ShelterEmail")] Models.AnimalShelter animalShelter)
        {
            if (ModelState.IsValid)
            {
                db.AnimalShelters.Add(animalShelter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalShelter);//System.Web.UI.WebControls.View(animalShelter);
        }

        // GET: AnimalShelters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AnimalShelter animalShelter = db.AnimalShelters.Find(id);
            if (animalShelter == null)
            {
                return HttpNotFound();
            }
            return View(animalShelter);//System.Web.UI.WebControls.View(animalShelter);
        }

        // POST: AnimalShelters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShelterId,ShelterAddress,ShelterName,ShelterPhoneNumber,ShelterEmail")] Models.AnimalShelter animalShelter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalShelter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalShelter);//System.Web.UI.WebControls.View(animalShelter);
        }

        // GET: AnimalShelters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.AnimalShelter animalShelter = db.AnimalShelters.Find(id);
            if (animalShelter == null)
            {
                return HttpNotFound();
            }
            return View(animalShelter);//System.Web.UI.WebControls.View(animalShelter);
        }

        // POST: AnimalShelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.AnimalShelter animalShelter = db.AnimalShelters.Find(id);
            db.AnimalShelters.Remove(animalShelter);
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
