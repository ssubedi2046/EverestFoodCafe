using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverestFoodCafe.Domain.Concrete;

namespace EverestFoodCafe.Domain.Entities
{
  public  class CartLine
    {
      public Dish Dish { get; set; }
      public int Quantity { get; set; }

    }
}
