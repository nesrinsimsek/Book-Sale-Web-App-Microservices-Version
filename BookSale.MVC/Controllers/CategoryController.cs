using BookSale.Sale.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookSale.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return ViewComponent("CategoryList");
        }
    }
}
