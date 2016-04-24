using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EverestFoodCafe.Domain.Entities;

namespace EverestFoodCafe.Models
{
    public class CartViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}