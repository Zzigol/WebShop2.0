using WebShop.Data.Interfaces;
using WebShop.Data.Models;

namespace WebShop.Data.Repozitory
{
    public class CategoryRepozitory : ICarsCategory
    {

        private readonly AppDbContent appDbContent;

        public CategoryRepozitory(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
