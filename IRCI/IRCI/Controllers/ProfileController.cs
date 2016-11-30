using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;
using IRCI.Entity;

namespace IRCI.Controllers
{
    public class ProfileController : Controller
    {
        private E_Profile data;
        private M_Profile profile = new M_Profile();
        // GET: Profil
        public ActionResult Index(string id = "")
        {
            //string profilId = id; //the id in the URL
            //string data = RouteData.Values["id"] + Request.Url.Query;
            //string data = RouteData.Values["id"].ToString(); ;
            //ViewData["data"] = data;
            data = profile.detailAuthor(id);
            return View(data);
        }
        public ActionResult claimProfile(string id_authors = "", string auth_id = "")
        {

            M_Profile profile = new M_Profile();
            string result = profile.claimProfile(id_authors, auth_id);
            if (result == "success")
            {
                Response.Redirect("/show");
            }
            else
            {
                Response.Redirect("/show?error=1");
            }
            return View();
        }
        public ActionResult unClaimProfile(string id_authors = "", string auth_id = "")
        {

            M_Profile profile = new M_Profile();
            string result = profile.unClaimProfile(id_authors, auth_id);
            if (result == "success")
            {
                Response.Redirect("/show");
            }
            else
            {
                Response.Redirect("/show?error=1");
            }
            return View();
        }
    }
}