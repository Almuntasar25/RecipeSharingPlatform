using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Context;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenaricRepository<Recipe> _recipeRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenaricRepository<Rating> _ratingRepository;

        public AdminService(UserManager<ApplicationUser> userManager,
            IGenaricRepository<Recipe> recipeRepository,
            IGenaricRepository<Rating> ratingRepository,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _recipeRepository = recipeRepository;
            _ratingRepository = ratingRepository;
          
        }
        public async Task DeleteRecipe(string recipeId)
        {
            await _recipeRepository.Delete(recipeId);
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                await _userManager.DeleteAsync(user);
            }
        }

        public Task<Dictionary<string, object>> GetAllRecipes()
        {
            return Task.FromResult(new Dictionary<string, object>
            {
                { "Recipes", _recipeRepository.GetAll() },
                { "Ratings", _ratingRepository.GetAll() }
            });
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesForAdmin()
        {
            return await _recipeRepository.GetAll();

        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _userManager.Users
                .Include(x => x.Recipes)
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
           return await _userManager.Users
                .Include(x => x.Recipes)
                .Include(x => x.Ratings)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

    }
}
