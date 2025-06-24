using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Models.Enums;

namespace RecipePlatform.DAL.Entitys
{
    public class Recipes
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ? Description { get; set; }
        public int Ingredients { get; set; }
        public int Instructions { get; set; }
        public int PrepTimeMinuteserty { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties 

        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }
        public int UserId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; } = new List<Ratings>();






    }
}
