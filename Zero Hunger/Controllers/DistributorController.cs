using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class DistributorController : Controller
    {
        // GET: Distributor
        public ActionResult Index()
        {
            return View(DistributorRepo.Get());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DistributorModel dis)
        {

            DistributorRepo.Create(dis);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var db = new Zero_HungerEntities1();
            var dis = (from d in db.Distributors
                        where d.Id == Id
                        select d).SingleOrDefault();
            return View(dis);

        }
        [HttpPost]
        public ActionResult Edit(DistributorModel Dis)
        {

            var db = new Zero_HungerEntities1();
            var ext = (from d in db.Distributors
                       where d.Id == Dis.Id
                       select d).SingleOrDefault();

            ext.Name = Dis.Name;
            ext.Email = Dis.Email;
            ext.Phone = Dis.Phone;
            ext.Password = Dis.Password;
            ext.Dob = Dis.Dob;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(DistributorModel dis)
        {
            DistributorRepo.Delete(dis);
            return RedirectToAction("Index");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}