using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IGenaricRepository<Categories> _categories;

        public CategoriesController(IGenaricRepository<Categories> categories)
        {
            _categories = categories;
        }
        public IActionResult Index()
        {
            var categories = _categories.GetAll();
            return View(categories);
        }
    }
}
