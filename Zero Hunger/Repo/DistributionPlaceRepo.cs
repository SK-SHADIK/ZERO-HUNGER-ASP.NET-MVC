using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class DistributionPlaceRepo
    {
        public static List<DistributionPlace> Get()
        {
            var db = new Zero_HungerEntities1();
            var dp = new List<DistributionPlace>();
            foreach (var item in db.DistributionPlaces)
            {
                dp.Add(new DistributionPlace()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return dp;
        }
        public static void Create(DistributionPlaceModel dis)
        {
            var dp = new DistributionPlace();
            dp.Id = dis.Id;
            dp.Name = dis.Name;


            var db = new Zero_HungerEntities1();
            db.DistributionPlaces.Add(dp);
            db.SaveChanges();
        }
        public static void Delete(DistributionPlaceModel s)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from f in db.DistributionPlaces
                       where f.Id == s.Id
                       select f).SingleOrDefault();

            db.DistributionPlaces.Remove(ext);
            db.SaveChanges();
        }
    }
}