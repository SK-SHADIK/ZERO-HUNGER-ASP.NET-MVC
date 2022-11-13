using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class FoodModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime RottenTime { get; set; }
        public System.DateTime LastTimeForCollect { get; set; }
        public int Qty { get; set; }
        public string Email { get; set; }
    }
}