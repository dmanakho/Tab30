using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tab30.DAL;
using Tab30.Models;

namespace Tab30.Controllers
{
    public class LocationsController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: Locations
        public ActionResult Index()
        {
            return View(db.Locations.OrderBy(o=>o.LongDescription).ToList());
        }

        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShortDescription,LongDescription")] Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Locations.Add(location);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_ShortDescription"))
                {
                    ModelState.AddModelError("", "Unable to create. Location with this name already exist.");
                }
                else
                {
                    ModelState.AddModelError("", $"Database Error: {dex.InnerException.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error! {ex.Message}");
            }

            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShortDescription,LongDescription")] Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(location).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_ShortDescription"))
                {
                    ModelState.AddModelError("", "Unable to create. Location with this name already exist.");
                }
                else
                {
                    ModelState.AddModelError("", $"Database Error: {dex.InnerException.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error! {ex.Message}");
            }


            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id, string errorMessage = "", bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete Failed: " + errorMessage;
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            try
            {
                db.Entry(location).State = EntityState.Deleted;
                db.Locations.Remove(location);
                db.SaveChanges();
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("FK_"))
                {
                    ModelState.AddModelError("", "Unable to delete. You cannot delete a location that has tablets associated with it.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error! {ex.Message}");
            }
            return View(location);
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
