using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Relaties.Models;

namespace Relaties.Controllers
{
    public class PeopleController : Controller
    {
        private PersonEntity db = new PersonEntity();

        // GET: People
        public ActionResult Index()
        {
            var persons = db.Persons.Include(p => p.AddressId);
            return View(persons.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Where(x => x.Id == id && x.AddressId.Id == x.IdAddress).Include("AddressId").FirstOrDefault(); //db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            //ViewBag.IdAddress = new SelectList(db.Addresses, "Id", "StreetName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person) //([Bind(Include = "Id,NamePerson,BirthDate,IdAddress")] Person person)
        {
            if (ModelState.IsValid)
            {
                // niet geprogrammeerd volgens convention !!!!!!!!!!!!!!!!!!

                Address ad = new Address();
                ad.StreetName = person.AddressId.StreetName;
                ad.HouseNr = person.AddressId.HouseNr;
                ad.BusNr = person.AddressId.BusNr;

                db.Addresses.Add(ad); // new adres object inserten in adres tabel.
                db.SaveChanges();

                List<Address> adressen = new List<Address>();
                adressen = db.Addresses.ToList();
                person.IdAddress = adressen.Max(x => x.Id); // Laatst opgeslagen adres id opvragen uit addressen lijst.

                db.Persons.Add(person); // new person object inserten in person tabel.
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.IdAddress = new SelectList(db.Addresses, "Id", "StreetName", person.IdAddress);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Where(x => x.Id == id && x.AddressId.Id == x.IdAddress).Include("AddressId").FirstOrDefault(); //db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            //ViewBag.IdAddress = new SelectList(db.Addresses, "Id", "StreetName", person.IdAddress);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Person person) //([Bind(Include = "Id,NamePerson,BirthDate,IdAddress")] Person person)
        {
            if (ModelState.IsValid)
            {
                Address adres = new Address(); //db.Addresses.Where(x => x.Id == person.AddressId.Id).FirstOrDefault();
                adres.Id = person.AddressId.Id;
                adres.StreetName = person.AddressId.StreetName;
                adres.HouseNr = person.AddressId.HouseNr;
                adres.BusNr = person.AddressId.BusNr;

                db.Entry(adres).State = EntityState.Modified;
                db.Entry(person).State = EntityState.Modified; //melding gebruik van dezelfde primary keys!!!!
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            //ViewBag.IdAddress = new SelectList(db.Addresses, "Id", "StreetName", person.IdAddress);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Persons.Where(x => x.Id == id && x.AddressId.Id == x.IdAddress).Include("AddressId").FirstOrDefault(); //db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Where(x => x.Id == id && x.AddressId.Id == x.IdAddress).Include("AddressId").FirstOrDefault(); //db.Persons.Find(id);
            Address adres = db.Addresses.Where(x => x.Id == person.AddressId.Id).FirstOrDefault();

            db.Persons.Remove(person); // Verwijderd person uit persoon tabel.
            db.Addresses.Remove(adres); // verwijderd gelinkte adres uit adres tabel.

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
