using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.DAL.Entitys;

namespace RecipePlatform.BLL.Interfaces
{
    internal interface IAdminService
    {
        Task<ApplicationUser> GetUserById(string userId);
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        
        Task DeleteUser(string userId); 
        Task DeleteRecipe(string recipeId);
        Task<IEnumerable<Recipe>> GetAllRecipesForAdmin();
       
        Task<Dictionary<string, object>> GetAllRecipes();







    }
}
