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
    public class DistributionPlaceController : Controller
    {
        // GET: DistributionPlace
        public ActionResult Index()
        {
            return View(DistributionPlaceRepo.Get());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DistributionPlaceModel dp)
        {

            DistributionPlaceRepo.Create(dp);
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int Id)
        {

            var db = new Zero_HungerEntities1();
            var dp = (from f in db.DistributionPlaces
                      where f.Id == Id
                      select f).SingleOrDefault();
            return View(dp);

        }
        [HttpPost]
        public ActionResult Edit(DistributionPlaceModel dp)
        {

            var db = new Zero_HungerEntities1();
            var ext = (from f in db.DistributionPlaces
                       where f.Id == dp.Id
                       select f).SingleOrDefault();

            ext.Name = dp.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(DistributionPlaceModel s)
        {
            DistributionPlaceRepo.Delete(s);
            return RedirectToAction("Index");

        }
    }
}