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
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(RestaurantRepo.Get());
        }
        //CREATE RESTAURANT
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantModel res)
        {

            RestaurantRepo.Create(res);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            /*RestaurantRepo.Edit(Id);
            return View();*/

            var db = new Zero_HungerEntities1();
            var Res = (from p in db.Restaurants
                       where p.Id == Id
                       select p).SingleOrDefault();
            return View(Res);

        }
        [HttpPost]
        public ActionResult Edit( RestaurantModel res)
        {
           /* RestaurantRepo.Edit(res);
            return RedirectToAction("Index");*/

            var db = new Zero_HungerEntities1();
            var ext = (from r in db.Restaurants
                       where r.Id == res.Id
                       select r).SingleOrDefault();

            ext.Name = res.Name;
            ext.Email = res.Email;
            ext.Phone = res.Phone;
            ext.Password = res.Password;
            ext.Address = res.Address;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(RestaurantModel r)
        {
            RestaurantRepo.Delete(r);
            return RedirectToAction("Index");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}