using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;
using Zero_Hunger.Repo;

namespace Zero_Hunger.Controllers
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            return View(FoodRepo.Get());

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FoodModel foo)
        {

            FoodRepo.Create(foo);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var db = new Zero_HungerEntities1();
            var food = (from f in db.Foods
                       where f.Id == Id
                       select f).SingleOrDefault();
            return View(food);

        }
        [HttpPost]
        public ActionResult Edit(FoodModel food)
        {

            var db = new Zero_HungerEntities1();
            var ext = (from f in db.Foods
                       where f.Id == food.Id
                       select f).SingleOrDefault();

            ext.Name = food.Name;
            ext.RottenTime = food.RottenTime;
            ext.LastTimeForCollect = food.LastTimeForCollect;
            ext.Qty = food.Qty;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(FoodModel f)
        {
            FoodRepo.Delete(f);
            return RedirectToAction("Index");
        }
        public ActionResult Add(int Id)
        {
            var f = FoodRepo.Get(Id);
            f.Qty = 1;
            List<Food> foods = null;
            if (Session["cart"] == null)
            {
                foods = new List<Food>();
            }
            else
            {
                var json2 = Session["cart"].ToString();
                foods = new JavaScriptSerializer().Deserialize<List<Food>>(json2);

            }
            foods.Add(f);
            var json = new JavaScriptSerializer().Serialize(foods);
            Session["cart"] = json;
            TempData["msg"] = "Food is Added";
            return RedirectToAction("Index");
        }
        public ActionResult Show()
        {
            if (Session["cart"] == null)
            {
                TempData["msg"] = "This is empty";
                return RedirectToAction("Index");
            }
            var json2 = Session["cart"].ToString();
            var food = new JavaScriptSerializer().Deserialize<List<FoodModel>>(json2);
            
            return View(food);
        }
        [HttpPost]
        public ActionResult Checkout(FoodDetailsModel food)
        {

            FoodRepo.FCreate(food);
            Session["cart"] = null;
            return RedirectToAction("Index");
        }
    }

}