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
    public class TravelsController : Controller
    {
        private BoatJourneyEntities db = new BoatJourneyEntities();

        // GET: Travels
        public ActionResult Index()
        {
            //ViewBag.Vessels = db.Vessels.ToList();

            //Travel travel = new Travel();
            //travel.VesselList.AddRange(db.Vessels.Where(x => x.TravelId == x.Travel.Id));

            //ViewBag.travelVessel = travel.VesselList;

            var travels = db.Travels.Where(x => x.TravelOrganiser.Id == x.TravelOrganiser.Id).Include("TravelOrganiser").ToList();
            return View(travels);
            //return View(db.Travels.ToList());
        }

        // GET: Travels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Where(x => x.Id == id && x.TravelOrganiserId == x.TravelOrganiser.Id).Include("TravelOrganiser").FirstOrDefault(); //db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }

            //ViewBag.Vessels = db.Vessels.ToList();

            return View(travel);
        }

        // GET: Travels/Create
        public ActionResult Create()
        {
            //Travel travel = new Travel();
            //travel.VesselList = db.Vessels.ToList();

            //ViewBag.Vessels = travel.VesselList;

            return View();
        }

        // POST: Travels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "'Id,TypeTravel,BookingDate,StartDate,EndDate")] Travel travel)
        {
            if (ModelState.IsValid)
            {
                db.Travels.Add(travel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(travel);
        }

        // GET: Travels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Where(x => x.Id == id && x.TravelOrganiserId == x.TravelOrganiser.Id).Include("TravelOrganiser").FirstOrDefault(); //db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }

            //ViewBag.TravelOrganiser = new SelectList(db.TravelOrganisers, "Id", "Organiser,BookingDate,StartDate,EndDate");

            return View(travel);
        }

        // POST: Travels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Travel travel) //Edit([Bind(Include = "Id,TypeTravel")] Travel travel)
        {
            TravelOrganiser t = travel.TravelOrganiser;

            if (ModelState.IsValid)
            {
                db.Entry(travel).State = EntityState.Modified;
                db.Entry(travel.TravelOrganiser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(travel);
        }

        // GET: Travels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Travel travel = db.Travels.Find(id);
            if (travel == null)
            {
                return HttpNotFound();
            }
            return View(travel);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Travel travel = db.Travels.Find(id);
            db.Travels.Remove(travel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Geeft boot details per reis weer.
        /// </summary>
        /// <param name="id">travel property type int</param>
        /// <returns>travel eigenschappen vieuw</returns>
        public ActionResult VesselDetailPerTravel(int id)
        {
            Travel travel = new Travel();
            travel = db.Travels.Where(x => x.Id == id && x.TravelOrganiserId == x.TravelOrganiser.Id).Include("TravelOrganiser").FirstOrDefault();
            travel.VesselList = db.Vessels.Where(x => x.TravelId == id).Include("Travel").ToList();

            return View(travel);
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
