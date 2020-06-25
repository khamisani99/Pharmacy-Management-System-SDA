using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class MedicinController : Controller
    {
        // GET: Medicin
        public ActionResult Index()
        {
            MedicineDB dbhandle = new MedicineDB();
            ModelState.Clear();
            return View(dbhandle.GetLogins());
        }
        public ActionResult IndexC()
        {
            MedicineDB dbhandle = new MedicineDB();
            ModelState.Clear();
            return View(dbhandle.GetLogins());
        }
        public ActionResult IndexE()
        {
            MedicineDB dbhandle = new MedicineDB();
            ModelState.Clear();
            return View(dbhandle.GetLogins());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Medicine login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MedicineDB db = new MedicineDB();
                    if (db.AddMedicine(login))
                    {
                        ViewBag.Message = "Medicine Added Successfully";
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
            MedicineDB db = new MedicineDB();
            return View(db.GetLogins().Find(smodel => smodel.DrugID == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, Medicine login)
        {
            try
            {
                MedicineDB db = new MedicineDB();
                db.UpdateDetails(login);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                MedicineDB db = new MedicineDB();
                if (db.DeleteUser(id))
                {
                    ViewBag.AlertMsg = "Medicine Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Index1()
        {
            return View();
        }
    }
}