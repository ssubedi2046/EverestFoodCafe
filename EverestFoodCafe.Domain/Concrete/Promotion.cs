//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EverestFoodCafe.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promotion
    {
        public int PromotionId { get; set; }
        public string PromotionCategory { get; set; }
        public string Label { get; set; }
        public int DishID { get; set; }
    
        public virtual Dish Dish { get; set; }
    }
}
