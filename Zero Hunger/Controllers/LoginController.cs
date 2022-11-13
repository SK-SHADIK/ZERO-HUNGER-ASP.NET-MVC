using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hunger.DBS;
using Zero_Hunger.Models;

namespace Zero_Hunger.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RestaurantModel re, EmployeeModel foo)
        {
            if (ModelState.IsValid)
            {
                using (Zero_HungerEntities1 db = new Zero_HungerEntities1())
                {
                    var Res = db.Restaurants.Where(a => a.Email.Equals(re.Email) && a.Password.Equals(re.Password)).FirstOrDefault();
                    var Emp = db.Employees.Where(a => a.Email.Equals(re.Email) && a.Password.Equals(re.Password)).FirstOrDefault();
                    var Dis = db.Distributors.Where(a => a.Email.Equals(re.Email) && a.Password.Equals(re.Password)).FirstOrDefault();
                    if (Res != null)
                    {
                        Session["UserID"] = Res.Id.ToString();
                        Session["Email"] = Res.Email.ToString();
                        Session["Name"] = Res.Name.ToString();
                        Session["Address"] = Res.Address.ToString();
                        return Redirect("/Restaurant/Dashboard");
                    }
                    if (Emp != null)
                    {
                        Session["UserID"] = Emp.Id.ToString();
                        Session["Email"] = Emp.Email.ToString();
                        Session["Name"] = Emp.Name.ToString();
                        return Redirect("/Employee/Index");
                    }
                    if (Dis != null)
                    {
                        Session["UserID"] = Dis.Id.ToString();
                        Session["Email"] = Dis.Email.ToString();
                        Session["Name"] = Dis.Name.ToString();
                        return Redirect("/Distributor/Dashboard");
                    }
                    else
                    {
                        TempData["msg"] = "Somthing Went To Worng!!! Please Try Again";
                    }
                }
            }
            return View(re);
        }
        
    }
}