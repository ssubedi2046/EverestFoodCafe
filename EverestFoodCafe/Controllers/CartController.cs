using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EverestFoodCafe.Domain.Abstract;
using EverestFoodCafe.Domain.Concrete;
using EverestFoodCafe.Domain.Entities;
using EverestFoodCafe.Models;

namespace EverestFoodCafe.Controllers
{
    public class CartController : Controller
    {
        private IDishesRepository repository;
        private IOrderProcessing orderProcessing;

        public CartController(IDishesRepository repo,IOrderProcessing orderProcess)
        {
           this.repository = repo;
            orderProcessing = orderProcess;
        }
        // GET: Cart
        public ViewResult Index(Cart cart ,string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart=cart,
                ReturnUrl = returnUrl

            });
        }

        public RedirectToRouteResult AddToCart(Cart cart,string returnUrl,int id)
        {
            Dish dish = repository.Dishes.FirstOrDefault(d => d.DishID == id);
            if (dish != null)
            {
                cart.AddItem(dish,1);
            }
            return RedirectToAction("Index",new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int dishId, string returnUrl)
        {
            Dish dish = repository.Dishes.FirstOrDefault(d => d.DishID == dishId);
            if (dish != null)
            {
                cart.RemoveLine(dish);

            }
            return RedirectToAction("Index", new { returnUrl });

        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessing.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else {
                return View(shippingDetails);
            }
        }


    }
}