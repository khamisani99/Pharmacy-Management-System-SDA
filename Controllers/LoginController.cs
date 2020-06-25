using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(Project.Models.Login login)
        {
            UserDBHandle dbb = new UserDBHandle();

            using (OOSEPROJECTEntities db = new OOSEPROJECTEntities())
            {
                var user = db.Logins.Where(x => x.UserName == login.UserName && x.UserPassword == login.UserPassword).FirstOrDefault();
                var userDetails = dbb.GetLogins().Find(smodel => smodel.ID == user.UserID);
                if (user == null)
                {
                    login.LoginErrorMessage = "Wrong Username or Password";
                    return View("Index", login);
                }
                else if (userDetails.UserType == "admin")
                {
                    Session["userID"] = user.UserID;
                    Session["userName"] = user.UserName;
                    Session["userType"] = userDetails.UserType;
                    return RedirectToAction("Index", "Home");
                }
                else if (userDetails.UserType == "customer")
                {
                    Session["userID"] = user.UserID;
                    Session["userName"] = user.UserName;
                    Session["userType"] = userDetails.UserType;
                    return RedirectToAction("IndexC", "Home");
                }
                else if (userDetails.UserType == "employee")
                {
                    Session["userID"] = user.UserID;
                    Session["userName"] = user.UserName;
                    Session["userType"] = userDetails.UserType;
                    return RedirectToAction("IndexE", "Home");
                }
                else
                {
                    login.LoginErrorMessage = "Enter valid type!";
                    return View("Index", login);
                }
            }
        }
        public ActionResult LogOut()
        {
            int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Addemp()
        {
            return RedirectToAction("Index", "User");
        }
        public ActionResult Medicin()
        {
            return RedirectToAction("Index", "Medicin");
        }
        public ActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}