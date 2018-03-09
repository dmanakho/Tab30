using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            var tablets = db.Tablets.Include(t => t.Location).Include(t => t.User).OrderBy(t => t.TabletName);
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
            TabletViewModel tablet = db.Tablets.Where(t => t.ID == id).Include(t => t.Repairs).Include(t => t.User).Include(t => t.Location).SingleOrDefault();

            if (tablet == null)
            {
                return HttpNotFound();
            }
            return View(tablet);
        }

        // GET: Tablets/Create
        public ActionResult Create()
        {
            var tabletViewModel = new TabletViewModel();
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
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tablets.Add(tablet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_SerialNo"))
                {
                    ModelState.AddModelError("SerialNo", "Unable to save changes. Serial Number must be unique");
                }
                else if (dex.InnerException.InnerException.Message.Contains("IX_TabletName"))
                {
                    ModelState.AddModelError("TabletName", "Unable to save changes. Tablet Name must be unique");
                }
                else if (dex.InnerException.InnerException.Message.Contains("IX_AssetTag"))
                {
                    ModelState.AddModelError("AssetTag", "Unable to save changes. Asset Tag must be unique");
                }
                else
                {
                    ModelState.AddModelError("", $"Error occured (please copy the error and contact helpdesk)</br>: {dex.Message}. + {dex.InnerException.Message} + {dex.InnerException.Message}");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "System freaked out. The record wasn't updated for some bizzare reasons. Please contact someone with knowledge to look at this");
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
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(tablet).OriginalValues["RowVersion"]
                    db.Entry(tablet).State = EntityState.Modified;
                    //db.Entry(tablet).OriginalValues["RowVersion"] = tabletViewModel.RowVersion;
                    db.Entry(tablet).Property("CreatedOn").IsModified = false;
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = tablet.ID });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //This is implemented by a virtue of having "RowVersion" field in our model and database. watch this video for details: https://youtu.be/Gi_kEbc5faQ
                ModelState.AddModelError(string.Empty, $"The record you were trying to update was modified by another user. Please go back and try again. {ex.Message}");
            }
            catch (DataException dex)
            {
                //the database error handling. Well explained in this video: https://youtu.be/aKSTDjxGxhw
                if (dex.InnerException.InnerException.Message.Contains("IX_SerialNo"))
                {
                    ModelState.AddModelError("SerialNo", "Unable to save changes. Serial Number must be unique");
                }
                else if (dex.InnerException.InnerException.Message.Contains("IX_TabletName"))
                {
                    ModelState.AddModelError("TabletName", "Unable to save changes. Tablet Name must be unique");
                }
                else if (dex.InnerException.InnerException.Message.Contains("IX_AssetTag"))
                {
                    ModelState.AddModelError("AssetTag", "Unable to save changes. Asset Tag must be unique");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong </br>" + dex.InnerException.InnerException.Message);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "System freaked out. The record wasn't updated for some bizzare reasons. Please contact someone with knowledge to look at this");
            }
            return View(tabletViewModel);
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
