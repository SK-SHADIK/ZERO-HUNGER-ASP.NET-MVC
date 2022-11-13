using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class DistributorRepo
    {
        public static List<DistributorModel> Get()
        {
            var db = new Zero_HungerEntities1();
            var food = new List<DistributorModel>();
            foreach (var d in db.Distributors)
            {
                food.Add(new DistributorModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Email = d.Email,
                    Phone = d.Phone,
                    Password = d.Password,
                    Dob = d.Dob,

                });
            }
            return food;
        }
        public static void Create(DistributorModel Dis)
        {
            var d = new Distributor();
            d.Id = Dis.Id;
            d.Name = Dis.Name;
            d.Email = Dis.Email;
            d.Phone = Dis.Email;
            d.Password = Dis.Password;
            d.Dob = Dis.Dob;

            var db = new Zero_HungerEntities1();
            db.Distributors.Add(d);
            db.SaveChanges();
        }
        public static void Delete(DistributorModel dis)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from d in db.Distributors
                       where d.Id == dis.Id
                       select d).SingleOrDefault();

            db.Distributors.Remove(ext);
            db.SaveChanges();
        }
    }
}