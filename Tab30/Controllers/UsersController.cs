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
using X.PagedList;
using X.PagedList.Mvc;

namespace Tab30.Controllers
{
    public class UsersController : Controller
    {
        private TabDBContext db = new TabDBContext();

        public ActionResult UsersTablets()
        {
            var users = db.Users;
            return View(users);
        }
        
        // GET: Users
        public ViewResult Index(string sortOrder, string searchQuery, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CreatedDateSortParm = sortOrder == "CDate" ? "cdate_desc" : "CDate";
            ViewBag.UpdatedDateSortParm = sortOrder == "UDate" ? "udate_desc" : "UDate";

            if (searchQuery != null)
            {
                page = 1;
            }
            else
            {
                searchQuery = currentFilter;
            }
            ViewBag.CurrentFilter = searchQuery;


            var users = from u in db.Users select u;

            if (!String.IsNullOrEmpty(searchQuery))
            {
                users = users.Where(u => u.LastName.Contains(searchQuery) || u.FirstName.Contains(searchQuery) || u.UserName.Contains(searchQuery));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.LastName);
                    break;
                case "UDate":
                    users = users.OrderBy(u => u.UpdatedOn);
                    break;
                case "udate_desc":
                    users = users.OrderByDescending(u => u.UpdatedOn);
                    break;
                case "CDate":
                    users = users.OrderBy(u => u.CreatedOn);
                    break;
                case "cdate_desc":
                    users = users.OrderByDescending(u => u.CreatedOn);
                    break;
                default:
                    users = users.OrderBy(u => u.LastName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedUsers = users.ToPagedList(pageNumber, pageSize);
            
            return View(pagedUsers);
        }
        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}
        //public ActionResult Index(string sortOrder, string searchQuery)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.CreatedDateSortParm = sortOrder == "CDate" ? "cdate_desc" : "CDate";
        //    ViewBag.UpdatedDateSortParm = sortOrder == "UDate" ? "udate_desc" : "UDate";
        //    var users = from u in db.Users select u;

        //    if (!String.IsNullOrEmpty(searchQuery))
        //    {
        //        users = users.Where(u => u.LastName.Contains(searchQuery) || u.FirstName.Contains(searchQuery) || u.UserName.Contains(searchQuery));
        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            users = users.OrderByDescending(u => u.LastName);
        //            break;
        //        case "UDate":
        //            users = users.OrderBy(u => u.UpdatedOn);
        //            break;
        //        case "udate_desc":
        //            users = users.OrderByDescending(u => u.UpdatedOn);
        //            break;
        //        case "CDate":
        //            users = users.OrderBy(u => u.CreatedOn);
        //            break;
        //        case "cdate_desc":
        //            users = users.OrderByDescending(u => u.CreatedOn);
        //            break;
        //        default:
        //            users = users.OrderBy(u => u.LastName);
        //            break;
        //    }
        //    return View(users.ToList());
        //}
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,UserName,ClassOf,ImportID")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                if (dex.InnerException.InnerException.Message.Contains("IX_Import"))
                {
                    ModelState.AddModelError("ImportID", "Unable to save changes. ImportID must be unique");
                }
                else if (dex.InnerException.InnerException.Message.Contains("IX_UserName"))
                {
                    ModelState.AddModelError("UserName", "Unable to save changes. User Name must be unique");
                }
                else
                {
                    ModelState.AddModelError("", $"DataBase error occured (please copy the error and contact helpdesk)</br>: {dex.Message}. + {dex.InnerException.Message} + {dex.InnerException.Message}");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error occured Copy the error message and send it to Dima</br>: {ex.Message}. + {ex.InnerException.Message} + {ex.InnerException.InnerException.Message}");
            }


            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userToUpdate = db.Users.Find(id);
            if (TryUpdateModel(userToUpdate, "", new string[]
            { "FirstName", "LastName", "UserName", "ClassOf", "ImportID", "UpdatedOn", "CreatedOn", "UpdatedBy", "CreatedBy", "RowVersion" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (DbUpdateConcurrencyException)
                {
                    //This is implemented by a virtue of having "RowVersion" field in our model and database. watch this video for details: https://youtu.be/Gi_kEbc5faQ
                    ModelState.AddModelError(string.Empty, $"The record you were trying to update was modified by another user. Please go back and try again.");
                }
                catch (DataException dex)
                {
                    if (dex.InnerException.InnerException.Message.Contains("IX_Import"))
                    {
                        ModelState.AddModelError("ImportID", "Unable to save changes. ImportID must be unique");
                    }
                    else if (dex.InnerException.InnerException.Message.Contains("IX_UserName"))
                    {
                        ModelState.AddModelError("UserName", "Unable to save changes. User Name must be unique");
                    }
                    else
                    {
                        ModelState.AddModelError("", $"DataBase error occured (please copy the error and contact helpdesk)</br>: {dex.Message}. + {dex.InnerException.Message} + {dex.InnerException.Message}");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error occured Copy the error message and send it to Dima</br>: {ex.Message}. + {ex.InnerException.Message} + {ex.InnerException.InnerException.Message}");
                }
            }
            return View(userToUpdate);
        }
        //public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,UserName,ClassOf")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        user.UpdatedOn = DateTime.Now;

        //        db.Entry(user).State = EntityState.Modified;
        //        //db.Entry(user).Property("ID").IsModified = false;
        //        db.Entry(user).Property("CreatedOn").IsModified = false;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        // GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again or contact Helpdesk";
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
