using WebShop.Data.Models;
using System.Collections.Generic;

namespace WebShop.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
