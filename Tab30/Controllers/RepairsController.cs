using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tab30.DAL;
using Tab30.Models;
using Tab30.ViewModels;

namespace Tab30.Controllers
{
    [Authorize]
    public class RepairsController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: Repairs
        public ActionResult Index()
        {
            var repairs = db.Repairs.OrderByDescending(p => p.CreatedOn).Include(r => r.RepairType).Include(r => r.Tablet);
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

            return View();
        }
        // POST: Repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create([Bind(Include = "ID,VendorCaseNo,Description,Comment,IsComplete,RepairCreated,UpdatedOn,RepairClosed,IsBoxRequested,BoxRequestedOn,IsShipped,ShippedOn,IsUnitReturned,ReturnedOn,TabletID,RepairTypeID")] Repair repair)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Repairs.Add(repair);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.RepairTypeID = new SelectList(db.RepairTypes, "ID", "RepairTypeDescription", repair.RepairTypeID);
            //ViewBag.TabletID = new SelectList(db.Tablets, "ID", "TabletName", repair.TabletID);
            //ViewBag.TechID = new SelectList(db.Teches, "ID", "FirstName", repair.TechID);
            //return View(repair);
            return "Not Implemented";
        }


        public ActionResult Save(int? tabletID)
        {
            if (!tabletID.HasValue)
            {
                //redirect to the tablet list if this page was accessed by accident without providing a valid tablet ID
                return RedirectToAction("Index", "Tablets");
            }
            var tabletRepair = new TabletRepairViewModel(tabletID.Value);

            return View(tabletRepair);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(TabletRepairViewModel tabletRepair)
        {
            Repair repair = tabletRepair; //implicit conversion with the help of implicit operator in TabletRepairviewModels class
            try
            {
                if (ModelState.IsValid)
                {
                    //the line below is from: https://www.thereformedprogrammer.net/updating-a-many-to-many-relationship-in-entity-framework/
                    //also need to work to update this code to work with EDIT action. See article above.
                    //this only works with EF configured many-to-many relationship. It will not work with custom join table with payload.

                    repair.ProblemAreas = db.ProblemAreas.Where(p => tabletRepair.AssignedProblems.Contains(p.ID)).ToList();

                    db.Repairs.Add(repair);
                    db.SaveChanges();

                    //lines below populat ordered parts.
                    if (tabletRepair.OrderedPartIDs != null)
                    {
                        List<PartOrder> partOrders = new List<PartOrder>();
                        foreach (var part in tabletRepair.OrderedPartIDs)
                        {
                            partOrders.Add(new PartOrder()
                            {
                                OrderedOn = DateTime.Now,
                                PartID = part,
                                RepairID = repair.ID,
                                IsPartReceived = false
                            });
                        }
                        db.PartOrders.AddRange(partOrders);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Details", "Tablets", new { id = repair.TabletID });
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_VendorCaseNo"))
                {
                    ModelState.AddModelError("VendorCaseNo", "Unable to save changes. Vendor Case No. must be unique");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Database Error occured Copy the error message and send it to Dima</br>: {dex.Message}. / {dex.InnerException.Message} / {dex.InnerException.InnerException.Message} ");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error occured Copy the error message and send it to Dima</br>: {ex.Message}. + {ex.InnerException.Message} + {ex.InnerException.InnerException.Message}");
            }

            return View(tabletRepair);
        }


        // GET: Repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repair repair = db.Repairs.Include(r => r.PartOrders).Include(r => r.ProblemAreas).Include(r => r.Tablet).FirstOrDefault(r => r.ID == id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            TabletRepairViewModel tabletRepair = repair;

            return View(tabletRepair);
        }

        // POST: Repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TabletRepairViewModel tabletRepair)
        {
            Repair repair = tabletRepair;
            try
            {
                if (ModelState.IsValid)
                {

                    //                var problemsToAdd = db.ProblemAreas.Where(p => tabletRepair.AssignedProblems.Contains(p.ID)).ToList();
                    repair.ProblemAreas = new HashSet<ProblemArea>();
                    db.Entry(repair).State = EntityState.Modified;
                    db.Entry(repair).Collection(p => p.ProblemAreas).Load();

                    db.Entry(repair).Collection(p => p.PartOrders).Load();
                    foreach (var partOrder in repair.PartOrders)
                    {
                        partOrder.IsPartReceived = tabletRepair.PartOrders.Where(p => p.ID == partOrder.ID).Select(p => p.IsPartReceived).SingleOrDefault();
                        partOrder.ReceivedOn = tabletRepair.PartOrders.Where(p => p.ID == partOrder.ID).Select(p => p.ReceivedOn).SingleOrDefault();
                    }
                    repair.ProblemAreas = db.ProblemAreas.Where(p => tabletRepair.AssignedProblems.Contains(p.ID)).ToList();

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                //This is implemented by a virtue of having "RowVersion" field in our model and database. watch this video for details: https://youtu.be/Gi_kEbc5faQ
                ModelState.AddModelError(string.Empty, $"The record you were trying to update was modified by another user. Please go back and try again.");
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_VendorCaseNo"))
                {
                    ModelState.AddModelError("VendorCaseNo", "Unable to save changes. Vendor Case No. must be unique");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Database Error occured Copy the error message and send it to Dima </br>: {dex.Message}. + {dex.InnerException.Message} + {dex.InnerException.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Unexpected error occured. Copy the error message and send it to Dima {ex.Message} | {ex.InnerException.InnerException.Message}" +
                    $"{ex.InnerException.InnerException.Message}");
            }
            return View(tabletRepair);
        }

        // GET: Repairs/Delete/5
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
            try
            {
                Repair repair = db.Repairs.Find(id);
                db.Repairs.Remove(repair);
                db.SaveChanges();
            }
            catch (DataException dex)
            {
                return RedirectToAction("Delete", new { id, errorMessage = dex.InnerException.InnerException.Message, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult RecentRepairs()
        {
            var repair = db.Repairs.OrderByDescending(p => p.CreatedOn).Take(10).Include(r => r.RepairType).Include(r => r.Tablet);
            return PartialView(repair);
        }

        [ChildActionOnly]
        public ActionResult YourRecentRepairs(string userName)
        {
            var repair = db.Repairs.Where(p=>p.CreatedBy == userName).OrderByDescending(p => p.CreatedOn).Take(10).Include(r => r.RepairType).Include(r => r.Tablet);
            return PartialView("RecentRepairs",repair);
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
