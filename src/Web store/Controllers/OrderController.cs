using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Models;
using Web_store.Data;
using Web_store.Data.Interfaces;

namespace Web_store.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrders _orders;
        private readonly ShopCart _shopCart;

        public OrderController(IOrders orders, ShopCart shopCart)
        {
            _orders = orders;
            _shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ItemsInCart = _shopCart.GetShopItems();

            if (_shopCart.ItemsInCart.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            if (ModelState.IsValid)
            {
                _orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            else
            {
                foreach (var modelState in ModelState)
                {
                    Console.WriteLine($"{modelState.Key} {modelState.Value.ValidationState}");
                }
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";

            return View();
        }
    }
}
