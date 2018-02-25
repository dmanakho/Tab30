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
    public class PartOrdersController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: PartOrders
        public ActionResult Index()
        {
            var partOrders = db.PartOrders.Include(p => p.Part);
            return View(partOrders.ToList());
        }

        // GET: PartOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartOrder partOrder = db.PartOrders.Find(id);
            if (partOrder == null)
            {
                return HttpNotFound();
            }
            return View(partOrder);
        }

        // GET: PartOrders/Create
        public ActionResult Create()
        {
            ViewBag.PartID = new SelectList(db.Parts, "ID", "Description");
            ViewBag.RepairID = new SelectList(db.Repairs, "ID", "RepairDescription");
            return View();
        }

        // POST: PartOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderedOn,IsPartReceived,ReceivedOn,RepaidID,PartID")] PartOrder partOrder)
        {
            if (ModelState.IsValid)
            {
                db.PartOrders.Add(partOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartID = new SelectList(db.Parts, "ID", "Description", partOrder.PartID);
            ViewBag.RepairID = new SelectList(db.Repairs, "ID", "RepairDescription", partOrder.RepairID);
            return View(partOrder);
        }

        // GET: PartOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartOrder partOrder = db.PartOrders.Find(id);
            if (partOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartID = new SelectList(db.Parts, "ID", "PartNo", partOrder.PartID);
            return View(partOrder);
        }

        // POST: PartOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderedOn,IsPartReceived,ReceivedOn,RepaidID,PartID")] PartOrder partOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartID = new SelectList(db.Parts, "ID", "PartNo", partOrder.PartID);
            return View(partOrder);
        }

        // GET: PartOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartOrder partOrder = db.PartOrders.Find(id);
            if (partOrder == null)
            {
                return HttpNotFound();
            }
            return View(partOrder);
        }

        // POST: PartOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartOrder partOrder = db.PartOrders.Find(id);
            db.PartOrders.Remove(partOrder);
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
