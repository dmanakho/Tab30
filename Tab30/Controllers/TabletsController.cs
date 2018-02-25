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
    public class TabletsController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: Tablets
        public ActionResult Index()
        {
            var tablets = db.Tablets.Include(t => t.Location).Include(t => t.User).Include(t=>t.Repairs);
            return View(tablets.ToList());
        }

        // GET: Tablets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tablet = db.Tablets.Single(t => t.ID == id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // GET: Tablets/Create
        public ActionResult Create()
        {
            
            ViewBag.LocationID = new SelectList(db.Locations.OrderBy(d=>d.ShortDescription), "ID", "ShortDescription");
            ViewBag.UserID = new SelectList(db.Users.OrderBy(d=>d.FirstName).ThenBy(d=>d.LastName), "ID", "FullName");
            return View();
        }

        // POST: Tablets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TabletName,Make,Model,SerialNo,AssetTag,WarrantyExpiresOn,ADPEnabled,LocationID,UserID")] Tablet tablet)
        {
            if (ModelState.IsValid)
            {
                tablet.CreatedOn = DateTime.Now;
                tablet.UpdatedOn = DateTime.Now;
                db.Tablets.Add(tablet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "ID", "ShortDescription", tablet.LocationID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", tablet.UserID);
            return View(tablet);
        }

        // GET: Tablets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "ShortDescription", tablet.LocationID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", tablet.UserID);
            return View(tablet);
        }

        // POST: Tablets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TabletName,Make,Model,SerialNo,AssetTag,WarrantyExpiresOn,ADPEnabled,LocationID,UserID")] Tablet tablet)
        {
            if (ModelState.IsValid)
            {
                tablet.UpdatedOn = DateTime.Now;
                db.Entry(tablet).State = EntityState.Modified;
                db.Entry(tablet).Property("CreatedOn").IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "ID", "ShortDescription", tablet.LocationID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName", tablet.UserID);
            return View(tablet);
        }

        // GET: Tablets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tablet tablet = db.Tablets.Find(id);
            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // POST: Tablets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tablet tablet = db.Tablets.Find(id);
            db.Tablets.Remove(tablet);
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
