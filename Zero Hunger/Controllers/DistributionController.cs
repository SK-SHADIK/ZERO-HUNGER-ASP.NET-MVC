using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class DistributionController : Controller
    {
        // GET: Distribution
        public ActionResult Index()
        {
            ViewBag.Distributor = DistributorRepo.Get(); 
            ViewBag.DistributePlace = DistributionPlaceRepo.Get(); 
            ViewBag.Status = StatusRepo.Get();
            return View(DistributionRepo.Get());
        }
        [HttpPost]
        public ActionResult Assign(DelivaryModel deta)
        {
            DistributionRepo.Assign(deta);
            DistributionRepo.Delete(deta.Id);
            return RedirectToAction("Index");
        }
    }
}