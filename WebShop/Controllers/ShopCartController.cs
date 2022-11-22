using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.Data.Repozitory;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class ShopCartController:Controller
    {
        private readonly IAllCars _carRepozitory;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepozitory, ShopCart shopCart)
        {
            _carRepozitory = carRepozitory;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItem = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRepozitory.Cars.FirstOrDefault(i=>i.id == id);
            if (item !=null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
