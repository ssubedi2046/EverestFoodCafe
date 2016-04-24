using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EverestFoodCafe.Domain.Concrete;

namespace EverestFoodCafe.Domain.Entities
{
  public  class Cart
    {
        private List<CartLine> itemCollection=new List<CartLine>();

      public void AddItem(Dish dish, int quantity)
      {
          CartLine line = itemCollection.FirstOrDefault(d => d.Dish.DishID == dish.DishID);
          if (line == null)
          {
              itemCollection.Add(new CartLine {Dish=dish,Quantity=quantity});
          }
          else
          {
              line.Quantity += quantity;
          }
      }

      public void RemoveLine(Dish dish)
      {
            itemCollection.RemoveAll(d => d.Dish.DishID == dish.DishID);
      }

      public decimal TotalValue()
      {
          return itemCollection.Sum(s => s.Dish.Price*s.Quantity);
      }

      public void Clear()
      {
            itemCollection.Clear();
      }

      public IEnumerable<CartLine> Lines
      {
            get { return itemCollection; }
      
      }
    }
}
