using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class DelivaryRepo
    {
        public static List<DelivaryModel> Get()
        {
            var db = new Zero_HungerEntities1();
            var d = new List<DelivaryModel>();
            foreach (var f in db.Delivaries)
            {
                d.Add(new DelivaryModel()
                {
                    Id = f.Id,
                    RestaurantName = f.RestaurantName,
                    RestaurantAddress = f.RestaurantAddress,
                    Qty = f.Qty,
                    DistributionPlace = f.DistributionPlace,
                    DistributorName = f.DistributorName,
                    Status = f.Status,


                });
            }
            return d;
        }
        
    }
}