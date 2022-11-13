using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Repo
{
    public class StatusRepo
    {
        public static List<Status> Get()
        {
            var db = new Zero_HungerEntities1();
            var status = new List<Status>();
            foreach (var item in db.Status)
            {
                status.Add(new Status()
                {
                    Id = item.Id,
                    Status1 = item.Status1
                });
            }
            return status;
        }
        public static void Create(StatusModel st)
        {
            var stu = new Status();
            stu.Id = st.Id;
            stu.Status1 = st.Status1;
            

            var db = new Zero_HungerEntities1();
            db.Status.Add(stu);
            db.SaveChanges();
        }
        public static void Delete(StatusModel s)
        {
            var db = new Zero_HungerEntities1();
            var ext = (from f in db.Status
                       where f.Id == s.Id
                       select f).SingleOrDefault();

            db.Status.Remove(ext);
            db.SaveChanges();
        }
    }
}