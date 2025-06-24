using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Entitys
{
    public class Categories
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; } = new List<Recipes>();
    }
}
