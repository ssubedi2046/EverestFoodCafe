using EverestFoodCafe.Domain.Concrete;
using EverestFoodCafe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverestFoodCafe.Controllers
{
    public class DishesController : Controller
    {
        private IDishesRepository repository;
        public DishesController(IDishesRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            var model = repository.Dishes.ToList();
           // model.AllDishes = db.Dishes.ToList();
            
               return View(model);
        }

     
    }
}