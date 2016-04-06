
using EverestFoodCafe.Domain.Abstract;
using EverestFoodCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverestFoodCafe.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IDishesRepository repository;
        public HomeController(IDishesRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            PromotionViewModel pvm = new PromotionViewModel();
            pvm.PromoDishes = repository.Dishes.Where(d => d.DishID == 1).ToList();
            return View(pvm);
        }

    }
}