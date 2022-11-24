using WebShop.Data.Models;

namespace WebShop.Data.Interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order order);
    }
}
