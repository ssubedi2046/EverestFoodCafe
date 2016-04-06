using EverestFoodCafe.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EverestFoodCafe.Domain.Concrete;

namespace EverestFoodCafe.Controllers
{
    public class DishDetailsController : Controller
    {

        private IDishesRepository repository;
        public DishDetailsController(IDishesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index(int id )
        {

            var dish = repository.Dishes.Where(d => d.DishID == id).FirstOrDefault();
           

            return View("Index", dish);
        }
        [HttpPost]
        public ActionResult Index(Comment comment,int id)
        {
            if(ModelState.IsValid)
            {
                comment.EntryDate = DateTime.Now.Date;
                comment.DishID = id;
                repository.InsertComment(comment);
               
                return RedirectToAction("Index", "DishDetails",id);
                
                 
            }
           
            return View("Index");
            
        }
    }
}
