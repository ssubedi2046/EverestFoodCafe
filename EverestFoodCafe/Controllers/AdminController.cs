using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EverestFoodCafe.Domain.Abstract;
using EverestFoodCafe.Domain.Concrete;

namespace EverestFoodCafe.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IDishesRepository repository;
        public AdminController(IDishesRepository repository)
        {
            this.repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var model = repository.Dishes.ToList();
            return View(model);
        }

       
        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DishID,DishName,DishCategory,DishDecription,Image,Price")] Dish dish)
        {
            if (ModelState.IsValid)
            {

                repository.InsertUpdateDish(dish);
                return RedirectToAction("Index");
            }

            return View(dish);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dish dish = repository.Dishes.Where(d => d.DishID == id).FirstOrDefault();
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DishID,DishName,DishCategory,DishDecription,Image,Price")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                repository.InsertUpdateDish(dish);
                return RedirectToAction("Index");
            }
            return View(dish);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dish = repository.Dishes.Where(d => d.DishID == id).FirstOrDefault();
            if (dish == null)
            {
                return HttpNotFound();
            }
            return View(dish);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.DeleteDish(id);
            return RedirectToAction("Index");
        }

      
    }
}
