using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RelationsEF.Models;

namespace RelationsEF.Controllers
{
    public class PersoonsController : Controller
    {
        private MyEntities db = new MyEntities();

        // GET: Persoons
        public ActionResult Index()
        {
            var personen = db.personen.Include(p => p.Adres);
            return View(personen.ToList());
        }

        // GET: Persoons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Persoon persoon = db.personen.Find(id);
            Persoon persoon = db.personen.Where(x => x.Id == id).Include("Adres").FirstOrDefault();

            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // GET: Persoons/Create
        public ActionResult Create()
        {
            ViewBag.AdresId = new SelectList(db.adressen, "Id", "Straat");
            return View();
        }

        // POST: Persoons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.personen.Add(persoon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdresId = new SelectList(db.adressen, "Id", "Straat", persoon.AdresId);
            return View(persoon);
        }

        // GET: Persoons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Persoon persoon = db.personen.Find(id);
            Persoon persoon = db.personen.Where(x => x.Id == id).Include("Adres").FirstOrDefault();

            if (persoon == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdresId = new SelectList(db.adressen, "Id", "Straat", persoon.AdresId);
            return View(persoon);
        }

        // POST: Persoons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persoon).State = EntityState.Modified;
                db.Entry(persoon.Adres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdresId = new SelectList(db.adressen, "Id", "Straat", persoon.AdresId);
            return View(persoon);
        }

        // GET: Persoons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persoon persoon = db.personen.Find(id);
            if (persoon == null)
            {
                return HttpNotFound();
            }
            return View(persoon);
        }

        // POST: Persoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persoon persoon = db.personen.Find(id);
            db.personen.Remove(persoon);
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
