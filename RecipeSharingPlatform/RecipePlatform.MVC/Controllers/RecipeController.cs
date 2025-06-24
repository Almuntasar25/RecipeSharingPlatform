using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.MVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IGenaricRepository<Recipe> _recipe;

        public RecipeController(IGenaricRepository<Recipe> recipe)
        {
            _recipe = recipe;
        }
        public IActionResult Index()
        {
            var recipes = _recipe.GetAll();
            return View(recipes);
        }
    }
}
