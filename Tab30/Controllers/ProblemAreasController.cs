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
    public class ProblemAreasController : Controller
    {
        private TabDBContext db = new TabDBContext();

        // GET: ProblemAreas
        public ActionResult Index()
        {
            return View(db.ProblemAreas.ToList());
        }

        // GET: ProblemAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemArea problemArea = db.ProblemAreas.Find(id);
            if (problemArea == null)
            {
                return HttpNotFound();
            }
            return View(problemArea);
        }

        // GET: ProblemAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] ProblemArea problemArea)
        {
            if (ModelState.IsValid)
            {
                db.ProblemAreas.Add(problemArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(problemArea);
        }

        // GET: ProblemAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemArea problemArea = db.ProblemAreas.Find(id);
            if (problemArea == null)
            {
                return HttpNotFound();
            }
            return View(problemArea);
        }

        // POST: ProblemAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] ProblemArea problemArea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(problemArea).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_Description"))
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

            return View(problemArea);
        }

        // GET: ProblemAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemArea problemArea = db.ProblemAreas.Find(id);
            if (problemArea == null)
            {
                return HttpNotFound();
            }
            return View(problemArea);
        }

        // POST: ProblemAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemArea problemArea = db.ProblemAreas.Find(id);
            db.ProblemAreas.Remove(problemArea);
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
