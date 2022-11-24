using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repozitory
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }
        
        public void CreateOrder(Order order)
        {
            order.OrderTime=DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();
            var items = shopCart.ListShopItem;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail
                {
                    CarId = el.car.id,
                    OrderId = order.Id,                     
                    Price = el.car.price 
                };
                appDbContent.OrderDetail.Add(orderDetail);
            }
            appDbContent.SaveChanges();
        }
    }
}
