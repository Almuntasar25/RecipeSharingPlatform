using Microsoft.AspNetCore.Mvc;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.MVC.Controllers
{
    public class RatingController : Controller
    {
        private readonly IGenaricRepository<Rating> _rating;

        public RatingController(IGenaricRepository<Rating> rating)
        {
            _rating = rating;
        }
        public IActionResult Index()
        {
            var ratings = _rating.GetAll();
            return View(ratings);
        }
    }
}
