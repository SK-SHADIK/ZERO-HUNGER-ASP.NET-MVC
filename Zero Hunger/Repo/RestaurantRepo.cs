using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class RestaurantRepo
    {
        public static List<RestaurantModel> Get()
        {
            var db = new Zero_HungerEntities1();
            var res = new List<RestaurantModel>();
            foreach (var rs in db.Restaurants)
            {
                res.Add(new RestaurantModel()
                {
                    Id = rs.Id,
                    Name = rs.Name,
                    Email = rs.Email,
                    Phone = rs.Phone,
                    Password = rs.Password,
                    Address = rs.Address,

                });
            }
            return res;
        }

        public static void Create(RestaurantModel res)
        {
            var restaurant = new Restaurant();
            restaurant.Id = res.Id;
            restaurant.Name = res.Name;
            restaurant.Email = res.Email;
            restaurant.Phone = res.Phone;
            restaurant.Password = res.Password;
            restaurant.Address = res.Address;

            var db = new Zero_HungerEntities1();
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }
        /*public static void Edit(int Id)
        {
            var db = new Zero_HungerEntities1();
            var Res = (from p in db.Restaurants
                           where p.Id == Id
                           select p).SingleOrDefault();
        }
        public static void Edit(RestaurantModel re)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from r in db.Restaurants
                       where r.Id == re.Id
                       select r).SingleOrDefault();

            ext.Name = re.Name;
            ext.Email = re.Email;
            ext.Phone = re.Phone;
            ext.Password = re.Password;
            ext.Address = re.Address;
            db.SaveChanges();
        }*/
        public static void Delete(RestaurantModel r)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from p in db.Restaurants
                       where p.Id == r.Id
                       select p).SingleOrDefault();

            db.Restaurants.Remove(ext);
            db.SaveChanges();
        }
    }
}