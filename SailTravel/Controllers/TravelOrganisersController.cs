using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoatJourney.Models;

namespace BoatJourney.Controllers
{
    public class TravelOrganisersController : Controller
    {
        private BoatJourneyEntities db = new BoatJourneyEntities();

        // GET: TravelOrganisers
        public ActionResult Index()
        {
            return View(db.TravelOrganisers.ToList());
        }

        // GET: TravelOrganisers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrganiser travelOrganiser = db.TravelOrganisers.Find(id);
            if (travelOrganiser == null)
            {
                return HttpNotFound();
            }
            return View(travelOrganiser);
        }

        // GET: TravelOrganisers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TravelOrganisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TravelOrganiser travelOrganiser) //Create([Bind(Include = "Id,Organiser")] TravelOrganiser travelOrganiser)
        {
            if (ModelState.IsValid)
            {
                db.TravelOrganisers.Add(travelOrganiser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travelOrganiser);
        }

        // GET: TravelOrganisers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrganiser travelOrganiser = db.TravelOrganisers.Find(id);
            if (travelOrganiser == null)
            {
                return HttpNotFound();
            }
            return View(travelOrganiser);
        }

        // POST: TravelOrganisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TravelOrganiser travelOrganiser) //Edit([Bind(Include = "Id,Organiser")] TravelOrganiser travelOrganiser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(travelOrganiser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travelOrganiser);
        }

        // GET: TravelOrganisers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TravelOrganiser travelOrganiser = db.TravelOrganisers.Find(id);
            if (travelOrganiser == null)
            {
                return HttpNotFound();
            }
            return View(travelOrganiser);
        }

        // POST: TravelOrganisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TravelOrganiser travelOrganiser = db.TravelOrganisers.Find(id);
            db.TravelOrganisers.Remove(travelOrganiser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Geef reis details weer per travelagency.
        /// </summary>
        /// <returns>alle reis details</returns>
        public ActionResult TravelDetailsPerTravelAgency(int id)
        {
            TravelOrganiser travelOrganiser = new TravelOrganiser();
            travelOrganiser = db.TravelOrganisers.Where(x => x.Id == id).FirstOrDefault();

            //Travel travel = new Travel();
            //travel.VesselList = db.Vessels.Where(x => x.Travel.Id == x.TravelId).Include("Travel").ToList();

            travelOrganiser.TravelList = db.Travels.Where(x => x.TravelOrganiser.Id == id).ToList();

            return View(travelOrganiser);
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
