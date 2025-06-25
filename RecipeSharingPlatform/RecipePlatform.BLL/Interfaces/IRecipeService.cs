using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipe();
        Task<Recipe> GetRecipeById(int id);
        Task<Recipe> CreateRecipe(Recipe recipe);
        Task<Recipe> UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int id);
        Task<IEnumerable<Recipe>> GetRecipesByUserId(string userId);
        Task<IEnumerable<Recipe>> GetRecipesByCategoryId(int categoryId);
        Task UpdateRecipeRating(int recipeId, int ratingValue, string userId);
        Task<IEnumerable<Recipe>> GetTopRatedRecipes(int count = 10);

        Task UpdateRecipeRating(int recipeId);
        Task Add(Rating rating);
    }
}
