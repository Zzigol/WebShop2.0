using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class HomeController:Controller
    {
        private readonly IAllCars _carRepozitory;        

        public HomeController(IAllCars carRepozitory)
        {
            _carRepozitory = carRepozitory;         
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRepozitory.GetFavCars
            };
            return View(homeCars);
        }
    }
}
