using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Models;
using RecipePlatform.Models.Models.Enums;

namespace RecipePlatform.DAL.Entitys
{
    public class Recipe : BaseEntity
    {
        public string Title { get; set; }
        public string ? Description { get; set; }
        public int Ingredients { get; set; }
        public int Instructions { get; set; }
        public int PrepTimeMinuteserty { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Servings { get; set; }
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Easy;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        // Navigation properties 

        [ForeignKey("UserId")]
        public ApplicationUser Users { get; set; }

        [ForeignKey("CategoryId")]
        
        public Categories Categories { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();






    }
}
