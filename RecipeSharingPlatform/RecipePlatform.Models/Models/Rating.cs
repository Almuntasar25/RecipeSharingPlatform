using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Models;

namespace RecipePlatform.DAL.Entitys
{
    public class Rating : BaseEntity
    {
        public int Stars { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int RecipeId { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }

        [ForeignKey("RecipeId")]
       
        public Recipe Recipes { get; set; }
    }
}
