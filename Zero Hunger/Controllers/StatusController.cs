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
    public class StatusController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View(StatusRepo.Get());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StatusModel st)
        {

            StatusRepo.Create(st);
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int Id)
        {

            var db = new Zero_HungerEntities1();
            var st = (from f in db.Status
                      where f.Id == Id
                      select f).SingleOrDefault();
            return View(st);

        }
        [HttpPost]
        public ActionResult Edit(StatusModel St)
        {

            var db = new Zero_HungerEntities1();
            var ext = (from f in db.Status
                       where f.Id == St.Id
                       select f).SingleOrDefault();

            ext.Status1 = St.Status1;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(StatusModel s)
        {
            StatusRepo.Delete(s);
            return RedirectToAction("Index");

        }
    }
}