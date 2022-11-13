using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class DistributionRepo
    {
        public static List<FoodDetailsModel> Get()
        {
            var db = new Zero_HungerEntities1();
            var food = new List<FoodDetailsModel>();
            foreach (var f in db.FoodDetails)
            {
                food.Add(new FoodDetailsModel()
                {
                    Id = f.Id,
                    RestaurantName = f.RestaurantName,
                    RestaurantAddress = f.RestaurantAddress,
                    Qty = f.Qty,

                });
            }
            return food;
        }
        public static void Assign(DelivaryModel model)
        {
            var db = new Zero_HungerEntities1();
            var Del = new Delivary()
            {
                RestaurantName = model.RestaurantName,
                RestaurantAddress = model.RestaurantAddress,
                Qty = model.Qty,
                DistributionPlace = model.DistributionPlace,
                DistributorName = model.DistributorName,
                Status = model.Status,

            };
            db.Delivaries.Add(Del);
            db.SaveChanges();

        }
        public static void Delete(int Id)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from d in db.FoodDetails
                       where d.Id == Id
                       select d).SingleOrDefault();

            db.FoodDetails.Remove(ext);
            db.SaveChanges();
        }
    }
}