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
    public class C_ProfileController : Controller
    {
        private E_Profile profile;
        private List<E_Artikel> artikel;
        private M_Profile ProfileModel = new M_Profile();
        private M_Artikel ArtikelModel = new M_Artikel();
        // GET: Profil
        public ActionResult Show(string id = "")
        {
            profile = ProfileModel.getProfile(id);
            artikel = ArtikelModel.getArtikelByProfile(id);
            ViewBag.profile = profile;
            ViewBag.artikel = artikel;
            return View();
        }
        public ActionResult claim(string id_authors = "", string auth_id = "")
        {

            M_Profile profile = new M_Profile();
            string result = profile.claimProfile(id_authors, auth_id);
            if (result == "success")
            {
                Response.Redirect("/c_profile/show");
            }
            else
            {
                Response.Redirect("/c_profile/show?error=1");
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