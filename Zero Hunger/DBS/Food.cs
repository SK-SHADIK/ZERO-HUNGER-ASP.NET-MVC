//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zero_Hunger.DBS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Food
    {
        public Food()
        {
            this.Distributions = new HashSet<Distribution>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime RottenTime { get; set; }
        public System.DateTime LastTimeForCollect { get; set; }
        public int Qty { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Distribution> Distributions { get; set; }
    }
}
