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
    public class RepairsController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: Repairs
        public ActionResult Index()
        {
            var repairs = db.Repairs.Include(r => r.RepairType).Include(r => r.Tablet).Include(r => r.Tech);
            return View(repairs.ToList());
        }

        // GET: Repairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // GET: Repairs/Create
        public ActionResult Create()
        {
            ViewBag.RepairTypeID = new SelectList(db.RepairTypes, "ID", "RepairTypeDescription");
            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName");
            ViewBag.TechID = new SelectList(db.Teches, "ID", "FirstName");
            return View();
        }
        public ActionResult Save(int? tabletID)
        {
            if (!tabletID.HasValue)
            {
                //redirect to the tablet list if this page was accessed by accident without providing a valid tablet ID
                return RedirectToAction("Index", "Tablets");
            }
            var tabletRepair = GetTabletRepairVM(tabletID.Value);

            return View(tabletRepair);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TabletRepairViewModel tabletRepair)
        {
            if (ModelState.IsValid)
            {
                Repair repair = tabletRepair; //implicit conversion with the help of implicit operator in TabletRepairviewModels class

                repair.UpdatedOn = DateTime.Now;
                repair.RepairCreated = DateTime.Now;
                repair.IsComplete = tabletRepair.IsComplete;
                repair.TechID = 2; //this is temporary until Auth and Oauth is implemented;

                //if (tabletRepair.Problems != null)
                //{
                //    foreach (var problem in tabletRepair.Problems)
                //    {
                //        if (problem.Assigned)
                //        {
                //            var problemArea = new ProblemArea { ID = problem.ProblemAreaID };

                //            db.ProblemAreas.Attach(problemArea);
                //            repair.ProblemAreas.Add(problemArea);
                //        }
                //    }
                //}
                db.Repairs.Add(repair);
                db.SaveChanges();
                return RedirectToAction("Details", "Tablets", new { id = repair.TabletID });
            }
            //tabletRepair.Problems = GetAssignedProblemsList();
            return View(tabletRepair);
        }
        // POST: Repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VendorCaseNo,RepairDescription,Comment,IsComplete,RepairCreated,UpdatedOn,RepairClosed,IsBoxRequested,BoxRequestedOn,IsShipped,ShippedOn,IsUnitReturned,ReturnedOn,TabletID,RepairTypeID,TechID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Repairs.Add(repair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RepairTypeID = new SelectList(db.RepairTypes, "ID", "RepairTypeDescription", repair.RepairTypeID);
            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", repair.TabletID);
            ViewBag.TechID = new SelectList(db.Teches, "ID", "FirstName", repair.TechID);
            return View(repair);
        }

        // GET: Repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            ViewBag.RepairTypeID = new SelectList(db.RepairTypes, "ID", "RepairTypeDescription", repair.RepairTypeID);
            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", repair.TabletID);
            ViewBag.TechID = new SelectList(db.Teches, "ID", "FirstName", repair.TechID);
            return View(repair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VendorCaseNo,RepairDescription,Comment,IsComplete,RepairCreated,UpdatedOn,RepairClosed,IsBoxRequested,BoxRequestedOn,IsShipped,ShippedOn,IsUnitReturned,ReturnedOn,TabletID,RepairTypeID,TechID")] Repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RepairTypeID = new SelectList(db.RepairTypes, "ID", "RepairTypeDescription", repair.RepairTypeID);
            ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", repair.TabletID);
            ViewBag.TechID = new SelectList(db.Teches, "ID", "FirstName", repair.TechID);
            return View(repair);
        }

        // GET: Repairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: Repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repair repair = db.Repairs.Find(id);
            db.Repairs.Remove(repair);
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

        [NonAction]
        private TabletRepairViewModel GetTabletRepairVM(int tabletID)
        {
            var tablet = db.Tablets.Find(tabletID);
            var tech = db.Teches.Find(2); //magic number but will be replaces with Tech's info later;
            

            var tabletRepair = new TabletRepairViewModel()
            {
                TabletID = tablet.ID,
                TabletName = tablet.TabletName,
                TechID = 2, //Kevin
                TechName = tech.FullName,
                 
            };
            //var assignedProblems = new List<AssignedProblemAreas>();
            //foreach (var problemArea in db.ProblemAreas)
            //{
            //    assignedProblems.Add(new AssignedProblemAreas
            //    {
            //        ProblemAreaID = problemArea.ID,
            //        ProblemDescription = problemArea.ProblemDescription,
            //        Assigned = false
            //    }
            //        );
            //}
            //tabletRepair.Problems = GetAssignedProblemsList();
            return tabletRepair;
        }

        [NonAction]
        private List<AssignedProblemAreas> GetAssignedProblemsList()
        {
            var assignedProblems = new List<AssignedProblemAreas>();
            foreach (var problemArea in db.ProblemAreas)
            {
                assignedProblems.Add(new AssignedProblemAreas
                {
                    ProblemAreaID = problemArea.ID,
                    ProblemDescription = problemArea.ProblemDescription,
                    Assigned = false
                }
                    );
            }
            return assignedProblems;
        }
    }
}
