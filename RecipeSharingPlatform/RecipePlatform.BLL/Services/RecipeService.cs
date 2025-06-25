using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Context;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IGenaricRepository<Recipe> _recipeRepository;
        private readonly IGenaricRepository<Rating> _ratingRepository;
        private readonly ApplicationDbContext _context;
        public RecipeService(IGenaricRepository<Recipe> recipeRepository,
            IGenaricRepository<Rating> ratingRepository,
            ApplicationDbContext context)
        {
            _recipeRepository = recipeRepository;
            _ratingRepository = ratingRepository;
            _context = context;
        }
        public Task Add(Rating rating)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> CreateRecipe(Recipe recipe)
        {
            recipe.CreatedDate = DateTime.Now;
            return await _recipeRepository.Add(recipe);
        }

        public async Task DeleteRecipe(int id)
        {
            await _recipeRepository.Delete(id);
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipe()
        {
            return await _recipeRepository.GetQueryable()
                .Include(r => r.Categories)
                .Include(r => r.Users)
                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _recipeRepository.GetQueryable()
                .Include(r => r.Categories)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<IEnumerable<Recipe>> GetRecipesByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetRecipesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Recipe>> GetTopRatedRecipes(int count = 10)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        //public async Task<Recipe> UpdateRecipe(Recipe recipe)
        //{
        //    var existingRecipe = _recipeRepository.GetById(recipe.Id);
        //    if (existingRecipe == null)
        //    {
        //        throw new ArgumentException("Recipe not found");
        //    }
        //    existingRecipe.Description = recipe.Description;
        //}

        public Task UpdateRecipeRating(int recipeId, int ratingValue, string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipeRating(int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}
