using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Interfaces
{
    public interface IRatingService
    {
        Task <Rating> AddRating(int Stars , int RecipeId , string UserId );
        Task<Rating> UpdateRating(int Stars, int RecipeId, string UserId);
        Task<Rating> GetRatingByRecipeIdAndUserId(int RecipeId, string UserId);
        Task<Rating> GetUserRatingForRecipe(int RecipeId, string UserId);

        Task<IEnumerable<Rating>> GetRatingsByRecipeId(int RecipeId);
        Task<IEnumerable<Rating>> GetRatingsForRecipe(int recipeId);

    }
}
