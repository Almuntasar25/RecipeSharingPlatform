using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipePlatform.BLL.Interfaces;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Services
{
    public class RatingService : IRatingService
    {
        private readonly IGenaricRepository<Rating> _ratingRepository;
        private readonly IRecipeService _recipeService;


        public RatingService(IGenaricRepository<Rating> ratingRepository, IRecipeService recipeService)
        {
            _ratingRepository = ratingRepository;
            _recipeService = recipeService;
        }

        public async Task<Rating> AddRating(int Stars, int RecipeId, string UserId)
        {
            var existingRating = await GetUserRatingForRecipe(RecipeId, UserId);
            if (existingRating != null)
            {
                throw new InvalidOperationException("user already rated recipe!!!!!");
            }
            var rating = new Rating
            {
                Stars = Stars,
                RecipeId = RecipeId,
                UserId = UserId
            };
            var res = await _ratingRepository.Add(rating);
            await _recipeService.UpdateRecipeRating(RecipeId);

            return res;

        }

        public Task<Rating> GetRatingByRecipeIdAndUserId(int RecipeId, string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Rating>> GetRatingsByRecipeId(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Rating>> GetRatingsForRecipe(int recipeId)
        {
            return await _ratingRepository.GetQueryable()
                
                .Where(r => r.RecipeId == recipeId)
                .Include(r => r.Users) 
                .ToListAsync();
        }

        public Task<Rating> GetUserRatingForRecipe(int RecipeId, string UserId)
        {
            return _ratingRepository.GetQueryable()
                .FirstOrDefaultAsync(r => r.RecipeId == RecipeId && r.UserId == UserId);
        }

        public async Task<Rating> UpdateRating(int Stars, int RecipeId, string UserId)
        {
            var existingRating =await GetUserRatingForRecipe(RecipeId, UserId);

            if (existingRating == null)
            {
                throw new InvalidOperationException("user has not rated this recipe yet!!!!!");
            }
            existingRating.Stars = Stars;
            
            var res = await _ratingRepository.Update(existingRating);
            await _recipeService.UpdateRecipeRating(RecipeId);

            return res;


        }
    }
}
