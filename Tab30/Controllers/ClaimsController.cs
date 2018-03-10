using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Tab30.Controllers
{
    [Authorize]
    public class ClaimsController : Controller
    {
        /// <summary>
        /// Add user's claims to viewbag
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;

            //You get the user’s first and last name below:
            ViewBag.Name = userClaims?.FindFirst("name")?.Value;

            // The 'Name' claim can be used for showing the username
            ViewBag.Username = userClaims?.FindFirst(System.IdentityModel.Claims.ClaimTypes.Name)?.Value;

            // The subject/ NameIdentifier claim can be used to uniquely identify the user across the web
            ViewBag.Subject = userClaims?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // TenantId is the unique Tenant Id - which represents an organization in Azure AD
            ViewBag.TenantId = userClaims?.FindFirst("http://schemas.microsoft.com/identity/claims/tenantid")?.Value;

            var cp = System.Web.HttpContext.Current.User;

            //var roles = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;


            var bb = userClaims.Claims.Select(p => p.Properties).ToList();

            return View();
        }
    }
}