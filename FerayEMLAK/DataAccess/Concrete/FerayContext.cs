using DataAccess.Mapping;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class FerayContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Aim> Aim { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Users> Users { get; set; }
       
 
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Properties> Properties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-Q6LCBONF\SQLEXPRESS;Database=FERAYEMLAKDATA;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new AimMap());
            modelBuilder.ApplyConfiguration(new CategoriesMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            
        
            modelBuilder.ApplyConfiguration(new ProductImagesMap());
            modelBuilder.ApplyConfiguration(new PropertiesMap());
        }


    }
}
