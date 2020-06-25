using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UserDBHandle dbhandle = new UserDBHandle();
            ModelState.Clear();
            return View(dbhandle.GetLogins());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDBHandle db = new UserDBHandle();
                    if (db.AddUser(login))
                    {
                        ViewBag.Message = "User Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            UserDBHandle db = new UserDBHandle();
            return View(db.GetLogins().Find(smodel => smodel.ID == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Employee login)
        {
            try
            {
                //login.ID = id;
                UserDBHandle db = new UserDBHandle();
                db.UpdateDetails(login);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                UserDBHandle db = new UserDBHandle();
                if (db.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "User Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}