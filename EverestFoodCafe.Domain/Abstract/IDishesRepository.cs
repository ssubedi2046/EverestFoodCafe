using EverestFoodCafe.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverestFoodCafe.Domain.Abstract
{
    public interface IDishesRepository
    {
        IQueryable<Dish> Dishes { get; }
        void InsertComment(Comment comment);
        void InsertUpdateDish(Dish dish);
        void DeleteDish(int id);
    }
}
