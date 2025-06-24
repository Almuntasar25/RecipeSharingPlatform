using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipePlatform.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using RecipePlatform.DAL.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RecipePlatform.DAL.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Users)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Recipes)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
        
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}

