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
using Tab30.ViewModels;

namespace Tab30.Controllers
{
    public class TabletsController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: Tablets
        public ActionResult Index()
        {
            var tablets = db.Tablets.Include(t => t.Location).Include(t => t.User).Include(t => t.Repairs).OrderBy(t => t.TabletName);
            return View(tablets.ToList());
        }

        // GET: Tablets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Tablets");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tablet = db.Tablets.FirstOrDefault(t => t.ID == id);

            if (tablet == null)
            {
                return HttpNotFound();
            }

            tablet.Repairs = db.Repairs.Where(t => t.TabletID == id).
                Include(t=>t.RepairType).
                Include(t => t.ProblemAreas).
                ToList();

            return View(tablet);
        }

        // GET: Tablets/Create
        public ActionResult Create()
        {
            var tabletViewModel = new TabletViewModel(db);
            return View(tabletViewModel);
        }

        // POST: Tablets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TabletViewModel tabletViewModel)
        {
            //implicit conversion using implicit operator defined in TabletViewModel Class

            Tablet tablet = tabletViewModel;

            if (ModelState.IsValid)
            {
                tablet.CreatedOn = DateTime.Now;
                tablet.UpdatedOn = DateTime.Now;
                db.Tablets.Add(tablet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabletViewModel);
        }

        // GET: Tablets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Tablets");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabletViewModel tabletViewModel = db.Tablets.Find(id);

            if (tabletViewModel == null)
            {
                return HttpNotFound();
            }
            tabletViewModel.Locations = new SelectList(db.Locations.OrderBy(p => p.ShortDescription), "ID", "ShortDescription");
            tabletViewModel.Users = new SelectList(db.Users.ToList().OrderBy(t => t.FullName), "ID", "FullName");

            return View(tabletViewModel);
        }

        // POST: Tablets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TabletViewModel tabletViewModel)
        {
            Tablet tablet = tabletViewModel;
            if (ModelState.IsValid)
            {
                tablet.UpdatedOn = DateTime.Now;
                db.Entry(tablet).State = EntityState.Modified;
                db.Entry(tablet).Property("CreatedOn").IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = tablet.ID });
            }
           
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
