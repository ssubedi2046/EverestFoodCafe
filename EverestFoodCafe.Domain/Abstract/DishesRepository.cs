using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using EverestFoodCafe.Domain.Entities;
using EverestFoodCafe.Domain.Concrete;
using System.Data.Entity;

namespace EverestFoodCafe.Domain.Abstract
{
    public class DishesRepository : IDishesRepository
    {
        KathmanduFoodStoreEntities context = new KathmanduFoodStoreEntities();

        public IQueryable<Dish> Dishes
        {
            get
            {
                return context.Dishes;
            }
        }

        public void InsertComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void InsertUpdateDish(Dish dish)
        {
            if(dish.DishID==0)
            {
                context.Dishes.Add(dish);
            }
            else
            {
                var dishes = context.Dishes.Find(dish.DishID);
               context.Entry(dish).State = EntityState.Modified;
            }
           context.SaveChanges();
        }
        public void DeleteDish(int id)
        {
            var dish = context.Dishes.Find(id);
            context.Dishes.Remove(dish);
            context.SaveChanges();

        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
