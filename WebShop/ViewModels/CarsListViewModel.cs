using WebShop.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace WebShop.ViewModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string CurrCategory { get; set; }
    }
}
