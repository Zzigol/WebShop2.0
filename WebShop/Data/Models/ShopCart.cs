using Microsoft.EntityFrameworkCore;

namespace WebShop.Data.Models
{
    public class ShopCart
    {
        //public int Id { get; set; }

        private readonly AppDbContent appDbContent;

        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItem { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId")??Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart (Car car)
        {
            this.appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                car = car,
                price=car.price
            });
            appDbContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return appDbContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
