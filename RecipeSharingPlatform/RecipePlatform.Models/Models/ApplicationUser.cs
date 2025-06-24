using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipePlatform.DAL.Entitys
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Recipes> Recipes { get; set; } = new List<Recipes>();
        public virtual ICollection<Ratings> Ratings { get; set; } = new List<Ratings>();
    }
}
