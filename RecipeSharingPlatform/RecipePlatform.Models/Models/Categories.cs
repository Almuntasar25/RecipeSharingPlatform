using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.Models.Models;

namespace RecipePlatform.DAL.Entitys
{
    public class Categories : BaseEntity
    {
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
