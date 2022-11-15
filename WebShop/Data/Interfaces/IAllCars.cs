using WebShop.Data.Models;
using System.Collections.Generic;

namespace WebShop.Data.Interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> GetFavCars { get; }

        Car GetObjectCar(int carID);

    }
}
