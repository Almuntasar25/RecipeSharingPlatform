using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Entitys
{
    public class Ratings
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public DateTime CreatedDate { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }

        [ForeignKey("RecipeId")]
       
        public Recipes Recipes { get; set; }
    }
}
