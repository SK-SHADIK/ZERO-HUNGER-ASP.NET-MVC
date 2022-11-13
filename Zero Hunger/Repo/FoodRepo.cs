using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class FoodRepo
    {
        public static List<FoodModel> Get()
        {
            var db = new Zero_HungerEntities1();
            var food = new List<FoodModel>();
            foreach (var f in db.Foods)
            {
                food.Add(new FoodModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                    RottenTime = f.RottenTime,
                    LastTimeForCollect = f.LastTimeForCollect,
                    Qty = f.Qty,
                    Email = f.Email,

                });
            }
            return food;
        }
        public static void Create(FoodModel foo)
        {
            var food = new Food();
            food.Id = foo.Id;
            food.Name = foo.Name;
            food.RottenTime = foo.RottenTime;
            food.LastTimeForCollect = foo.LastTimeForCollect;
            food.Qty = foo.Qty;
            food.Email = foo.Email;

            var db = new Zero_HungerEntities1();
            db.Foods.Add(food);
            db.SaveChanges();
        }
        public static void Delete(FoodModel r)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from f in db.Foods
                       where f.Id == r.Id
                       select f).SingleOrDefault();

            db.Foods.Remove(ext);
            db.SaveChanges();
        }

        public static Food Get(int id)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from f in db.Foods
                       where f.Id == id
                       select f).SingleOrDefault();
            return ext;
        }
        public static int Add(Food model)
        {
            var db = new Zero_HungerEntities1();
            var food = new Food()
            {
                Id = model.Id,
                Name = model.Name,
                RottenTime = model.RottenTime,
                LastTimeForCollect = model.LastTimeForCollect,
                Qty = model.Qty
            };
            db.Foods.Add(food);
            if (db.SaveChanges() > 0)
            {
                return food.Id;
            }
            return 0;

        }
        public static void FCreate(FoodDetailsModel model)
        {
            var db = new Zero_HungerEntities1();
            var food = new FoodDetail()
            {                
                RestaurantName = model.RestaurantName,
                RestaurantAddress = model.RestaurantAddress,
                Qty = model.Qty,

            };
            db.FoodDetails.Add(food);
            db.SaveChanges();

        }
    }
}