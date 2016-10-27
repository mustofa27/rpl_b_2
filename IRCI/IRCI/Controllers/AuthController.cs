using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IRCI.Models;

namespace IRCI.Controllers
{
    public class AuthController : Controller
    {
        private List<AuthModel> auth;
        private Auth AuthModel = new Auth();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public void Login(string username, string password)
        {
            auth = AuthModel.login(username, password);
            if (auth.Count == 0)
            {
                Response.Redirect("/auth");
            }
            else
            {
                Session["id"] = auth[0].id;
                Session["username"] = auth[0].username;
                Response.Redirect("/search");
            }
            
        }
    }
}