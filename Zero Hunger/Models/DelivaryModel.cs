using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.Models
{
    public class DelivaryModel
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public int Qty { get; set; }
        public string DistributionPlace { get; set; }
        public string Status { get; set; }
        public string DistributorName { get; set; }
    }
}