using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tab30.DAL;
using Tab30.ViewModels;

namespace Tab30.Controllers
{
    public class HomeController : Controller
    {
        private TabDBContext tabdb = new TabDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<TabletAssignments> data = from user in tabdb.Users
                                                 group user by user.ClassOf into dateGroup
                                                 select new TabletAssignments()
                                                 {
                                                     ClassOf = dateGroup.Key,
                                                     UserCount = dateGroup.Count()
                                                 };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            tabdb.Dispose();
            base.Dispose(disposing);
        }
    }
}