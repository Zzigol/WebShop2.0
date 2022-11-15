using Microsoft.EntityFrameworkCore;
using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repozitory
{
    public class CarRepozitory : IAllCars
    {

        private readonly AppDbContent appDbContent;

        public CarRepozitory(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(p => p.isFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carID) => appDbContent.Car.FirstOrDefault(p => p.id == carID);
        
    }
}
