using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Models;
using WebShop.Data;
using WebShop.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebShop.Controllers
{
    public class OrderController:Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            shopCart.ListShopItem = shopCart.GetShopItems();
            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
            }


            if (shopCart.ListShopItem.Count==0)            
                ModelState.AddModelError("", "У вас должны быть товары!");
            
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
