using Microsoft.AspNetCore.Mvc;
using WebShop.Data.Interfaces;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class CarsController:Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _allCategories = carsCategory;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel carsListViewModel = new CarsListViewModel();
            carsListViewModel.allCars = _allCars.Cars;
            carsListViewModel.CurrCategory = "Автомобили";

            return View(carsListViewModel);
        }

    }
}
