using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class DelivaryController : Controller
    {
        // GET: Delivary
        public ActionResult Index()
        {
            ViewBag.Status = StatusRepo.Get();
            return View(DelivaryRepo.Get());
        }
        public ActionResult See()
        {
            
            return View(DelivaryRepo.Get());
        }
        
    }
}